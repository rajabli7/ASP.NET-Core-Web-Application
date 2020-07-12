using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Users
    {
        public Users()
        {
            EmployeeOrders = new HashSet<EmployeeOrders>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<EmployeeOrders> EmployeeOrders { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
