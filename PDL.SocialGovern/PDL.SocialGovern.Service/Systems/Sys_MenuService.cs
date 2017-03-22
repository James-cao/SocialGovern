using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDL.SocialGovern.Domain.Systems;
using PDL.SocialGovern.Repositories.Systems;

namespace PDL.SocialGovern.Service.Systems
{
    public class Sys_MenuService : ISys_MenuService
    {
        private readonly ISys_MenuRepository sysMenuRepo;

        public Sys_MenuService(ISys_MenuRepository sysMenuRepo)
        {
            this.sysMenuRepo = sysMenuRepo;
        }

        public IEnumerable<Sys_Menu> GetSysMenuByCatetory(int menuCatetory)
        {
            return sysMenuRepo.Query("SELECT * FROM SYS_MENU WHERE MENUCATEGORY =@menuCatetory", new { menuCatetory = menuCatetory });
        }
    }
}
