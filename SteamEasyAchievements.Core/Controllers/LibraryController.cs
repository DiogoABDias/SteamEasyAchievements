using SteamEasyAchievements.Core.Models;
using SteamEasyAchievements.Core.ViewModels;

namespace SteamEasyAchievements.Core.Controllers
{
    public class LibraryController
    {
        //Fields
        private static Library? _library;

        //Methods
        internal static void Login(string steamApiKey, string sessionId, string steamLoginSecure)
        {
            try
            {
                _library = new(SteamProfileController.GetSteamId());
                _library.LoadDynamicStore(sessionId, steamLoginSecure);
                _library.LoadGames(steamApiKey);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }

        internal static void Logout()
        {
            _library = null;
        }

        internal static bool DynamicStoreIsFilled()
        {
            bool result = false;

            if (_library is null)
            {
                return result;
            }

            if (_library.DynamicStore is null)
            {
                return result;
            }

            try
            {
                result = _library.DynamicStore.Any();
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }

            return result;
        }

        internal static bool GamesIsFilled()
        {
            bool result = false;

            if (_library is null)
            {
                return result;
            }

            if (_library.Games is null)
            {
                return result;
            }

            try
            {
                result = _library.Games.Any();
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }

            return result;
        }

        public static void Calculate(string steamApiKey, string sessionId, string steamLoginSecure)
        {
            if (_library is null)
            {
                return;
            }

            try
            {
                _library.LoadDynamicStore(sessionId, steamLoginSecure);
                _library.LoadGames(steamApiKey);

                _library.LoadGamesAchievements(sessionId, steamLoginSecure);

                if (_library.Games is null)
                {
                    return;
                }

                List<int> gamesToRemove = new();

                foreach (Game game in _library.Games)
                {
                    //Mark to remove games without dlc
                    if (game.Achievements is null || game.Achievements.Count == 0)
                    {
                        gamesToRemove.Add(game.AppId);
                        continue;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }
        }

        public static List<AchievementView> GetAchievements()
        {
            List<AchievementView> result = new();

            if (_library is null)
            {
                return result;
            }

            if (_library.Games is null)
            {
                return result;
            }

            try
            {
                foreach (Game game in _library.Games)
                {
                    foreach (Achievement achievement in game.Achievements)
                    {
                        AchievementView achievementDto = new()
                        {
                            Name = achievement.Name,
                            Description = achievement.Description,
                            Percentage = achievement.Percentage,
                            AppId = game.AppId
                        };

                        result.Add(achievementDto);
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }

            result = result.OrderByDescending(x => x.Percentage).ToList();

            return result;
        }

        internal static string GetGameName(int appId)
        {
            string result = string.Empty;

            if (_library is null)
            {
                return result;
            }

            if (_library.Games is null)
            {
                return result;
            }

            if (!_library.Games.Any(x => x.AppId == appId))
            {
                return result;
            }

            try
            {
                Game game = _library.Games.First(x => x.AppId == appId);
                result = game.Name ?? result;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }

            return result;
        }

        public static int GetLibrarySize()
        {
            int result = 0;

            if (_library is null)
            {
                return result;
            }

            if (_library.Games is null)
            {
                return result;
            }

            try
            {
                result = _library.Games.Count;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception);
            }

            return result;
        }
    }
}