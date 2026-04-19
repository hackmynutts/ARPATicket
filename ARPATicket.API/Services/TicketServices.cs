using ARPATicket.API.DTO;
using ARPATicket.API.Models;
using ARPATicket.API.Repository;

namespace ARPATicket.API.Services
{
    public class TicketServices : ITicketServices
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly PriorityService _priorityService;

        public TicketServices(ITicketRepository ticketRepository, PriorityService priorityService)
        {
            _ticketRepository = ticketRepository;
            _priorityService = priorityService;
        }

        //lista de tickets
        public async Task<List<TicketDTO>> GetAllTickets()
        {
            var tickets = await _ticketRepository.GetAllTicketsAsync();
            return tickets.Select(t => new TicketDTO
            {
                ticketID = t.ticketID,
                title = t.title,
                description = t.description,
                status = t.status,
                priority = t.priority,
                assignedUserID = t.assignedUserID,
                assignedUser = t.assignedUser
            }).ToList();
        }

        // Obtener un ticket por ID
        public async Task<TicketDTO?> GetTicketById(int id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id);
            if (ticket == null) return null;
            return new TicketDTO
            {
                ticketID = ticket.ticketID,
                title = ticket.title,
                description = ticket.description,
                status = ticket.status,
                priority = ticket.priority,
                assignedUserID = ticket.assignedUserID,
                assignedUser = ticket.assignedUser
            };
        }

        // Agregar un nuevo ticket
        public async Task<TicketDTO> AddTicket(TicketAddDTO newTicket)
        {
            var priority = await _priorityService.GetPriorityAsync(newTicket.description); // se usa
            var ticket = new Ticket
            {
                title = newTicket.title,
                description = newTicket.description,
                status = Estado.Open,
                priority = priority, // se asigna la prioridad evaluada
                assignedUserID = newTicket.assignedUserID
            };
            var addedTicket = await _ticketRepository.CreateTicketAsync(ticket);
            return new TicketDTO
            {
                ticketID = addedTicket.ticketID,
                title = addedTicket.title,
                description = addedTicket.description,
                status = addedTicket.status,
                priority = addedTicket.priority,
                assignedUserID = addedTicket.assignedUserID,
                assignedUser = addedTicket.assignedUser
            };
        }

        // Actualizar un ticket existente
        public async Task<TicketDTO?> UpdateTicket(TicketEditDTO updatedTicket)
        {
            var existingTicket = await _ticketRepository.GetTicketByIdAsync(updatedTicket.ticketID);
            if (existingTicket == null) return null;
            existingTicket.title = updatedTicket.title;
            existingTicket.description = updatedTicket.description;
            existingTicket.status = updatedTicket.status;
            existingTicket.assignedUserID = updatedTicket.assignedUserID;
            var priority = await _priorityService.GetPriorityAsync(updatedTicket.description); // se reevaluá la prioridad
            existingTicket.priority = priority; // se actualiza la prioridad
            var updated = await _ticketRepository.UpdateTicketAsync(existingTicket);

            if (updated == null) return null; // en caso de que la actualización falle por alguna razón
            return new TicketDTO
            {
                ticketID = updated.ticketID,
                title = updated.title,
                description = updated.description,
                status = updated.status,
                priority = updated.priority,
                assignedUserID = updated.assignedUserID,
                assignedUser = updated.assignedUser
            };
        }

        // Eliminar un ticket
        public async Task<bool> DeleteTicket(int id)
        {
            return await _ticketRepository.DeleteTicketAsync(id);
        }
    }
}
