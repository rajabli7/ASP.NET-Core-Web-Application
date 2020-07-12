using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using PhotoAndVideoServices.Classes;
using PhotoAndVideoServices.Enums;
using PhotoAndVideoServices.Extensions;
using PhotoAndVideoServices.Models;

namespace PhotoAndVideoServices.Controllers
{
    public class SpecialEventServicesController : Controller
    {
        private IServiceManager _serviceManager;
        private IMapper _mapper;

        public SpecialEventServicesController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            return View();
        }

        public IActionResult ShowSpecialEventServices()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var specialEventServices = _mapper.Map<ServiceTypePM>(_serviceManager.ServiceTypesService.GetWithServices((int)ServiceTypeNames.SpecialEvent));

            return View(specialEventServices);
        }

        public IActionResult MakeOrder()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var order = new OrderPM();

            ViewBag.Services = _mapper.Map<List<ServicePM>>(_serviceManager.ServiceTypesService.GetServices((int)ServicesNames.SPECIAL_EVENT_SERVICES));

            return View(order);
        }
    }
}