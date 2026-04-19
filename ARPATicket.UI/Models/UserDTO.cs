namespace ARPATicket.UI.Models
{
    public class UserDTO
    {
        public int userID { get; set; }
        public string name { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int AvatarID { get; set; } = 0;
    }
}
