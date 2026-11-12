namespace Axis.Api.Events
{
    public class UserCreatedEventArgs
    {
        public int UserId { get; set; }

        public string Type { get; set; }
        public UserCreatedEventArgs(int userId, string type)
        {
            UserId = userId;
            Type = type; 
        }
    }
}
