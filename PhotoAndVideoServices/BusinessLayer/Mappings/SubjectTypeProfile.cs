using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;

namespace BusinessLayer.Mappings
{
    class ServiceTypeProfile : AutoMapper.Profile
    {
        public ServiceTypeProfile()
        {
            CreateMap<ServiceTypes, ServiceTypeDTO>();
            CreateMap<ServiceTypeDTO, ServiceTypes>();
        }
    }
}
