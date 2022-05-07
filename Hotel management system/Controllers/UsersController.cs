using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_management_system.Data;
using Hotel_management_system.Models.DTOs;
using Hotel_management_system.Models.Interfaces;
using Hotel_management_system.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hotel_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO data)
        {
            await _userService.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return Ok("Registered done");

            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Authenticaten(LoginDataDTO data)
        {
            var user = await _userService.Authenticate(data);
            if (user != null)
            {
                return user;
            }
            return Unauthorized();
        }

    }
}
