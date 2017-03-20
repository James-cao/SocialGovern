using PDL.SocialGovern.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDL.SocialGovern.Domain
{
    public class UserInfo
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
