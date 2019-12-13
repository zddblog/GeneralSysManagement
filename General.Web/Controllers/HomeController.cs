using General.Entities.GeneralModels;
using General.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace General.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoreContext _coreContext;

        public HomeController(CoreContext coreContext)
        {
          
            this._coreContext = coreContext;
        }

        public IActionResult Index()
        {
            var sss = _coreContext.Category.ToList();
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
