using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Departments
    {
        public Departments()
        {
            DepartmentInfomations = new HashSet<DepartmentInfomations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<DepartmentInfomations> DepartmentInfomations { get; set; }
    }
}
