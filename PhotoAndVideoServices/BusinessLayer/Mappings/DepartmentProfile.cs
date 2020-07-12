using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Mappings
{
    class DepartmentProfile: AutoMapper.Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Departments, DepartmentDTO>();
            CreateMap<DepartmentDTO, Departments>();
        }
    }
}
