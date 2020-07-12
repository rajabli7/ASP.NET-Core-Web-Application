using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class ServiceAdditions
    {
        public int ServiceId { get; set; }
        public int AdditionId { get; set; }

        public virtual Additions Addition { get; set; }
        public virtual Services Service { get; set; }
    }
}
