using PDL.SocialGovern.Domain.Systems;
using System.Collections.Generic;

namespace PDL.SocialGovern.Service.Systems
{
    public interface ISys_MenuService
    {
        IEnumerable<Sys_Menu> GetSysMenuByCatetory(int menuCatetory);
    }
}