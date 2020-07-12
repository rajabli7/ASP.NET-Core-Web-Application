using AutoMapper;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using PhotoAndVideoServices.Extensions;
using PhotoAndVideoServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhotoAndVideoServices.Controllers
{
    public class OrdersController : Controller
    {
        private IServiceManager _serviceManager;
        private IMapper _mapper;

        public OrdersController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public void SetOrderStatus(OrderPM order)
        {
            switch (order.StatusId)
            {
                case (int)OrderStatusNames.New: order.StatusName = "Новый"; break;
                case (int)OrderStatusNames.Rejected: order.StatusName = "Отклонен"; break;
                case (int)OrderStatusNames.Done: order.StatusName = "Выполнен"; break;
                case (int)OrderStatusNames.InProgress: order.StatusName = "Выполняется"; break;
            }
        }

        public IActionResult Index()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            return View();
        }

        [HttpPost]
        public IActionResult MakeOrder(OrderPM orderPM, List<int> additionIds)
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();
            var userName = _serviceManager.UsersService.GetById(currentUser.UserId).Name;

            orderPM.UserId = currentUser.UserId;

            var orderAdditions = new List<OrderAdditions>();

            foreach(var additionId in additionIds)
            {
                orderAdditions.Add(new OrderAdditions() { AdditionId = additionId });
            }

            _serviceManager.OrdersService.Save(_mapper.Map<OrderDTO>(orderPM), orderAdditions);
           
            return Redirect("ShowClientOrders");
        }

        [HttpPost]
        public IActionResult SaveOrderAdditions(int orderId, List<int> additionIds)
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();
            var userName = _serviceManager.UsersService.GetById(currentUser.UserId).Name;

            var orderAdditions = new List<OrderAdditions>();

            foreach (var additionId in additionIds)
            {
                orderAdditions.Add(new OrderAdditions() { OrderId = orderId, AdditionId = additionId });
            }

            _serviceManager.OrdersService.SaveAdditions(orderAdditions);

            return Redirect($"ShowClientOrder?orderId={orderId}");
        }

        public IActionResult ShowOrders()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var orderPMs = _mapper.Map<List<OrderPM>>(_serviceManager.OrdersService.GetAll());

            foreach (var order in orderPMs)
            {
                SetOrderStatus(order);
            }

            return View(orderPMs);
        }

        public IActionResult ShowSortedOrders(int statusId)
        {
            var orderPMs = _mapper.Map<List<OrderPM>>(_serviceManager.OrdersService.GetByStatus(statusId));

            foreach (var order in orderPMs)
            {
                SetOrderStatus(order);
            }

            return PartialView("_ShowOrders", orderPMs);
        }

        public IActionResult ShowOrder(int orderId)
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var orderPM = _mapper.Map<OrderPM>(_serviceManager.OrdersService.GetById(orderId));

            SetOrderStatus(orderPM);

            orderPM.Employees = _mapper.Map<List<UserPM>>(_serviceManager.OrdersService.GetOrderEmployees(orderId));
            orderPM.Additions = _mapper.Map<List<AdditionPM>>(_serviceManager.OrdersService.GetAdditions(orderPM.Id));

            ViewBag.Employees = _mapper.Map<List<UserPM>>(_serviceManager.UsersService.GetPosibleEmployes());

            return View(orderPM);
        }

        [HttpPost]
        public IActionResult SetOrderStatus(int orderId, int statusId)
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();
            var userName = _serviceManager.UsersService.GetById(currentUser.UserId).Name;

            _serviceManager.OrdersService.SetStatus(orderId, statusId);

            return Redirect($"ShowOrder?orderId={orderId}");
        }

        [HttpPost]
        public IActionResult SetEmployeeOrders(int orderId, List<int> checkedEmployees)
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();
            var userName = _serviceManager.UsersService.GetById(currentUser.UserId).Name;

            _serviceManager.OrdersService.SetEmployeeOrder(orderId, checkedEmployees);

            return Redirect($"ShowOrder?orderId={orderId}");
        }

        public IActionResult ShowEmployeeOrders()
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();

            var orderPMs = _mapper.Map<List<OrderPM>>(_serviceManager.UsersService.GetOrdersForEmployee(currentUser.UserId));

            foreach (var order in orderPMs)
            {
                SetOrderStatus(order);
            }

            ViewBag.CurrentUser = currentUser;

            return View(orderPMs);
        }

        public IActionResult ShowEmployeeOrder(int orderId)
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var orderPM = _mapper.Map<OrderPM>(_serviceManager.OrdersService.GetById(orderId));

            SetOrderStatus(orderPM);

            orderPM.Employees = _mapper.Map<List<UserPM>>(_serviceManager.OrdersService.GetOrderEmployees(orderId));

            return View(orderPM);
        }

        public IActionResult ShowClientOrders()
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();

            var orderPMs = _mapper.Map<List<OrderPM>>(_serviceManager.UsersService.GetOrdersForClient(currentUser.UserId));

            foreach (var order in orderPMs)
            {
                SetOrderStatus(order);
            }

            ViewBag.CurrentUser = currentUser;

            return View(orderPMs);
        }

        public IActionResult ShowClientOrder(int orderId)
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var orderPM = _mapper.Map<OrderPM>(_serviceManager.OrdersService.GetById(orderId));

            SetOrderStatus(orderPM);

            orderPM.Additions = _mapper.Map<List<AdditionPM>>(_serviceManager.OrdersService.GetAdditions(orderPM.Id));
            orderPM.Employees = _mapper.Map<List<UserPM>>(_serviceManager.OrdersService.GetOrderEmployees(orderId));

            var serviceAdditions = _mapper.Map<List<AdditionPM>>(_serviceManager.ServicesService.GetAdditions(orderPM.ServiceId));
            ViewBag.ServiceAdditions = serviceAdditions;

            var posibleAdditionals = serviceAdditions.Except(orderPM.Additions).ToList();

            return View(orderPM);
        }

        public IActionResult DeleteEmployeeOrder(int orderId)
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();

            _serviceManager.OrdersService.DeleteEmployeeOrder(orderId, currentUser.UserId);

            return Redirect("ShowEmployeeOrders");
        }
    }
}