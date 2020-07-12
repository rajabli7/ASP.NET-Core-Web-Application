using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DataTransferObjects
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime? ProjectDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }

        public ServiceDTO Service { get; set; }
        public UserDTO User { get; set; }
    }
}
