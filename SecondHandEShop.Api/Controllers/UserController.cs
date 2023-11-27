using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandEShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserProfileService _userProfileService;
        private IUserService _userService;

        public UserController(IUserProfileService userProfileService, IUserService userService)
        {
            this._userProfileService = userProfileService;
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult GetMyProfile()
        {
            return Ok(_userProfileService.GetMyProfile());
        }

        [HttpGet("{username}")]
        public IActionResult GetProfile(string username)
        {
            return Ok(_userService.GetProfile(username));
        }

    }
}
