using Latihan1.DAO;
using Latihan1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace Latihan1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.Id = "2";
            dy.Name = "Joni";
            dy.Description = "Good";

            List<MemberModel> list = new List<MemberModel>
            {
                new MemberModel {
                    Id = 1,
                    Name = "Andi",
                    Description = "Good"
                },
                new MemberModel
                {
                    Id = 2,
                    Name = "Joni",
                    Description = "Good"
                }
            };

            List<string> arrStr = new List<string> { 
                "A","B","C"
            };
            
            ResponseModel res = new ResponseModel();
            res.Status = "Ok";
            res.Message = "Success";
            res.Description = "Success";
            res.Data = arrStr;

            ViewData["sub_title"] = "Ini Halaman Home"; //hanya untuk tipe data string selain itu akan diubah ke string
            ViewBag.data = list;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}