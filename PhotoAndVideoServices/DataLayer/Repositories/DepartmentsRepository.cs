using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class DepartmentsRepository: IDepartmentsRepository
    {
        private PhotoAndVideoServicesContext _dbContext;

        public DepartmentsRepository(PhotoAndVideoServicesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Departments> GetAll()
        {
            return _dbContext.Departments.AsNoTracking().Include(department => department.DepartmentInfomations).ToList();
        }
    }
}
