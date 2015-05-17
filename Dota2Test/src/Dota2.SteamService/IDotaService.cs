namespace Dota2.SteamService
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IDotaService
    {
        IEnumerable<Hero> GetHeroes();
    }
}