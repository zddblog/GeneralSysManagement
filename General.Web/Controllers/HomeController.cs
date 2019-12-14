using General.Entities.GeneralModels;
using General.NetCore.Data;
using General.NetCore.Librs;
using General.Services.General.EntityServices;
using General.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace General.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<SysUser> _repository;
        public HomeController(IRepository<SysUser> repository)
        {
            this._repository = repository;
        }

        public IActionResult Index()
        {
            // _categoryService.Add(new Category { });
            // _categoryService.Add(new Category { Name = "6666", SysResource = "6666", FatherResource = "666" });
           // _repository.Add(new SysUser { Name="aaaaa",Account="aaaa",Password="44444"});
            return View();
        }

        [HttpPost]
        public IActionResult Login(SysUser sysUser) {
            SysUser s = new SysUser();
            var list = _repository.GetList();
            foreach (var item in list)
            {
                if (sysUser.Account.Equals(item.Account))
                {
                    s = item;
                    break;
                }
            }
            if (sysUser!=null)
            {
                var ret =   EncryptorHelper.GetMd532(string.Format("{0}{1}", sysUser.Password, s.Salt));
                if (ret.Equals(s.Password))
                {

                }
                else { 
                }
            }
            return Json("");

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
