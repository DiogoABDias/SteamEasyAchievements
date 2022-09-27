using HtmlAgilityPack;
using System.Net;
using System.Web;

namespace SteamEasyAchievements.Core.Models
{
    internal class Game
    {
        //Properties
        internal int AppId { get; }

        internal string? Name { get; }

        internal List<Achievement> AchievementList { get; private set; }

        //Constructor
        public Game(int appId = default, string? name = default)
        {
            AppId = appId;
            Name = name;
            AchievementList = new();
        }

        //Methods
        internal void LoadAchievements()
        {
            Uri uri = new("https://steamcommunity.com");

            using HttpClientHandler handler = new();
            handler.CookieContainer = new();
            handler.CookieContainer.Add(uri, new Cookie("birthtime", HttpUtility.UrlEncode("birthtime=0; path=/; max-age=315360000")));

            HttpClient httpClient = new(handler);
            string response;

            using HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"{uri.OriginalString}/stats/{AppId}/achievements").Result;
            using HttpContent content = httpResponseMessage.Content;
            response = content.ReadAsStringAsync().Result;

            //The html dlc area was not found
            if (!response.Contains("gameAreaDLCSection"))
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

            HtmlNode dlcBrowse = htmlDoc.DocumentNode.SelectSingleNode("//span[contains(@class, 'note')]");

            //The node selection found no results
            if (dlcBrowse is null)
            {
                return;
            }

            HtmlNodeCollection achievementList = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'game_area_dlc_row')]");

            //The node selection found no results
            if (achievementList is null || achievementList.Count == 0)
            {
                return;
            }

            //AchievementList = new();

            //foreach (HtmlNode node in achievementList)
            //{
            //    HtmlNode priceNode = node.SelectSingleNode("./div[@class='game_area_dlc_price']");

            //    Achievement achievement = new();
            //    AchievementList.Add(achievement);
            //}
        }
    }
}