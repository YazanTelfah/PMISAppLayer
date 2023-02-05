using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMISAppLayer.DTO;
using PMISAppLayer.Models;
using PMISBLayer.Data;
using PMISBLayer.Entities;
using PMISBLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer.Controllers
{
    public class HomeController : Controller

    {
        private readonly IMessageRepository messageRepository;
        private readonly ApplicationDbContext context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMessageRepository message1, ILogger<HomeController> logger, ApplicationDbContext context)
        {
            this.messageRepository = message1;
            _logger = logger;
            this.context = context;
        }




        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Manager()
        {
            return View();
        }
        public IActionResult Index()
        {
            ViewBag.Messages = messageRepository.GetAllMessages();

            return View();
        }
        
        public IActionResult NewMessage()
        {

            return View();
        }
        public IActionResult Createmessage(CreateMessageDTO messageDTO)
        {
            var message = new Message();
            message.MessageName = messageDTO.MessageName;
            message.MessageId = messageDTO.MessageId;
            message.MessageContact = messageDTO.MessageContact;
            message.MessageDescription = messageDTO.MessageDescription;
            messageRepository.InsertMessage(message);
            return RedirectToAction("Home");
        }
        public IActionResult DeleteMessage(int messageid)
        {

            messageRepository.Delete(messageid);
            return RedirectToAction("Index");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
