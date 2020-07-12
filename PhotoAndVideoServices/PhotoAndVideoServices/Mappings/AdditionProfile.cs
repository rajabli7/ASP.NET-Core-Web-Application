using BusinessLayer.DataTransferObjects;
using PhotoAndVideoServices.Models;

namespace PhotoAndVideoServices.Mappings
{
    class AdditionProfile: AutoMapper.Profile
    {
        public AdditionProfile()
        {
            CreateMap<AdditionDTO, AdditionPM>();
            CreateMap<AdditionPM, AdditionDTO>();
        }
    }
}
