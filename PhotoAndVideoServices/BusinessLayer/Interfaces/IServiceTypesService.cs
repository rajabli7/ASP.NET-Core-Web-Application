using BusinessLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IServiceTypesService
    {
        ServiceTypeDTO GetById(int id);
        IEnumerable<ServiceTypeDTO> GetAll();
        ServiceTypeDTO GetWithServices(int id);
        IEnumerable<ServiceDTO> GetServices(int id);
    }
}
