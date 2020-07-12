using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Additions
    {
        public Additions()
        {
            OrderAdditions = new HashSet<OrderAdditions>();
            ServiceAdditions = new HashSet<ServiceAdditions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual ICollection<OrderAdditions> OrderAdditions { get; set; }
        public virtual ICollection<ServiceAdditions> ServiceAdditions { get; set; }
    }
}
