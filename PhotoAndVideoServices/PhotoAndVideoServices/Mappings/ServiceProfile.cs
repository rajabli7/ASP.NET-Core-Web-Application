using PhotoAndVideoServices.Models;
using BusinessLayer.DataTransferObjects;

namespace PhotoAndVideoServices.Mappings
{
    class ServiceProfile: AutoMapper.Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceDTO, ServicePM>();
            CreateMap<ServicePM, ServiceDTO>();
        }
    }
}
