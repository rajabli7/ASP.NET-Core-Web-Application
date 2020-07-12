using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class ServiceRepository: IServicesRepository
    {
        private PhotoAndVideoServicesContext _dbContext;

        public ServiceRepository(PhotoAndVideoServicesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Services GetById(int id)
        {
            return _dbContext.Services.FirstOrDefault(service => service.Id == id);
        }

        public void Save(Services service)
        {
            if (service.Id == 0)
            {
                _dbContext.Services.Add(service);
            }
            else
            {
                _dbContext.Entry(service).State = EntityState.Modified;
                
                _dbContext.ServiceAdditions.AddRange(service.ServiceAdditions);
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var service = _dbContext.Services.FirstOrDefault(s => s.Id == id);
            _dbContext.Services.Remove(service);
            _dbContext.SaveChanges();
        }

        public void DeleteAdditions(int id)
        {
            var serviceAdditions = _dbContext.ServiceAdditions.AsNoTracking().Where(sAddition => sAddition.ServiceId == id).ToList();

            _dbContext.ServiceAdditions.RemoveRange(serviceAdditions);

            _dbContext.SaveChanges();
        }

        public IEnumerable<Additions> GetAdditions(int serviceId)
        {
            return _dbContext.ServiceAdditions
                .Where(serviceAdditions => serviceAdditions.ServiceId == serviceId)
                .Include(serviceAdditions => serviceAdditions.Addition)
                .Select(serviceAdditions => serviceAdditions.Addition).ToList();
        }
    }
}
