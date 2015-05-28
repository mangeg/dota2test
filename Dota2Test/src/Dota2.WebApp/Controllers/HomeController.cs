namespace Dota2.WebApp.Controllers
{
    using System.Linq;
    using Microsoft.AspNet.Mvc;
    using Model;
    using SteamService;
    using Hero = Model.Hero;

    public class HomeController : Controller
    {
        private readonly Dota2Db _db;
        private readonly IDotaService _dotaService;
        public HomeController( IDotaService dotaService, Dota2Db db )
        {
            _dotaService = dotaService;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            if ( !_db.Heroes.Any() )
            {
                var heroes = _dotaService.GetHeroes();
                foreach ( var hero in heroes )
                {
                    _db.Heroes.Add(
                        new Hero {
                            Id = hero.Id,
                            Name = hero.Name,
                            LocalizedName = hero.LocalizedName
                        } );
                }
                _db.SaveChanges();
            }
            return View( _db.Heroes.ToList() );
        }
    }
}
