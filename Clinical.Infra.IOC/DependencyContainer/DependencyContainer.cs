using Clinical.Application.Services.Implementations;
using Clinical.Application.Services.Interfaces;
using Clinical.Domain.Interfaces;
using Clinical.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical.Infra.IOC.DependencyContainer
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repository
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion
        }
    }
}
