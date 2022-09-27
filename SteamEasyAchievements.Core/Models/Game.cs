using HtmlAgilityPack;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace SteamEasyAchievements.Core.Models
{
    internal class Game
    {
        //Properties
        internal int AppId { get; }

        internal string? Name { get; }

        internal List<Achievement> Achievements { get; private set; }

        //Constructor
        public Game(int appId = default, string? name = default)
        {
            AppId = appId;
            Name = name;
            Achievements = new();
        }

        //Methods
        internal void LoadAchievements(string sessionId, string steamLoginSecure)
        {
            Uri uri = new("https://steamcommunity.com");

            using HttpClientHandler handler = new();
            handler.CookieContainer = new();
            handler.CookieContainer.Add(uri, new Cookie("birthtime", HttpUtility.UrlEncode("birthtime=0; path=/; max-age=315360000")));
            handler.CookieContainer.Add(uri, new Cookie("sessionid", sessionId));
            handler.CookieContainer.Add(uri, new Cookie("steamLoginSecure", steamLoginSecure));

            HttpClient httpClient = new(handler);
            string response;

            using HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"{uri.OriginalString}/stats/{AppId}/achievements").Result;
            using HttpContent content = httpResponseMessage.Content;
            response = content.ReadAsStringAsync().Result;

            //The html dlc area was not found
            if (response.Contains("error_ctn"))
            {
                return;
            }

            //No achievements have been unlocked
            if (!response.Contains("achieveRow unlocked"))
            {
                return;
            }

            //All achievements have been unlocked
            if (!response.Contains("<div class=\"achieveRow \">"))
            {
                return;
            }

            HtmlDocument htmlDoc = new();
            htmlDoc.LoadHtml(response);

            //The html parse failed
            if (htmlDoc.DocumentNode is null)
            {
                return;
            }

            HtmlNodeCollection achievementList = htmlDoc.DocumentNode.SelectNodes("//div[@class='achieveRow ']");
            Achievements = new();

            foreach (HtmlNode node in achievementList)
            {
                string name = WebUtility.HtmlDecode(node.SelectSingleNode(".//h3").InnerText.Trim());
                string description = WebUtility.HtmlDecode(node.SelectSingleNode(".//h5").InnerText.Trim());
                string percentage = WebUtility.HtmlDecode(node.SelectSingleNode(".//div[@class='achievePercent']").InnerText.Trim());
                percentage = percentage.Replace("%", "");

                Achievements.Add(new(name, description, Convert.ToDouble(percentage)));
            }
        }
    }
}