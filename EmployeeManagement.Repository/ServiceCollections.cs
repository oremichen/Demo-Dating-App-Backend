using EmployeeManagement.Repository.RegisterRepository;
using EmployeeManagement.Repository.RoleRepository;
using EmployeeManagement.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Repository
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
            services.AddTransient<IRoleRepo, RoleRepo>();
            services.AddTransient<IRegistrationRepo, RegistrationRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            return services;
        }
    }
}
