using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;
using MongoDB.Driver;
using System.Net;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            DateTime now = DateTime.Now;
            ViewData["now"] = now.ToString("F");
            string hostName = Dns.GetHostName();
            ViewData["ip"] = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return View();
        }

        public IActionResult Index()
        {
            var client = new MongoClient("mongodb+srv://kaushik12:Password@cluster0.qwyhqzt.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("dbs1");
            var collection = database.GetCollection<entity>("entries");
            DateTime now = DateTime.Now;
            string date = now.ToString("F");
            string hostName = Dns.GetHostName();
            string ip = Dns.GetHostByName(hostName).AddressList[0].ToString();
            collection.InsertOne(
                new entity { 
                    Date = date,
                    Ip = ip
                    }
                );
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}