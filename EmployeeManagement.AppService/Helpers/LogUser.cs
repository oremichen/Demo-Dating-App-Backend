﻿using EmployeeManagement.AppService.UsersAppServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagement.Repository.UserRepository;
using System.Linq;

namespace EmployeeManagement.AppService.Helpers
{
    public class LogUser : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var claim = resultContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("nameid"));
            var id = claim.Value;
            var repo = resultContext.HttpContext.RequestServices.GetService<IUserRepo>();
            var user = await repo.GetUsersById(int.Parse(id));
            user.LastActive = DateTime.Now;
            await repo.UpdateUsers(user);
        }
    }
}
