using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDL.SocialGovern.Portal.Admin.ViewModels
{
    public class Sys_MenuViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int FatherID { get; set; }

        public List<Sys_MenuViewModel> Children { get; set; }
    }
}