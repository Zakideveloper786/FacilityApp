using System.Net;

namespace FacilityApp.ViewModels
{
    public class MobileVM
    {

    }

    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;       
        public ResponseData? responseData { get; set; }
    }

  
    public class ResponseData
    {
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
    public  class SignInRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class SignInResponse
    {
        public string Token { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

    }

    public class MainteinanceRequest
    {

        public int IssueTypeId { get; set; }
        public string Description { get; set; }

    }

    public class MaintenanceResponse
    {

        public int MaintenanceId { get; set; }
    }

    public class ListRequest
    {
        public int userId { get; set; }
    }

    public class ListResponse
    {
        public List<RequestItem> ResultData { get; set; }
    }

    public class RequestItem
    {
        public int RequestId { get; set; }
        public string  Status { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    public class ChangePwRequest
    {

    }

    public class ChangePwResponse
    {

    }
}
