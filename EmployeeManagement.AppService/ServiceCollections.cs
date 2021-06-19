using EmployeeManagement.AppService.RegistrationAppService;
using EmployeeManagement.AppService.RolesAppServices;
using EmployeeManagement.AppService.TokenService;
using EmployeeManagement.AppService.UsersAppServices;
using EmployeeManagement.Core;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.AppService
{
    public static class ServiceCollections
    {
        public static void AddAppServiceCollection(this IServiceCollection services)
        {
            services.RegisterAssemblyPublicNonGenericClasses()
           .AsPublicImplementedInterfaces();
        }
    }
}
