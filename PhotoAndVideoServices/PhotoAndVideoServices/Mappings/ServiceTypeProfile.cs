using PhotoAndVideoServices.Models;
using BusinessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAndVideoServices.Mappings
{
    public class ServiceTypeProfile : AutoMapper.Profile
    {
        public ServiceTypeProfile()
        {
            CreateMap<ServiceTypeDTO, ServiceTypePM>();
            CreateMap<ServiceTypePM, ServiceTypeDTO>();
        }
    }
}
