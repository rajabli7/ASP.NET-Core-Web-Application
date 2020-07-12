using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class OrderAdditions
    {
        public int OrderId { get; set; }
        public int AdditionId { get; set; }

        public virtual Additions Addition { get; set; }
        public virtual Orders Order { get; set; }
    }
}
