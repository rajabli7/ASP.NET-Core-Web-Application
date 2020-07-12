using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private PhotoAndVideoServicesContext _dbContext;

        public OrdersRepository(PhotoAndVideoServicesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Orders GetById(int id)
        {
            Orders order = _dbContext.Orders.AsNoTracking()
                            .Include(o => o.User)
                            .Include(o => o.Service)
                            .FirstOrDefault(o => o.Id == id);

            return order;
        }

        public IEnumerable<Orders> GetAll()
        {
            return _dbContext.Orders.AsNoTracking().
              Include(order => order.User).
              Include(order => order.Service).ToList();
        }

        public IEnumerable<Orders> GetByStatus(int statusId)
        {
            if(statusId > 4)
            {
                return GetAll();
            }

            return _dbContext.Orders.AsNoTracking()
                .Where(order => order.StatusId == statusId)
                .Include(order => order.User)
                .Include(order => order.Service).ToList();
        }

        public void Save(Orders order, List<OrderAdditions> orderAdditions)
        {
            _dbContext.Orders.Add(order);

            foreach (var orderAddition in orderAdditions)
            {
                orderAddition.OrderId = order.Id;
            }

            _dbContext.OrderAdditions.AddRange(orderAdditions);

            _dbContext.SaveChanges();
        }

        public void SaveAdditions(List<OrderAdditions> orderAdditions)
        {
            _dbContext.OrderAdditions.AddRange(orderAdditions);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Users> GetOrderEmployees(int orderId)
        {
            var employeeOrders = _dbContext.EmployeeOrders.AsNoTracking().Include(eo => eo.Employee).Where(eo => eo.OrderId == orderId).ToList();
            if (employeeOrders == null)
                return null;
            return employeeOrders.Select(eo => eo.Employee);
        }

        public void SetStatus(int orderId, int statusId)
        {
            var order = _dbContext.Orders.AsNoTracking().FirstOrDefault(o => o.Id == orderId);

            order.StatusId = statusId;

            _dbContext.Orders.Update(order);

            _dbContext.SaveChanges();
        }

        public void SetEmployeeOrder(int orderId, List<EmployeeOrders> employeeOrders)
        {
            var oldEmployeeOrders = _dbContext.EmployeeOrders.AsNoTracking()
                .Where(eo => eo.OrderId == orderId).ToList();

            _dbContext.EmployeeOrders.RemoveRange(oldEmployeeOrders);

            _dbContext.AddRange(employeeOrders);

            _dbContext.SaveChanges();
        }

        public void DeleteEmployeeOrder(int orderId, int userId)
        {
            var employeeOrder = _dbContext.EmployeeOrders.AsNoTracking().FirstOrDefault(eo => eo.OrderId == orderId && eo.EmployeeId == userId);

            _dbContext.EmployeeOrders.Remove(employeeOrder);
            
            _dbContext.SaveChanges();
        }

        public IEnumerable<Additions> GetAdditions(int orderId)
        {
            return _dbContext.OrderAdditions.AsNoTracking().Where(oa => oa.OrderId == orderId).Select(oa => oa.Addition).ToList();
        }
    }
}
