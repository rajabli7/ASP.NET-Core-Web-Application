using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Interfaces;
using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using PhotoAndVideoServices.Classes;
using PhotoAndVideoServices.Extensions;
using PhotoAndVideoServices.Models;

namespace PhotoAndVideoServices.Controllers
{
    public class UsersController: Controller
    {
        private IServiceManager _serviceManager;
        private IMapper _mapper;

        public UsersController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void SaveUser(UserPM userPM)
        {
            var password = userPM.Password;
            userPM.Password = SecurePasswordHasher.Hash(userPM.Password);
            userPM.RoleId = 3;

            var userDTO = _mapper.Map<UserDTO>(userPM);
            _serviceManager.UsersService.Save(userDTO);
            HttpContext.SetCurrentUserIdToCookie(userPM.Id, (int)userDTO.RoleId);
        }
    }
}