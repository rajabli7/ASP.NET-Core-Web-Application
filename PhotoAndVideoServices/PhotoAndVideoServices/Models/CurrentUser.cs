using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAndVideoServices.Models
{
    public class CurrentUser
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public bool IsAdmin => RoleId == (int)RolesNames.Administrator;
        public bool IsClient => RoleId == (int)RolesNames.Client;
        public bool IsEmployee => RoleId == (int)RolesNames.Employee;
        public bool IsGuest => !(RoleId == (int)RolesNames.Administrator || RoleId == (int)RolesNames.Client || RoleId == (int)RolesNames.Employee);

    }
}
