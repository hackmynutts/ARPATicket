namespace ARPATicket.UI.Models
{
    public class TicketAddDTO
    {
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int? assignedUserID { get; set; }
        public UserDTO? user { get; set; } = null;
    }
}
