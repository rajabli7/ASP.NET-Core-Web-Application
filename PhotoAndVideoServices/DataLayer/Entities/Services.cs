using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Services
    {
        public Services()
        {
            Orders = new HashSet<Orders>();
            ServiceAdditions = new HashSet<ServiceAdditions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ServiceTypeId { get; set; }

        public virtual ServiceTypes ServiceType { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<ServiceAdditions> ServiceAdditions { get; set; }
    }
}
