using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StudentRegistration.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(ILogger<PublisherController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Publisher p1 = new() {Id = 1, Name = "KEC", Address = "Jawalakhel",Phone = 1234567890};
            Publisher p2 = new() {Id = 2, Name = "Asmita", Address = "Lagankhel",Phone = 1234567890};
            List<Publisher> publishers = [p1,p2];
            return View(publishers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}