namespace Dota2.SteamService
{
    public class SteamServiceOptions
    {
        public SteamServiceOptions()
        {
            Language = "en_us";
        }

        public string SteamApiKey { get; set; }
        public string Language { get; set; }
    }
}