using AutoMapper;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Enums;
using DataLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class OrdersService: IOrdersService
    {
        private IDataManager _dataManager;
        private IMapper _mapper;

        public OrdersService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public void Save(OrderDTO orderDTO, List<OrderAdditions> orderAdditions)
        {
            var order = _mapper.Map<Orders>(orderDTO);

            order.StatusId = (int)OrderStatusNames.New;

            _dataManager.OrdersRepository.Save(order, orderAdditions);
        }

        public void SaveAdditions(List<OrderAdditions> orderAdditions)
        {
            _dataManager.OrdersRepository.SaveAdditions(orderAdditions);
        }

        public OrderDTO GetById(int orderId)
        {
            return _mapper.Map<OrderDTO>(_dataManager.OrdersRepository.GetById(orderId));
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return _mapper.Map<List<OrderDTO>>(_dataManager.OrdersRepository.GetAll());
        }

        public IEnumerable<OrderDTO> GetByStatus(int statusId)
        {
            return _mapper.Map<List<OrderDTO>>(_dataManager.OrdersRepository.GetByStatus(statusId));
        }

        public IEnumerable<UserDTO> GetOrderEmployees(int orderId)
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_dataManager.OrdersRepository.GetOrderEmployees(orderId));
        }

        public void SetStatus(int orderId, int statusId)
        {
            _dataManager.OrdersRepository.SetStatus(orderId, statusId);
        }

        public void SetEmployeeOrder(int orderId, List<int> employeeIds)
        {
            var employeeOrders = new List<EmployeeOrders>();

            foreach (var employeeId in employeeIds) 
            {
                employeeOrders.Add(new EmployeeOrders() { OrderId = orderId, EmployeeId = employeeId});
            }

            _dataManager.OrdersRepository.SetEmployeeOrder(orderId, employeeOrders);
        }

        public void DeleteEmployeeOrder(int orderId, int userId)
        {
            _dataManager.OrdersRepository.DeleteEmployeeOrder(orderId, userId);
        }

        public IEnumerable<AdditionDTO> GetAdditions(int orderId)
        {
            return _mapper.Map<List<AdditionDTO>>(_dataManager.OrdersRepository.GetAdditions(orderId));
        }
    }
}
