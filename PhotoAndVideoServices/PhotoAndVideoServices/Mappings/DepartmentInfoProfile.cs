using BusinessLayer.DataTransferObjects;
using PhotoAndVideoServices.Models;

namespace PhotoAndVideoServices.Mappings
{
    class DepartmentInfoProfile: AutoMapper.Profile
    {
        public DepartmentInfoProfile()
        {
            CreateMap<DepartmentInfomationDTO, DepartmentInfomationPM>();
        }
    }
}
