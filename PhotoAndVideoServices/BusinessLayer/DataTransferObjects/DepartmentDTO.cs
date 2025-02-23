﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DataTransferObjects
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public List<DepartmentInfomationDTO> DepartmentInfomations { get; set; }
    }
}
