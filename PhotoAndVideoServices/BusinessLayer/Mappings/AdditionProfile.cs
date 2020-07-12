using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Mappings
{
    class AdditionProfile: AutoMapper.Profile
    {
        public AdditionProfile()
        {
            CreateMap<Additions, AdditionDTO>();
            CreateMap<AdditionDTO, Additions>();
        }
    }
}
