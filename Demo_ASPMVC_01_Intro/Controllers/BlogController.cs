using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPMVC_01_Intro.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article(string slug)
        {
            Console.WriteLine(slug);

            ViewData["CAFÉ! (╯°□°）╯︵ ┻━┻"] = slug;

            return View();
        }
    }
}
