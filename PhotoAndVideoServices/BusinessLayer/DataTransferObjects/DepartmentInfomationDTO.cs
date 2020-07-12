using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DataTransferObjects
{
    public class DepartmentInfomationDTO
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int IdDepartment { get; set; }
    }
}
