using Autofac;
using PDL.SocialGovern.Domain;
using PDL.SocialGovern.Infrastructure;
using PDL.SocialGovern.Repositories;
using PDL.SocialGovern.Repositories.Interfaces;
using PDL.SocialGovern.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDL.SocialGovern.Test
{
    public class Program
    {
        private static IContainer container { get; set; }
        private static IUserInfoService userInfoService;
        static void Main(string[] args)
        {
            Register();

            //Add();
            //Delete();
            //Update();
            Query();


        }

        private static void Query()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var userInfoRepo = scope.Resolve<IUserInfoRepository>();
               // var users = userInfoRepo.Query("select * from UserInfo where Id =@Id", new { Id = 2 });
                int total;
                var userlist = userInfoRepo.GetListPaged(1, 10, "where ID<1000", "ID", out total).ToList();
                //foreach (var item in users)
                //{
                //    Console.WriteLine("Id={0}，Name={1}，Address={2}", item.Id, item.Name, item.Address);
                //}
            }


        }

        private static void Update()
        {

        }

        private static void Delete()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var userInfoService = scope.Resolve<IUserInfoService>();
                userInfoService.DeleteUserInfo(3);
                Console.WriteLine("删除成功。");
            }
        }

        private static void Add()
        {
            for (int i = 0; i < 10; i++)
            {
                var user = new UserInfo
                {
                    Name = "James" + i,
                    Address = "成都" + i
                };

                using (var scope = container.BeginLifetimeScope())
                {
                    userInfoService = scope.Resolve<IUserInfoService>();
                    userInfoService.AddGetUserInfo(user);
                    Console.WriteLine("Insert into success:{0}", i);
                }

            }
        }

        static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>();

            builder.RegisterAssemblyTypes(typeof(UserInfoRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(UserInfoService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .AsImplementedInterfaces();
            container = builder.Build();
        }
    }
}
