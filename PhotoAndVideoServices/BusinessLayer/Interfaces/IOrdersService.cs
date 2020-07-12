using BusinessLayer.DataTransferObjects;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrdersService
    {
        OrderDTO GetById(int orderId);
        IEnumerable<OrderDTO> GetAll();
        void SetStatus(int orderId, int statusId);
        void SetEmployeeOrder(int orderId, List<int> employeeIds);
        IEnumerable<UserDTO> GetOrderEmployees(int orderId);
        void DeleteEmployeeOrder(int orderId, int userId);
        IEnumerable<AdditionDTO> GetAdditions(int orderId);
        void Save(OrderDTO orderDTO, List<OrderAdditions> orderAdditions);
        void SaveAdditions(List<OrderAdditions> orderAdditions);
        IEnumerable<OrderDTO> GetByStatus(int statusId);
    }
}
