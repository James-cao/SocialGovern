using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDL.SocialGovern.Domain;
using PDL.SocialGovern.Repositories.Interfaces;

namespace PDL.SocialGovern.Service
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository userInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            this.userInfoRepository = userInfoRepository;
        }

        public IEnumerable<UserInfo> GetUserInfo()
        {
            userInfoRepository.GetList();
            return null;
        }
    }
}
