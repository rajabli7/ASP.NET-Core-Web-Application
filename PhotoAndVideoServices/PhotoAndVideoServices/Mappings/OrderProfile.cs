using BusinessLayer.DataTransferObjects;
using PhotoAndVideoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAndVideoServices.Mappings
{
    public class OrderProfile: AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, OrderPM>();
            CreateMap<OrderPM, OrderDTO>();
        }
    }
}
