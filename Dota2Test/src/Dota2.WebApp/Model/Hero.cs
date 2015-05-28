namespace Dota2.WebApp.Model
{
    using System.Text.RegularExpressions;

    public class Hero
    {
        private static readonly Regex ImageNameRegex = new Regex( "npc_dota_hero_", RegexOptions.IgnoreCase );

        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string ImageName => ImageNameRegex.Replace( Name, string.Empty );
        public string ImagePathSmallHorizontalPortrait => $"http://cdn.dota2.com/apps/dota2/images/heroes/{ImageName}_sb.png";
        public string ImagePathLargeHorizontalPortrait => $"http://cdn.dota2.com/apps/dota2/images/heroes/{ImageName}_lg.png";
        public string ImagePathFullHorizontalPortrait => $"http://cdn.dota2.com/apps/dota2/images/heroes/{ImageName}_full.png";
        public string ImagePathFullVerticalPortrait => $"http://cdn.dota2.com/apps/dota2/images/heroes/{ImageName}_vert.jpg";
    }
}
