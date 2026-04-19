namespace ARPATicket.API.Models
{
    public enum Estado
    {
        Open,
        InProgress,
        Closed
    }
    public class Ticket
    {
        public int ticketID{ get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Estado status { get; set; }
        public string priority { get; set; }
        public int? assignedUserID { get; set; }
        public User? assignedUser { get; set; } = null;
    }
}
