using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Mappings
{
    class DepartmentInfoProfile: AutoMapper.Profile
    {
        public DepartmentInfoProfile()
        {
            CreateMap<DepartmentInfomations, DepartmentInfomationDTO>();
            CreateMap<DepartmentInfomationDTO, DepartmentInfomations>();
        }
    }
}
