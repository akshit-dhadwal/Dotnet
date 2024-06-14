using Microsoft.AspNetCore.Http;
using ServiceLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Utils
{
    public class ApiResponses
    {
        public static ApiResponse RequestorDoesNotExist()
        {
            return new ApiResponse(StatusCodes.Status401Unauthorized, false, "User does not exist.");
        }

        public static ApiResponse ResourceDoesNotExist(string resourceName)
        {
            return new ApiResponse(StatusCodes.Status404NotFound, false, $"{resourceName} does not exist.");
        }

        public static ApiResponse Success(string message, object data = null, Pager pagingInfo = null)
        {
            return new ApiResponse(StatusCodes.Status200OK, true, message, data, pagingInfo);
        }

        public static ApiResponse Forbidden()
        {
            return new ApiResponse(StatusCodes.Status403Forbidden, false, "You are not allowed to perform this operation");
        }

        public static ApiResponse BadRequest(string message)
        {
            return new ApiResponse(StatusCodes.Status400BadRequest, false, message);
        }

        public static ApiResponse PagedData(object data, int totalCount, int pageNumber, int pageSize)
        {
            return Success("", data, new Pager(totalCount, pageNumber, pageSize));
        }

        public static ApiResponse SingleData(object data)
        {
            return Success("", data);
        }
    }
}
