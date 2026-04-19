namespace ARPATicket.API.Models
{
    public class User
    {
        public int userID { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int AvatarID { get; set; } = 0;
    }
}
