using PDL.SocialGovern.Domain;
using PDL.SocialGovern.Infrastructure.Repository;
using PDL.SocialGovern.Repositories.Interfaces;
using PDL.SocialGovern.Infrastructure;

namespace PDL.SocialGovern.Repositories
{
    public class UserInfoRepository : DapperRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
