using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAndVideoServices.Models
{
    public class DepartmentPM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public List<DepartmentInfomationPM> DepartmentInfomations { get; set; }
    }
}
