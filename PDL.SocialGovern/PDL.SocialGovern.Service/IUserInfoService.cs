using PDL.SocialGovern.Domain;
using System.Collections.Generic;

namespace PDL.SocialGovern.Service
{
    public interface IUserInfoService
    {

        IEnumerable<UserInfo> GetUserInfo();
        void AddGetUserInfo(UserInfo model);

        void UpdateGetUserInfo(UserInfo model);

        void DeleteUserInfo(long Id);
    }
}
