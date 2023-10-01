using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Calculators(Calculators calculator){
            
            if(calculator.Equation == "sum"){
                calculator.Accumulate += calculator.Reduce;  
            }
            if(calculator.Equation == "sub"){
                calculator.Accumulate -= calculator.Reduce;
            }

            if(calculator.Equation == "multiply"){
                calculator.Accumulate *= calculator.Reduce;
            }

            ViewBag.Result = calculator.Accumulate;
            return View();
        }

        public IActionResult Birthday(Birthday birthday){
            ViewBag.WelcomeMessage = $"Witaj {birthday.Name}, masz {DateTime.Now.Year - birthday.Year} lat";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Name = "Anna";
            ViewBag.CurrentHour = DateTime.Now.Hour;
            ViewBag.WelcomeMessage = ViewBag.CurrentHour < 17 ? "Dzień dobry" : "Dobry wieczór";
            
            Dane[] people =
            {
                new Dane {Name = "Anna", Surname="Kowalska"},
                new Dane {Name = "Jan", Surname="Kowalski"},
                new Dane {Name = "Mateusz", Surname="Kowalski"}

            };
            
            return View(people);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}