using PDL.SocialGovern.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDL.SocialGovern.Portal.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserInfoService userInfoService;
        public HomeController(IUserInfoService userInfoService)
        {
            this.userInfoService = userInfoService;
        }
        public ActionResult Index()
        {
           var ss =  userInfoService.GetUserInfo().ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}