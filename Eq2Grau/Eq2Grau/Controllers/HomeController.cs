using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eq2Grau.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int a, int b, int c)
        {
            double delta = b * b - 4 * a * c;
            string x1 = "", x2 = "";
            //posso calcular as minhas raízes?
            if(a != 0)
            {
                if(delta >= 0) 
                {
                    x1 = ((-b + Math.Sqrt(delta)) / (2 * a)).ToString();
                    x2 = ((-b - Math.Sqrt(delta)) / (2 * a)).ToString();
                }
                else
                {
                    x1 = ((-b / (2 * a) + Math.Sqrt(Math.Abs(delta))) / (2 * a)).ToString() + "i";
                    x2 = ((-b / (2 * a) - Math.Sqrt(Math.Abs(delta))) / (2 * a)).ToString() + "i";
                }

            }

            //preparar os dados para enviar para a vista
            ViewBag.x1 = x1;
            ViewBag.x2 = x2;

            return View();
        }

        

        public IActionResult Privacy()
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