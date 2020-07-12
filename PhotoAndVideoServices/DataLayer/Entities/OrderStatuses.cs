using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class OrderStatuses
    {
        public OrderStatuses()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
