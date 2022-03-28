using System;
using BasicCrudOperations.Areas.Identity.Data;
using BasicCrudOperations.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BasicCrudOperations.Areas.Identity.IdentityHostingStartup))]
namespace BasicCrudOperations.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddAuthentication().AddGoogle(options=> 
                {
                    options.ClientId = context.Configuration["App:GoogleClientId"];
                    options.ClientSecret = context.Configuration["App:GoogleClientSecret"];
                
                }).AddFacebook();

                services.AddDbContext<BasicCrudOperationsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BasicCrudOperationsContextConnection")));


                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
    
                }) 
                    .AddEntityFrameworkStores<BasicCrudOperationsContext>();
            });
        }
    }
}