using BusinessLayer.DataTransferObjects;
using PhotoAndVideoServices.Models;

namespace PhotoAndVideoServices.Mappings
{
    class DepartmentProfile: AutoMapper.Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentDTO, DepartmentPM>();
        }
    }
}
