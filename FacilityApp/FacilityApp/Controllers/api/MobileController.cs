using FacilityApp.Core;
using FacilityApp.Data;
using FacilityApp.Models;
using FacilityApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FacilityApp.Controllers.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MobileController: ControllerBase
    {
        private readonly FacilityAppDbContext _db;


        public MobileController(FacilityAppDbContext db)
        {
            _db = db;
        
        }

        [HttpGet]
       [ActionName("test")]
        public string  Test()
        {
            return "hello api";
        }

        [HttpPost]
        public APIResponse SignIn(SignInRequest request)
        {
            APIResponse apiResponse = null;
            try
            {
               var user=  _db.Users.Where(x => x.UserName.ToLower() == request.UserName.ToLower()).FirstOrDefault();
              
                if (user == null || (user != null && !BCrypt.Net.BCrypt.Verify(request.Password,user.Password)))
                {
                    apiResponse= ErrorResponse(message: Constants.SignInErrorMessge);
                }
                else
                {
                    //Token Generation 

                   var token= Util.GenerateToken(user.UserId.ToString());

                    SignInResponse response = new SignInResponse() { UserName = request.UserName, Token=token };
                    apiResponse= SuccessResponse(response: response);

                }
            }

            catch (Exception ex)
            {
                apiResponse=HandleException(ex);
            }

            return apiResponse;
        }

        [Authorize]
        [HttpPost]
        public APIResponse RequestListing(ListRequest request)
        {
            APIResponse apiResponse = null;
            try
            {

                var requestItems = (from m in _db.Maintanance
                                    join
                r in _db.RequestStatus on m.RequestStatusId equals r.RequestStatusId
                                    join u in _db.Users on m.TenantId equals u.UserId
                                    where m.Status == Statics.RecordState.Active && r.Status == Statics.RecordState.Active
                                    && u.UserId == Statics.Userid
                                    select new RequestItem() { RequestId = m.MaintananceId, Status = r.Name, CreatedDate = m.CreatedDate }).ToList<RequestItem>();

                if (requestItems == null)
                {
                    requestItems = new List<RequestItem>();
                }

                apiResponse = SuccessResponse(response: requestItems);


            }

            catch (Exception ex)
            {
                apiResponse = HandleException(ex);
            }

            return apiResponse;
        }

        [Authorize]
        [HttpPost]
        public APIResponse CreateRequest(MainteinanceRequest request)
        {
            APIResponse apiResponse = null;
            try
            {
                Maintenance maintenance = new Maintenance();
                maintenance.IssueTypeId = request.IssueTypeId;
                maintenance.IssueDetails = request.Description;
                var tenantid= _db.Users.Where(x => x.UserId == Statics.Userid).Select(x => x.TenantId).FirstOrDefault();
                var tenatntdetails = _db.TenantFlatDetails.Where(x => x.TenantId == tenantid).FirstOrDefault();
                maintenance.BuildingId = (int)tenatntdetails.BuildingId ;
                maintenance.RequestStatusId = 1;
                maintenance.FlatId = tenatntdetails.FlatId;
                AddDetais(maintenance);
                _db.Maintanance.Add(maintenance);
             int id=   _db.SaveChanges();
              MaintenanceResponse response= new MaintenanceResponse();
                response.MaintenanceId= maintenance.MaintananceId;
                apiResponse=SuccessResponse(response);
            }

            catch (Exception ex)
            {
                apiResponse = HandleException(ex);
            }

            return apiResponse;
        }

        protected dynamic AddDetais(dynamic obj)
        {
            obj.CreatedBy = Statics.Userid;
            obj.CreatedDate = DateTime.Now;
            return obj;
        }
        [NonAction]
        public APIResponse HandleException(Exception ex)
        {
            string errorID = "";// _logger.LogException(ex);
            var errorMessage = string.Concat(Constants.ErrorMessge);
            return new APIResponse() { StatusCode = HttpStatusCode.InternalServerError, responseData = new ResponseData() { Message = errorMessage, Data = new Object() } };
        }
        [NonAction]
        public APIResponse SuccessResponse(dynamic response = null, string message = null)
        {
            return new APIResponse() { StatusCode = HttpStatusCode.OK, responseData = new ResponseData() { Data = response, Message = "" } };
        }
        [NonAction]
        public APIResponse ErrorResponse(dynamic response = null, string message = null)
        {
            return new APIResponse() { StatusCode = HttpStatusCode.Accepted, responseData = new ResponseData() { Message = message, Data = null } };
        }
    }
}
