using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class ServiceTypesRepository : IServiceTypesRepository
    {
        private PhotoAndVideoServicesContext _dbContext;

        public ServiceTypesRepository(PhotoAndVideoServicesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceTypes GetById(int id)
        {
            return _dbContext.ServiceTypes.AsNoTracking().FirstOrDefault(st => st.Id == id);
        }

        public IEnumerable<ServiceTypes> GetAll()
        {
            return _dbContext.ServiceTypes.AsNoTracking().ToList();
        }

        public ServiceTypes GetWithServices(int id)
        {
            return _dbContext.ServiceTypes.AsNoTracking()
                .Include(serviceType => serviceType.Services)
                .FirstOrDefault(serviceTypes => serviceTypes.Id == id);
        }

        public IEnumerable<Services> GetServices(int id)
        {
            return _dbContext.Services.AsNoTracking().Where(service => service.ServiceTypeId == id);
        }
    }
}
