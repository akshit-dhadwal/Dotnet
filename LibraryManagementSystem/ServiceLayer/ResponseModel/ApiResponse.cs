using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServiceLayer.ResponseModel
{
    [Serializable]
    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = "data")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; }
        [DataMember(Name = "statusCode")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int StatusCode { get; }
        [DataMember(Name = "status")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Status { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "message")]
        public string Message { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "pagination")]
        public Pages Pagination { get; set; }
        public ApiResponse(int statusCode, bool status, string message = null, object result = null, Pager pagination = null)
        {
            StatusCode = statusCode;
            Status = status;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Data = result;
            Pagination = setPagination(pagination);
        }
        public class Pages
        {
            public long TotalItems { get; set; }
            public long TotalPages { get; set; }
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
        }
        private static Pages setPagination(Pager pager)
        {
            if (pager == null)
                return null;
            var page = new Pages();
            page.TotalPages = pager.TotalPages;
            page.CurrentPage = pager.CurrentPage;
            page.PageSize = pager.PageSize;
            page.TotalItems = pager.TotalItems;
            return page;
        }
        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";
                case 500:
                    return "Internal Server Error";
                case 502:
                    return "Bad Gateway";
                case 503:
                    return "Service Unavailable";
                default:
                    return null;
            }
        }
    }
    //public class ApiOkResponse : ApiResponse
    //{
    //    public ApiOkResponse(object result, string message = "Data is successfully returned.")
    //        : base(200, true, message)
    //    {
    //    }
    //}
    //public class CommanResponse
    //{
    //    public string Success { get; set; }
    //    public string Message { get; set; }
    //}
}
