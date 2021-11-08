using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Helpers;
using WebApp.Models;

namespace WebApp.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OTPCheck(OTPViewModel model)
        {
            return View("Submit",model);
        }
        public IActionResult Submit(OTPViewModel model)
        {
            if (model.OneTimePasswordFromUser == model.OneTimePasswordGenerated)
            {
                return View("LoggedIn", model);
            }

            return RedirectToAction("Index","Home");
        }

        public IActionResult LoggedIn(OTPViewModel model)
        {
            return View();
        }
        public IActionResult SendMail(OTPViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.OneTimePasswordGenerated = Helper.GenerateOneTimePassword();
                Helper.SendMail(model.Email, model.OneTimePasswordGenerated);
                return View("OTPCheck",model);
            }

            return RedirectToAction("Index","Home");
        }
    }
}
