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
    public class CorporateServicesController : Controller
    {
        private IServiceManager _serviceManager;
        private IMapper _mapper;

        public CorporateServicesController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCorporateServices()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var corporateServices = _mapper.Map<ServiceTypePM>(_serviceManager.ServiceTypesService.GetWithServices((int)ServiceTypeNames.Corporate));

            return View(corporateServices);
        }

        public IActionResult MakeOrder()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var order = new OrderPM();

            ViewBag.Services = _mapper.Map<List<ServicePM>>(_serviceManager.ServiceTypesService.GetServices((int)ServiceTypeNames.Corporate));

            return View(order);
        }
    }
}