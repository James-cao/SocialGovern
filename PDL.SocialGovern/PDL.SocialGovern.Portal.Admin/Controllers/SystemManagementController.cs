using PDL.SocialGovern.Portal.Admin.ViewModels;
using PDL.SocialGovern.Service.Systems;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PDL.SocialGovern.Portal.Admin.Controllers
{
    public class SystemManagementController : BaseController
    {
        private readonly ISys_MenuService sysMenuService;

        public SystemManagementController(ISys_MenuService sysMenuService)
        {
            this.sysMenuService = sysMenuService;
        }

        // GET: SystemManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Frame()
        {
            ViewBag.Title = "大联动-系统管理";
            return View();
        }

        [HttpPost]
        public JsonResult GetSysMenus()
        {
            var sysMenus = sysMenuService.GetSysMenuByCatetory(0);
            List<Sys_MenuViewModel> list = new List<Sys_MenuViewModel>();

            foreach (var item in sysMenus.Where(p => p.FatherID == 0))
            {
                list.Add(new Sys_MenuViewModel
                {
                    FatherID = item.FatherID,
                    Icon = item.Icon,
                    ID = item.ID,
                    Name = item.Name,
                    Url = item.Url,
                    Children = (from p in sysMenus
                                where p.FatherID == item.ID
                                select new Sys_MenuViewModel
                                {
                                    FatherID = p.FatherID,
                                    Icon = p.Icon,
                                    ID = p.ID,
                                    Name = p.Name,
                                    Url = p.Url,
                                }).ToList()
                });

            }

            return Json(new
            {
                menus = list
            }, JsonRequestBehavior.AllowGet);
        }
    }
}