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

        public IActionResult Calc(Calc calculator)
        {
            switch (calculator.Operation)
            {
                case Operation.Addition:
                    calculator.Accumulate += calculator.Reduce;
                    break;
                case Operation.Subtraction:
                    calculator.Accumulate -= calculator.Reduce;
                    break;
                case Operation.Multiplication:
                    calculator.Accumulate *= calculator.Reduce;
                    break;
                case Operation.Division:
                    if (calculator.Reduce != 0)
                    {
                        calculator.Accumulate /= calculator.Reduce;
                    }
                    break;
                default:
                    break;
            }

            ViewBag.Result = calculator.Accumulate;
            return View();
        }


        public IActionResult Birthday(Birthday birthday)
        {
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