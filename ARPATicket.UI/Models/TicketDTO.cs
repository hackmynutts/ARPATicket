namespace ARPATicket.UI.Models
{
    public class TicketDTO
    {        public int ticketID { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string priority { get; set; } = string.Empty;
        public int? assignedUserID { get; set; }
        public string? assignedUser { get; set; } = null;

    }
}
