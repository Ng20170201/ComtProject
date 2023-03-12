using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using RepositoriesInterfaces;
using Service.BackgroundServices;
using Service.EmailServices;
using ServiceReference1;
using ServicesInterfaces;
using Utils.Handlers;

namespace Service.DependencyInjections
{
    public static class ServicesInjections
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
            {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICampaignService, CampaignService>();

            services.AddScoped<SOAPDemoSoap, SOAPDemoSoapClient>();
            services.AddSingleton<BackgroundService, CampaignBackgroundService>();
            services.AddHostedService<CampaignBackgroundService>();

            services.AddScoped<IEmailServiceCSV, EmailServiceCSV>();
            services.AddSingleton<JWTGenerator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();

            return services;

            }
    }
}
