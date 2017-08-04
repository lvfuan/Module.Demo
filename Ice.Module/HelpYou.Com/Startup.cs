using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HelpYou.Com.DB.Context;
using HelpYou.Com.DB.Interface;
using HelpYou.Com.DB.Server;
using Autofac;

namespace HelpYou.Com
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        #region Autofac 注入   ContainerBuilder未找到到Populate()方法，暂时不启用
        //public IContainer ApplicationContainer { get; private set; }
        //public void IServiceProvider(IServiceCollection services)
        //{
        //    // Add framework services.
        //    services.AddDbContext<HelpYouDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("HelpYouDbContext")));
        //    var builder = new ContainerBuilder();
        //    builder.RegisterType<MenuServer>().As<IMenu>();
        //    builder.Populate(services);
        //    this.ApplicationContainer = builder.Build();
        //    services.AddMvc();
        //}
        #endregion
        #region NetCore 自带注入
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<HelpYouDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("HelpYouDbContext")));

            #region  注入 (netCore自带注入
            services.AddSingleton<ICustom, CustomServer>();
            services.AddSingleton<IMenu, MenuServer>();
            #endregion

            services.AddMvc();
        }
        #endregion
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, HelpYouDbContext context)
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

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Custom}/{action=SignIn}/{id?}");
            });
            HelpYouDBInit.Initialize(context);
        }
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        //    loggerFactory.AddDebug();

        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseBrowserLink();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //    }

        //    app.UseStaticFiles();

        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(
        //            name: "default",
        //            template: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
    }
}
