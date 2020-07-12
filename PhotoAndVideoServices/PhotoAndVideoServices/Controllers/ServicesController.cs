using AutoMapper;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAndVideoServices.Enums;
using PhotoAndVideoServices.Extensions;
using PhotoAndVideoServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhotoAndVideoServices.Controllers
{
    public class ServicesController : Controller
    {
        private IServiceManager _serviceManager;
        private IMapper _mapper;

        public ServicesController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var serviceTypes = _mapper.Map<List<ServiceTypePM>>(_serviceManager.ServiceTypesService.GetAll());

            ViewBag.Additions = _mapper.Map<IEnumerable<AdditionPM>>(_serviceManager.AdditionsService.GetAll());

            return View(serviceTypes);
        }

        public IActionResult ShowAdditionsForServiceType(int serviceTypeId)
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var additionPMs = _mapper.Map<List<AdditionPM>>(_serviceManager.ServicesService.GetAdditions(serviceTypeId));

            return PartialView("_ServiceTypeAdditionsPartial", additionPMs);
        }

        public IActionResult CreateServiceAddition()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            return View();
        }

        public IActionResult Show(int id)
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var servicePM = _mapper.Map<ServicePM>(_serviceManager.ServicesService.GetById(id));

            servicePM.ServiceTypeName = _serviceManager.ServiceTypesService.GetById(servicePM.ServiceTypeId).Name;

            ViewBag.ServiceTypeAdditions = _serviceManager.ServicesService.GetAdditions(id);

            return View(servicePM);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var servicePM = _mapper.Map<ServicePM>(_serviceManager.ServicesService.GetById(id));

            var additions = _mapper.Map<IEnumerable<AdditionPM>>(_serviceManager.AdditionsService.GetAll());

            var serviceAdditions = _serviceManager.ServicesService.GetAdditions(id);

            foreach (var addition in additions)
            {
                addition.Checked = serviceAdditions.Any(serviceAddition => serviceAddition.Id == addition.Id);
            }

            ViewBag.Additions = additions;

            return View(servicePM);
        }

        [HttpPost]
        public void Edit(ServicePM servicePM, List<int> additionIds)
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();
            var userName = _serviceManager.UsersService.GetById(currentUser.UserId).Name;

            var serviceDTO = _mapper.Map<ServiceDTO>(servicePM);

            serviceDTO.ServiceAdditions = new List<ServiceAdditions>();

            foreach (var additionId in additionIds)
            {
                serviceDTO.ServiceAdditions.Add(new ServiceAdditions() { ServiceId = serviceDTO.Id, AdditionId = additionId });
            }

            _serviceManager.ServicesService.DeleteAdditions(serviceDTO.Id);

            _serviceManager.ServicesService.Save(serviceDTO);
        }


        public IActionResult Create(int serviceTypeId)
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var servicePM = new ServicePM() { ServiceTypeId = serviceTypeId };

            var additions = _mapper.Map<IEnumerable<AdditionPM>>(_serviceManager.AdditionsService.GetAll());

            ViewBag.Additions = additions;

            return View(servicePM);
        }

        [HttpPost]
        public void Create(ServicePM servicePM, List<int> additionIds)
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();
            var userName = _serviceManager.UsersService.GetById(currentUser.UserId).Name;

            var serviceDTO = _mapper.Map<ServiceDTO>(servicePM);

            serviceDTO.ServiceAdditions = new List<ServiceAdditions>();

            foreach (var additionId in additionIds)
            {
                serviceDTO.ServiceAdditions.Add(new ServiceAdditions() { AdditionId = additionId });
            }

            _serviceManager.ServicesService.Save(serviceDTO);
        }

        public void Delete(int id)
        {
            var currentUser = HttpContext.GetCurrentUserFromCookie();
            var userName = _serviceManager.UsersService.GetById(currentUser.UserId).Name;

            _serviceManager.ServicesService.Delete(id);
        }
    }
}