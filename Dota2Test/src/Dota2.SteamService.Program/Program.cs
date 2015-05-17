namespace Dota2.SteamService.Program
{
    using System;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.OptionsModel;
    using Microsoft.Framework.Runtime;

    public class Program
    {
        private IServiceProvider _serviceProvider;

        public Program( IServiceProvider serviceProvider )
        {
            _serviceProvider = serviceProvider;
        }

        public void Main( string[] args )
        {
            var services = new ServiceCollection();
            var manifest = _serviceProvider.GetService<IServiceManifest>();
            if ( manifest != null )
            {
                foreach ( var service in manifest.Services )
                {
                    services.AddTransient( service, sp => _serviceProvider.GetService( service ) );
                }
            }

            var config = new Configuration()
                .AddJsonFile( "config.json" )
                .AddUserSecrets();

            services.AddOptions();
            services.Configure<SteamServiceOptions>( config.GetSubKey( "SteamService" ) );
            services.AddTransient<IDotaService, DotaService>();
            services.AddSingleton( s => config );

            _serviceProvider = services.BuildServiceProvider();

            var dotaService = ( IDotaService)_serviceProvider.GetService( typeof( IDotaService ) );

            var heroes = dotaService.GetHeroes();
        }
    }
}
