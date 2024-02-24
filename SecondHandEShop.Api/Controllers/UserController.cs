﻿using Domain.DTO;
using Domain.CustomExceptions;
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

        [HttpPut]
        public IActionResult EditMyProfile([FromBody] ProfileEditRequestDTO request)
        {
            UserDTO userDTO = request.UserDTO;
            string password = request.Password;
            try
            {
                return Ok(_userProfileService.EditMyUserProfile(userDTO, password));
            }
            catch (InvalidPasswordException ex)
            {
                return BadRequest(new { error = "InvalidPassword", message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to update user profile.");
            }
        }
        //dali samo da e get?
        [HttpPut("subscribe")]
        public IActionResult Subscribe( string username)
        {
            try
            {
                return Ok(_userService.Subscribe(username));
            }
            catch (InvalidEmailPasswordException ex)
            {
                return BadRequest(new { error = "Invalid neshto we gotta test this", message = ex.Message });
            }
        }

        [HttpPut("unsubscribe")]
        public IActionResult Unsubscribe(string username)
        {
            try
            {
                return Ok(_userService.Unsubscribe( username));
            }
            catch (InvalidEmailPasswordException ex)
            {
                return BadRequest(new { error = "Invalid neshto we gotta test this", message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            try
            {
                _userProfileService.ChangePassword(changePasswordDTO.OldPassword, changePasswordDTO.NewPassword, changePasswordDTO.RepeatNewPassword);

                return Ok(new { Message = "Password changed successfully." });
            }
            catch (InvalidPasswordException ex)
            {
                return BadRequest(new { Message = "Invalid old password." });
            }
            catch (PasswordMismatchException ex)
            {
                return BadRequest(new { Message = "New passwords do not match." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Failed to change password.", Error = ex.Message });
            }
        }
    }
}
