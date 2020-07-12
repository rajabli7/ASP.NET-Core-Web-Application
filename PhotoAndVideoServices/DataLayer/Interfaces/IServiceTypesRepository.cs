using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IServiceTypesRepository
    {
        IEnumerable<ServiceTypes> GetAll();
        ServiceTypes GetById(int id);
        ServiceTypes GetWithServices(int id);
        IEnumerable<Services> GetServices(int id);
    }
}
