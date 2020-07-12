using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using PhotoAndVideoServices.Models;
using PhotoAndVideoServices.Enums;
using PhotoAndVideoServices.Classes;
using PhotoAndVideoServices.Extensions;
using DataLayer.Enums;

namespace PhotoAndVideoServices.Controllers
{
    public class WeddingServicesController : Controller
    {
        private IServiceManager _serviceManager;
        private IMapper _mapper;

        public WeddingServicesController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowWeddingServices()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var weddingServices = _mapper.Map<ServiceTypePM>(_serviceManager.ServiceTypesService.GetWithServices((int)ServiceTypeNames.Wedding));

            return View(weddingServices);
        }

        public IActionResult MakeOrder()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var order = new OrderPM();

            ViewBag.Services = _mapper.Map<List<ServicePM>>(_serviceManager.ServiceTypesService.GetServices((int)ServicesNames.WEDDING_SERVICES));

            return View(order);
        }
    }
}