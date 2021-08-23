using System;
using Library_System.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Library_System.Areas.Identity.IdentityHostingStartup))]
namespace Library_System.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Library_SystemIdentityDatabaseContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Library_SystemIdentityDatabaseContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<Library_SystemIdentityDatabaseContext>();
            });
        }
    }
}