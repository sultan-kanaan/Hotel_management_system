using Hotel_management_system.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        // public Task<ApplicationUser> Register(RegisterUser data, ModelStateDictionary modelState);

        //public Task<UserDTO> Authenticate(string username, string password);
        public Task<UserDTO> Authenticate(LoginDataDTO data);
    }
}
