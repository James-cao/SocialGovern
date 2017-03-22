using PDL.SocialGovern.Domain.Systems;
using PDL.SocialGovern.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDL.SocialGovern.Infrastructure;

namespace PDL.SocialGovern.Repositories.Systems
{
    public class Sys_MenuRepository : DapperRepository<Sys_Menu>, ISys_MenuRepository
    {
        public Sys_MenuRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}
