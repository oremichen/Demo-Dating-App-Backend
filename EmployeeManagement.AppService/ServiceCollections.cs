using EmployeeManagement.AppService.RegistrationAppService;
using EmployeeManagement.AppService.RolesAppServices;
using EmployeeManagement.AppService.TokenService;
using EmployeeManagement.AppService.UsersAppServices;
using EmployeeManagement.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.AppService
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddAppServiceCollection(this IServiceCollection services)
        {
            services.AddTransient<IRolesAppService, RolesAppService>();
            services.AddTransient<IRegistrationAppServices, RegistrationAppServices>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddScoped<ITokenServices, TokenServices>();
            return services;
        }
    }
}
