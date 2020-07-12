using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class EmployeeEquipment
    {
        public int EmployeeId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Users Employee { get; set; }
        //public virtual Equipment Equipment { get; set; }
    }
}
