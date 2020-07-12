using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Mappings
{
    class ServiceProfile : AutoMapper.Profile
    {
        public ServiceProfile()
        {
            CreateMap<DataLayer.Entities.Services, ServiceDTO>();
            CreateMap<ServiceDTO, DataLayer.Entities.Services>();
        }
    }
}
