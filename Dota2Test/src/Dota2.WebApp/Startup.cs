﻿namespace Dota2.WebApp
{
    using Microsoft.AspNet.Authorization;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Diagnostics;
    using Microsoft.AspNet.Diagnostics.Entity;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Data.Entity;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;
    using Model;
    using Newtonsoft.Json.Serialization;
    using SteamService;

    public class Startup
    {
        public Startup( IHostingEnvironment env )
        {
            var configuration = new Configuration()
                .AddJsonFile( "config.json" )
                .AddJsonFile( $"config.{env.EnvironmentName}.json", true );

            if ( env.IsEnvironment( "Development" ) )
            {
                configuration.AddUserSecrets();
            }

            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc().Configure<MvcOptions>( o => {
                var formatter = o.OutputFormatters.InstanceOf<JsonOutputFormatter>();
                formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            } );

            services.Configure<SiteOptions>( Configuration.GetSubKey( "AppSettings" ) );
            services.Configure<SteamServiceOptions>( Configuration.GetSubKey( "AppSettings" ) );
            services.AddSingleton( s => Configuration );
            services.AddTransient<IDotaService, DotaService>();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<Dota2Db>(
                    d => { d.UseSqlServer( Configuration["Data:DefaultConnection:ConnectionString"] ); } );
        }
        public void Configure( IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory )
        {
            loggerfactory.AddConsole( LogLevel.Information );

            if ( env.IsEnvironment( "Development" ) )
            {
                app.UseBrowserLink();
                app.UseErrorPage( ErrorPageOptions.ShowAll );
                app.UseDatabaseErrorPage( DatabaseErrorPageOptions.ShowAll );
            }
            else
            {
                app.UseErrorHandler( "/Home/Error" );
            }

            app.UseStaticFiles();

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        "default",
                        "{controller}/{action}/{id?}",
                        new { controller = "Home", action = "Index" } );
                } );
        }
    }
}
