using ARPATicket.API.Models;

namespace ARPATicket.API.DTO
{
    public class TicketDTO
    {

        public int ticketID { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public Estado status { get; set; }
        public string priority { get; set; } = string.Empty;
        public int? assignedUserID { get; set; } 
        public User? assignedUser { get; set; } = null;
    }
}
