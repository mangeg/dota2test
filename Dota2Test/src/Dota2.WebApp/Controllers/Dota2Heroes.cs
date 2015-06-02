 // For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Dota2.WebApp.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNet.Mvc;
    using Model;
    using SteamService;
    using Hero = Model.Hero;

    [Route( "api/[controller]" )]
    public class Dota2Heroes : Controller
    {
        private readonly Dota2Db _db;
        private readonly IDotaService _dotaService;
        public Dota2Heroes( IDotaService dotaService, Dota2Db db )
        {
            _dotaService = dotaService;
            _db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            if ( !_db.Heroes.Any() )
            {
                var heroes = _dotaService.GetHeroes();
                foreach ( var hero in heroes )
                {
                    _db.Heroes.Add(
                        new Hero
                        {
                            Id = hero.Id,
                            Name = hero.Name,
                            LocalizedName = hero.LocalizedName
                        } );
                }
                _db.SaveChanges();
            }

            return _db.Heroes;
        }
    }
}
