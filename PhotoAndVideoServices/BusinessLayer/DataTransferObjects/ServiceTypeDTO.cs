using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DataTransferObjects
{
    public class ServiceTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ServiceDTO> Services { get; set; }
    }
}
