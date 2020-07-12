using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Mappings
{
    class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Orders, OrderDTO>();
            CreateMap<OrderDTO, Orders>();
        }
    }
}
