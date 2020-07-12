using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IOrdersRepository
    {
        void Save(Orders order, List<OrderAdditions> orderAdditions);
        Orders GetById(int id);
        IEnumerable<Orders> GetAll();
        void SetStatus(int orderId, int statusId);
        void SetEmployeeOrder(int orderId, List<EmployeeOrders> employeeOrders);
        IEnumerable<Users> GetOrderEmployees(int orderId);
        void DeleteEmployeeOrder(int orderId, int userId);
        IEnumerable<Additions> GetAdditions(int orderId);
        void SaveAdditions(List<OrderAdditions> orderAdditions);
        IEnumerable<Orders> GetByStatus(int statusId);
    }
}
