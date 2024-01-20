namespace SheduleHubAPI.Contracts.ChatUser
{
    public class GetChatUserResponse
    {
        public int IdStudent { get; set; }
        public int IdChat { get; set; }
        public DateTime JoinAt { get; set; }
        public DateTime? RemoveAt { get; set; }
    }
}
