﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAndVideoServices.Models
{
    public class UserPM
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int DepartmentId { get; set; }

        public string FullName => $"{Surname} {Name} {MiddleName}";
    }
}
