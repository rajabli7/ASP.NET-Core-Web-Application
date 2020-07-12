using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            EmployeeOrders = new HashSet<EmployeeOrders>();
            OrderAdditions = new HashSet<OrderAdditions>();
        }

        public int Id { get; set; }
        public DateTime? ProjectDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int StatusId { get; set; }

        public virtual Services Service { get; set; }
        public virtual OrderStatuses Status { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<EmployeeOrders> EmployeeOrders { get; set; }
        public virtual ICollection<OrderAdditions> OrderAdditions { get; set; }
    }
}
