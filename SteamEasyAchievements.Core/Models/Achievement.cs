namespace SteamEasyAchievements.Core.Models
{
    internal class Achievement
    {
        //Properties
        public string Name { get; }
        public string Description { get; }
        public double Percentage { get; }

        //Constructor
        public Achievement(string name, string description, double percentage)
        {
            Name = name;
            Description = description;
            Percentage = percentage;
        }
    }
}