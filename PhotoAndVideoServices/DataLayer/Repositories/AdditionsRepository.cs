using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class AdditionsRepository: IAdditionsRepository
    {
        private PhotoAndVideoServicesContext _dbContext;

        public AdditionsRepository(PhotoAndVideoServicesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Additions addition)
        {
            if (addition.Id == 0)
            {
                _dbContext.Additions.Add(addition);
            }
            else
            {
                _dbContext.Entry(addition).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public Additions GetById(int id)
        {
            return _dbContext.Additions.AsNoTracking().FirstOrDefault(addition => addition.Id == id);
        }

        public IEnumerable<Additions> GetAll()
        {
            return _dbContext.Additions.AsNoTracking().ToList();
        }
    }
}
