using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IServicesRepository
    {
        IEnumerable<Additions> GetAdditions(int serviceId);
        Services GetById(int id);
        void Save(Services service);
        void Delete(int id);
        void DeleteAdditions(int id);
    }
}
