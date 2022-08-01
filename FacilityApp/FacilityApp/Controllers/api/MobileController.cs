using FacilityApp.Core;
using FacilityApp.Data;
using FacilityApp.Models;
using FacilityApp.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FacilityApp.Controllers.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class MobileController : ControllerBase
    {
        private readonly FacilityAppDbContext _db;


        public MobileController(FacilityAppDbContext db)
        {
            _db = db;

        }

        [HttpGet]
        [ActionName("test")]
        public string Test()
        {
            return "hello api";
        }

        [HttpPost]
        public APIResponse SignIn(SignInRequest request)
        {
            APIResponse apiResponse = null;
            try
            {
                var user = _db.Users.Where(x => x.UserName.ToLower() == request.UserName.ToLower()).FirstOrDefault();
                var rolename = _db.UserRole.Where(x => x.RoleId == user.RoleId).Select(x => x.RoleName).FirstOrDefault();

                if (user == null || (user != null && !BCrypt.Net.BCrypt.Verify(request.Password, user.Password)))
                {
                    apiResponse = ErrorResponse(message: Constants.SignInErrorMessge);
                }
                else
                {
                    //Token Generation 

                    var token = Util.GenerateToken(user.UserId.ToString(), rolename);


                    SignInResponse response = new SignInResponse() { UserName = request.UserName, Token = token, RoleName = rolename };
                    apiResponse = SuccessResponse(response: response);

                }
            }

            catch (Exception ex)
            {
                apiResponse = HandleException(ex);
            }

            return apiResponse;
        }

        [Authorize]
        [HttpPost]
        public APIResponse Home(ListRequest request)
        {
            APIResponse apiResponse = null;
            List<KeyValue> response = null;
            try
            {
                if (Statics.RoleName.ToLower() == "tenant")
                {
                    var tenantDetails = (from u in _db.Users
                                         join t in _db.Tenant on u.TenantId equals t.TenantId
                                         join tf in _db.TenantFlatDetails on t.TenantId equals tf.TenantId

                                         join b in _db.Building on tf.BuildingId equals b.BuildingId
                                         join flat in _db.Flat on tf.FlatId equals flat.FlatId
                                         where u.UserId == Statics.Userid
                                         select new { t, u, buildingName = b.Name, flatname = flat.Name }).FirstOrDefault();

                    if (tenantDetails != null)
                    {

                        response = new List<KeyValue>();
                        KeyValue item1 = new KeyValue() { Key = "Building Name", Value = tenantDetails.buildingName.ToUpper() };

                        KeyValue item2 = new KeyValue() { Key = "Flat Name", Value = tenantDetails.flatname.ToUpper() };

                        KeyValue item3 = new KeyValue() { Key = "User Name", Value = tenantDetails.u.UserName.ToUpper() };
                        KeyValue item4 = new KeyValue() { Key = "Full Name", Value = tenantDetails.t.Name };
                        KeyValue item5 = new KeyValue() { Key = "Email ID", Value = tenantDetails.t.EmailId };
                        KeyValue item6 = new KeyValue() { Key = "Mobile No", Value = tenantDetails.t.MobileNo };

                        response.Add(item1);
                        response.Add(item2);
                        response.Add(item3);
                        response.Add(item4);
                        response.Add(item5);
                        response.Add(item6);


                    }


                }
                else
                {


                    var userDetails = (from u in _db.Users
                                       join ur in _db.UserRole on u.RoleId equals ur.RoleId
                                       where u.UserId == Statics.Userid
                                       select new { u.UserName, u.Name, u.EmailID, u.MobileNo, ur.RoleName }).FirstOrDefault();
                    response = new List<KeyValue>();
                    KeyValue item3 = new KeyValue() { Key = "Email ID", Value = userDetails.EmailID };

                    KeyValue item4 = new KeyValue() { Key = "Role Name", Value = userDetails.RoleName.ToUpper() };

                    KeyValue item1 = new KeyValue() { Key = "User Name", Value = userDetails.UserName.ToUpper() };
                    KeyValue item2 = new KeyValue() { Key = "Full Name", Value = userDetails.Name };

                    response.Add(item1);
                    response.Add(item2);
                    response.Add(item3);
                    response.Add(item4);
                }

                //  apiResponse = ErrorResponse("Tenant Details Not Found");



                apiResponse = SuccessResponse(response: response);


            }

            catch (Exception ex)
            {
                apiResponse = HandleException(ex);
            }

            return apiResponse;
        }
        [Authorize]
        [HttpPost]
        public APIResponse RequestListing(ListRequest request)
        {
            APIResponse apiResponse = null;
            List<RequestItem> requestItems = null;
            try
            {
                if (Statics.RoleName.ToLower() == "tenant")
                {
                    requestItems = (from m in _db.Maintanance
                                    join
                r in _db.RequestStatus on m.RequestStatusId equals r.RequestStatusId
                                    join u in _db.Users on m.TenantId equals u.UserId
                                    join issue in _db.IssueTypes on m.IssueTypeId equals issue.IssueTypeId
                                    where m.Status == Statics.RecordState.Active && r.Status == Statics.RecordState.Active
                                    && u.UserId == Statics.Userid
                                    select new RequestItem() { RequestId = m.MaintananceId, IssueTypeId = issue.IssueTypeId, Description = m.IssueDetails, Status = r.Name, StatusId = r.RequestStatusId, CreatedDate = m.CreatedDate }).ToList<RequestItem>();

                    if (requestItems == null)
                    {
                        requestItems = new List<RequestItem>();
                    }
                }
                else
                {
                    requestItems = (from m in _db.Maintanance
                                    join
                r in _db.RequestStatus on m.RequestStatusId equals r.RequestStatusId
                                    join u in _db.Users on m.UserId equals u.UserId
                                    join issue in _db.IssueTypes on m.IssueTypeId equals issue.IssueTypeId
                                    where m.Status == Statics.RecordState.Active && r.Status == Statics.RecordState.Active
                                    && u.UserId == Statics.Userid
                                    select new RequestItem() { RequestId = m.MaintananceId, IssueTypeId = issue.IssueTypeId, Description = m.IssueDetails, Status = r.Name, StatusId = r.RequestStatusId, CreatedDate = m.CreatedDate }).ToList<RequestItem>();



                }

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
            int id = 0;
            try
            {
                Maintenance maintenance = null;
                if (request.RequestId > 0)
                {
                    maintenance = _db.Maintanance.Where(x => x.MaintananceId == request.RequestId).FirstOrDefault();
                    maintenance.RequestStatusId = request.StatusId;
                    maintenance.IssueDetails = request.Description;
                    maintenance=UpdateDetails(maintenance);
                    _db.Maintanance.Update(maintenance);

                }
                else
                {
                    maintenance = new Maintenance();

                    maintenance.IssueTypeId = request.IssueTypeId;
                    maintenance.IssueDetails = request.Description;
                    maintenance.TenantId = Statics.Userid; // stores tenant userid
                    var tenantid = _db.Users.Where(x => x.UserId == Statics.Userid).Select(x => x.TenantId).FirstOrDefault();
                    var tenatntdetails = _db.TenantFlatDetails.Where(x => x.TenantId == tenantid).FirstOrDefault();
                    maintenance.BuildingId = (int)tenatntdetails.BuildingId;
                    maintenance.RequestStatusId = 1;
                    maintenance.FlatId = tenatntdetails.FlatId;
                    AddDetais(maintenance);
                    _db.Maintanance.Add(maintenance);

                }
               
                if (request.RequestId > 0)
                {
                    _db.SaveChanges();
                    id = (int)request.RequestId;
                }
                else
                {
                    id = _db.SaveChanges();
                }

                MaintenanceResponse response = new MaintenanceResponse();
                response.MaintenanceId = maintenance.MaintananceId;
                apiResponse = SuccessResponse(response);
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
        protected dynamic UpdateDetails(dynamic obj)
        {
            obj.UpdatedBy = Statics.Userid;
            obj.UpdatedDate = DateTime.Now;
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
