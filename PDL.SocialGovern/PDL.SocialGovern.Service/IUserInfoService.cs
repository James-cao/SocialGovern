using PDL.SocialGovern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDL.SocialGovern.Service
{
    public interface IUserInfoService
    {

        IEnumerable<UserInfo> GetUserInfo();
    }
}
