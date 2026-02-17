namespace Core.Domain.Models
{
    public class User
    {
        
        public enum State
        {
            Offline,
            Online,
            InGame,
        }
        
        public ulong UserId { get;}
        
        public State CurrentState { get; set; }
        
        public User(ulong userId)
        {
            UserId = userId;
        }

    }
}