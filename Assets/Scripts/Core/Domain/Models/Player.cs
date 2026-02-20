namespace Core.Domain.Models
{
    /// <summary>
    /// Domain model representing a player in the game.
    /// Contains pure business logic without Unity dependencies.
    /// </summary>
    public class Player
    {
        public enum Team
        {
            Team1,
            Team2
        }

        public ulong PlayerId { get; }
        public Team PlayerTeam { get; }
        public string PlayerName { get; set; }

        public Player(ulong playerId, Team playerTeam, string playerName = "Player")
        {
            PlayerId = playerId;
            PlayerTeam = playerTeam;
            PlayerName = playerName;
        }
    }
}

