namespace Dota2.WebApp.Controllers
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.Framework.OptionsModel;
    using SteamService;

    public class HomeController : Controller
    {
        private readonly IDotaService _dotaService;
        public HomeController( IDotaService dotaService )
        {
            _dotaService = dotaService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var heroes = _dotaService.GetHeroes();
            return View( heroes );
        }
    }
}
