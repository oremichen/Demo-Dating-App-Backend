using EmployeeManagement.AppService.UsersAppServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagement.Repository.UserRepository;
using System.Linq;
using System.Security.Claims;

namespace EmployeeManagement.AppService.Helpers
{
    public class LogUser : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var id = resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var repo = resultContext.HttpContext.RequestServices.GetService<IUserRepo>();
            var user = await repo.GetUsersById(int.Parse(id));
            user.LastActive = DateTime.Now;
            await repo.UpdateUsers(user);
        }
    }
}
