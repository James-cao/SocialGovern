using System;
using System.Collections.Generic;
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

        public void AddGetUserInfo(UserInfo model)
        {
            userInfoRepository.Insert(model);
        }

        public void DeleteUserInfo(long Id)
        {
            var entity = userInfoRepository.Get(Id);
            if (entity == null) throw new Exception("未找到删除对象");

            userInfoRepository.Delete(entity);
        }

        public IEnumerable<UserInfo> GetUserInfo()
        {
            
            return userInfoRepository.GetList();
        }

        public void UpdateGetUserInfo(UserInfo model)
        {
            userInfoRepository.Update(model);
        }
    }
}
