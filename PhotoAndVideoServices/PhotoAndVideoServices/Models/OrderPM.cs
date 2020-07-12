using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAndVideoServices.Models
{
    public class OrderPM
    {
        public int Id { get; set; }
        public DateTime? ProjectDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }

        public ServicePM Service { get; set; }
        public UserPM User { get; set; }
        public List<UserPM> Employees { get; set; }
        public List<AdditionPM> Additions { get; set; }

        //-----------
        public string StatusName { get; set; }
    }
}
