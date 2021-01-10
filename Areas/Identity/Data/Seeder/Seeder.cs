using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blog.Areas.Identity.Data.Seeder
{
    public class Seeder
    {
        public static  void Run(IServiceProvider serviceProvider)
        {
            RoleSeeder.Initialize(serviceProvider);
        }
    }
}