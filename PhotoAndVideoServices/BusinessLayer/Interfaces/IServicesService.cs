using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IServicesService
    {
        void Delete(int id);
        IEnumerable<AdditionDTO> GetAdditions(int id);
        ServiceDTO GetById(int id);
        void Save(ServiceDTO serviceDTO);
        void DeleteAdditions(int id);
    }
}
