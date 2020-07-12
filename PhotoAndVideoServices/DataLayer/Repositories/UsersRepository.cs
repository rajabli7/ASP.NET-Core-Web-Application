using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private PhotoAndVideoServicesContext _dbContext;

        public UsersRepository(PhotoAndVideoServicesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Users user)
        {
            if (user.Id == 0)
            {
                _dbContext.Users.Add(user);
            }
            else
            {
                _dbContext.Entry(user).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public Users GetById(int id)
        {
            return _dbContext.Users.AsNoTracking().FirstOrDefault(user => user.Id == id);
        }

        public Users CheckUser(string login)
        {
            var checkedUser = _dbContext.Users.AsNoTracking().FirstOrDefault(user => user.Phone == login);

            return checkedUser;
        }

        public bool IsAdministrator(int userId)
        {
            return _dbContext.Users.AsNoTracking().FirstOrDefault(user => user.Id == userId).RoleId == (int)RolesNames.Administrator;
        }

        public bool IsEmployee(int userId)
        {
            return _dbContext.Users.AsNoTracking().FirstOrDefault(user => user.Id == userId).RoleId == (int)RolesNames.Employee;
        }

        public bool IsClient(int userId)
        {
            return _dbContext.Users.AsNoTracking().FirstOrDefault(user => user.Id == userId).RoleId == (int)RolesNames.Client;
        }

        public int GetRoleId(int userId)
        {
            return (int)_dbContext.Users.AsNoTracking().FirstOrDefault(user => user.Id == userId).RoleId;
        }

        public List<Users> GetPosibleEmployees()
        {
            return _dbContext.Users.AsNoTracking()
                .Where(user => user.RoleId == (int)RolesNames.Employee && user.EmployeeOrders.Count < 5)
                .ToList();
        }

        public IEnumerable<Orders> GetOrdersForClient(int userId)
        {
            return _dbContext.Orders.AsNoTracking()
                .Where(order => order.UserId == userId)
                .Include(order => order.Service)
                .Include(order => order.User)
                .ToList();
        }

        public IEnumerable<Orders> GetOrdersForEmployee(int userId)
        {
            return _dbContext.EmployeeOrders.AsNoTracking()
                .Where(eo => eo.EmployeeId == userId)
                .Select(eo => eo.Order)
                .Include(order => order.Service)
                .Include(order => order.User)
                .ToList();
        }
    }
}
