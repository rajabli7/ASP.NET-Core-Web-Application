using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class EmployeeOrders
    {
        public int EmployeeId { get; set; }
        public int OrderId { get; set; }

        public virtual Users Employee { get; set; }
        public virtual Orders Order { get; set; }
    }
}
