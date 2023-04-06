using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TastApp.Models;
using TestNewWebApp.Models;

namespace TestNewWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoProcessor _todoProcessor;

        public HomeController(ILogger<HomeController> logger, ITodoProcessor todoProcessor)
        {
            _logger = logger;
            this._todoProcessor = todoProcessor; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Todo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTodo(TodoViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}