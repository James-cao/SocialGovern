using PDL.SocialGovern.Domain;
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
            return View(ss);
        }

        public ActionResult About()
        {
            var model = new UserInfo
            {
                Name = "cao1",
                Address = "zhangs"
            };

            userInfoService.AddGetUserInfo(model);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            userInfoService.DeleteUserInfo(1);
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}