using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class DepartmentInfomations
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int IdDepartment { get; set; }

        public virtual Departments IdDepartmentNavigation { get; set; }
    }
}
