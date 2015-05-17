namespace Dota2.WebApp
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Diagnostics;
    using Microsoft.AspNet.Diagnostics.Entity;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;

    public class Startup
    {
        public Startup( IHostingEnvironment env )
        {
            var configuration = new Configuration()
                .AddJsonFile( "config.json" )
                .AddJsonFile( $"config.{env.EnvironmentName}.json", optional: true );

            configuration.AddEnvironmentVariables();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc();
        }
        public void Configure( IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory )
        {
            loggerfactory.AddConsole( LogLevel.Verbose );

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
