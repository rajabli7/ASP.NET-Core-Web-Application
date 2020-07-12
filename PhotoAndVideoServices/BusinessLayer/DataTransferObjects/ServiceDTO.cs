using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DataTransferObjects
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ServiceTypeId { get; set; }

        public List<AdditionDTO> Additions { get; set; }
        public List<ServiceAdditions> ServiceAdditions { get; set; }
    }
}
