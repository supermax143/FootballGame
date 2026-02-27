namespace Core.Domain.Models
{
   
    public class Player
    {

        public ulong Id { get; }
        public string PlayerName { get; }
        public int TeamIndex { get;}

        public Player(ulong id, string playerName, int teamIndex)
        {
            Id = id;
            TeamIndex = teamIndex;
            PlayerName = playerName;
        }

    }
}

