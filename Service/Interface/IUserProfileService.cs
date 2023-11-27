using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IUserProfileService
    {
        UserDTO GetMyProfile();
    }
}
