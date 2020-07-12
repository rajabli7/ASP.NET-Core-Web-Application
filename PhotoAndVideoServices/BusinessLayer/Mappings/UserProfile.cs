using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Mappings
{
    class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<Users, UserDTO>();
            CreateMap<UserDTO, Users>();
        }
    }
}
