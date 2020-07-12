using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Enums;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PhotoAndVideoServices.Classes;
using PhotoAndVideoServices.Extensions;
using PhotoAndVideoServices.Models;

namespace PhotoAndVideoServices.Controllers
{
    public class PhotogalleryController : Controller
    {
        private IServiceManager _serviceManager;
        private IMapper _mapper;

        public PhotogalleryController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            return View();
        }


        public IActionResult Login()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            return View();
        }

        public IActionResult Registration()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            return View();
        }

        [HttpPost]
        public void Login(string login, string password)
        {
            var user = _serviceManager.UsersService.CheckUser(login);

            if (user == null)
            {
                throw new Exception();
            }
        
            if(!SecurePasswordHasher.Verify(password, user.Password))
            {
                throw new Exception();
            }

            HttpContext.SetCurrentUserIdToCookie(user.Id, (int)user.RoleId);
        }

        public IActionResult SuccessfulRegistration()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            return View();
        }

        public IActionResult AboutUs()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.CurrentUser = HttpContext.GetCurrentUserFromCookie();

            var departments = _mapper.Map<List<DepartmentPM>>(_serviceManager
                .DepartmentsService.GetAll());

            return View(departments);
        }

        [HttpPost]
        public void SendMessage(string header, string name, string surname, string mail, string message)
        {
            var smtpMessage = new MimeMessage();

            smtpMessage.From.Add(new MailboxAddress("Photogallery", "photogallery.smtp@gmail.com"));
            smtpMessage.To.Add(new MailboxAddress("eradjabli7@gmail.com"));
            smtpMessage.Subject = "Сообщение по услуге " + header;

            string body = $"Отправитель <i>{surname} {name}</i><br/>" +
                $"Cообщение: <br /> {message} <br/>" +
                $"Почта отправителя: <i>{mail}</i>";
            smtpMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("photogallery.smtp@gmail.com", "photogallery2019");

                client.Send(smtpMessage);

                client.Disconnect(true);
            }
        }
    }
}
