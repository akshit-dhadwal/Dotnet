using ServiceLayer.Interfaces;
using ServiceLayer.ResponseModel;
using ServiceLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        public async Task<ApiResponse> GetUsername(string username)
        {
            var data = username.Trim();
            return ApiResponses.Success("API Runs Succesfully" , data);
        }
    }
}
