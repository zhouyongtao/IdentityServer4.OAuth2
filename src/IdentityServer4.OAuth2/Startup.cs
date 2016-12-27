using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.OAuth2.Config;

namespace IdentityServer4.OAuth2
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                          .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = @"Data Source=.;Initial Catalog = IdentityServer4;Persist Security Info=True;User ID=sa;Password=123456";
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            //// configure identity server with in-memory users, but EF stores for clients and resources
            services.AddIdentityServer()
                    .AddInMemoryClients(Clients.GetClients())
                    .AddTestUsers(Users.GetUsers())
                    .AddInMemoryApiResources(Resources.GetApiResources())
                    .AddTemporarySigningCredential();


            //        .AddConfigurationStore(builder => builder.UseSqlServer(connectionString, options =>
            //                                          options.MigrationsAssembly(migrationsAssembly)))
            //        .AddOperationalStore(builder => builder.UseSqlServer(connectionString, options =>
            //                                         options.MigrationsAssembly(migrationsAssembly)));


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
