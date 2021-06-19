using EmployeeManagement.Repository.RegisterRepository;
using EmployeeManagement.Repository.RoleRepository;
using EmployeeManagement.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Repository
{
    public static class ServiceCollections
    {
        public static void AddRepoServices(this IServiceCollection services)
        {
            services.RegisterAssemblyPublicNonGenericClasses()
          .AsPublicImplementedInterfaces();
        }
    }
}
