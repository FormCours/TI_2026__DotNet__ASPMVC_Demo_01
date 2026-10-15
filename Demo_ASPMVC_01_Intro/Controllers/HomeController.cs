using Demo_ASPMVC_01_Intro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo_ASPMVC_01_Intro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("BienvenueSurLeSite")]
        // Sénario : Ancienne "route" redirigé vers "/home/welcome"
        public IActionResult BienvenueSurLeSite()
        {
            // Utilisation du "TempData" pour transmettre une info en resistant à la redirection
            TempData["OldRouting"] = true;

            // return RedirectToAction("Welcome")
            return RedirectToAction(nameof(Welcome));
        }

        public IActionResult Welcome()
        {
            // Utilisation du "ViewBag" pour transmettre l'info à la vu
            // → Utilisation du "ViewData" possible également
            ViewBag.Date = DateTime.Today.ToLongDateString();

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
