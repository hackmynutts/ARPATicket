namespace ARPATicket.UI.Models
{
    public class TicketEditDTO
    {
        public int ticketID { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string status { get; set; }
        public int? assignedUserID { get; set; }
        public string? user { get; set; } = null;
    }
}
