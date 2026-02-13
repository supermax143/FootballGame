namespace Core.Domain.Models
{
    public class User
    {
        public ulong UserId { get;}

        public User(ulong userId)
        {
            UserId = userId;
        }

        
    }
}