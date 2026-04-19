using ARPATicket.API.Models;

namespace ARPATicket.API.DTO
{
    public class TicketEditDTO
    {
        public int ticketID { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public Estado status { get; set; }
        public int? assignedUserID { get; set; }
    }
}
