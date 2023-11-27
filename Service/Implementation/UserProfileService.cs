using Domain.Domain_models;
using Domain.DTO;
using Domain.Identity;
using Microsoft.AspNetCore.Http;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Implementation
{
    public class UserProfileService : IUserProfileService
    {
        public readonly IUserRepository _userRepository;
        public readonly ICommentRepository _commentRepository;
        public readonly ShopApplicationUser _user;

        public UserProfileService (IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ICommentRepository commentRepository)
        {
            this._userRepository = userRepository;
            this._user = _userRepository.GetByEmail(httpContextAccessor.HttpContext.User.Identity.Name);
            this._commentRepository = commentRepository;

      }
        public UserDTO GetMyProfile()
        {
            var comments = this._commentRepository.GetByReceiver(_user.Id);

            UserDTO userDTO = new UserDTO
            {
                Name = _user.Name,
                Surname = _user.Surname,
                Phone = _user.Phone,
                Address = _user.Address,
                Email = _user.Email,
                Username = _user.Username,
                City = _user.City,
                PostalCode = _user.PostalCode,
                Rating = _user.UserRating,
                RatingCount = _user.UserRatingCount,
                Comments = comments
            };

            return userDTO;
        }
    }
}
