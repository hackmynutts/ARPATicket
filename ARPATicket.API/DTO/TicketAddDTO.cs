using ARPATicket.API.Models;

namespace ARPATicket.API.DTO
{
    public class TicketAddDTO
    {
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int? assignedUserID { get; set; }

    }
}
