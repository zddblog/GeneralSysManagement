using General.Entities.GeneralModels;
using General.NetCore.Data;
using General.Services.General.EntityServices;
using General.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace General.Web.Controllers
{
    public class HomeController : Controller
    {
        // private readonly IRepository<Category> _repository;
        //   private readonly ICategoryService _categoryService;
        public HomeController(ICategoryService categoryService)
        {
            // this._repository = repository;
            //  this._categoryService = categoryService;
        }

        public IActionResult Index()
        {
            // _categoryService.Add(new Category { });
            //_repository.Add(new Category { Name = "6666", SysResource = "6666", FatherResource = "666" });
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
