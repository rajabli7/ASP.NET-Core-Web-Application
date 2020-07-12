using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;
using PhotoAndVideoServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAndVideoServices.Mappings
{
    class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, UserPM>();
            CreateMap<UserPM, UserDTO>();
        }
    }
}
