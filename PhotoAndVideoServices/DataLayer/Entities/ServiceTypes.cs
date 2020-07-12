using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class ServiceTypes
    {
        public ServiceTypes()
        {
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Services> Services { get; set; }
    }
}
