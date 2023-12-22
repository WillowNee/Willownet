using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Willownet.BL.Resume;
using Willownet.Models;

namespace Willownet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResume resume;

        public HomeController(IResume resume)
        {
            this.resume = resume;
        }

        public async Task<IActionResult> Index()
        {
            var latestResumes = await resume.Search(4);
            return View(latestResumes);
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
