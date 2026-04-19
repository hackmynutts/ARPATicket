using ARPATicket.API.Data;
using ARPATicket.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ARPATicket.API.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        //listar todos los tickets
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets.AsNoTracking().ToListAsync();
        }

        //obtener ticket por id
        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.AsNoTracking().FirstOrDefaultAsync(t => t.ticketID == id);
        }

        //crear ticket
        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        //actualizar ticket
        public async Task<Ticket?> UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        //eliminar ticket
        public async Task<bool> DeleteTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return false;
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
