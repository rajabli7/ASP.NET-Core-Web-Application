using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAndVideoServices.Models
{
    public class ServicePM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public List<AdditionPM> Additions { get; set; }
    }
}
