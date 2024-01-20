namespace SheduleHubAPI.Contracts.ChatUser
{
    public class CreateChatUserRequest
    {
        public int IdStudent { get; set; }
        public int IdChat { get; set; }
        public DateTime JoinAt { get; set; }
    }
}
