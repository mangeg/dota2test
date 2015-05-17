namespace Dota2.SteamService
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Microsoft.Framework.OptionsModel;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class DotaService : IDotaService
    {
        private readonly IOptions<SteamServiceOptions> _opts;
        private readonly Uri _baseAddress = new Uri( "https://api.steampowered.com/" );
        public DotaService( IOptions<SteamServiceOptions> opts  )
        {
            _opts = opts;
        }

        public IEnumerable<Hero> GetHeroes()
        {
            var ret = new List<Hero>();

            var client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var requestString = $"IEconDOTA2_570/GetHeroes/v1?key={_opts.Options.SteamApiKey}&language={_opts.Options.Language}";
            var request = new HttpRequestMessage( HttpMethod.Get, requestString );

            var result = client.SendAsync( request ).Result;
            if ( !result.IsSuccessStatusCode )
                return ret;

            var resultString = result.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse( resultString );

            foreach ( var child in json["result"]["heroes"].Children() )
            {
                var name = child["name"].Value<string>();
                var id = child["id"].Value<int>();
                var fullName = child["localized_name"].Value<string>();

                var hero = new Hero() {
                    Id = id,
                    LocalizedName = fullName,
                    Name = name
                };

                ret.Add( hero );
            }
            

            return ret;
        }
    }
}