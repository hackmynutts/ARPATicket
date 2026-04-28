using ARPATicket.API.DTO;
using ARPATicket.API.Services;
using ARPATicket.API.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ARPATicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketServices _ticketServices;

        public TicketController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        // GET: api/Ticket   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _ticketServices.GetAllTickets();
            return Ok(tickets);
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await _ticketServices.GetTicketById(id);
            return ticket is not null ? Ok(ticket) : NotFound();
        }

        // POST: api/Ticket
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketAddDTO newTicket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ICommand<TicketDTO> command = new CommandAddTicket(_ticketServices, newTicket);
            var createdTicket = await command.Execute();
            return CreatedAtAction(nameof(GetById),
                new { id = createdTicket.ticketID }, createdTicket);
        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TicketEditDTO updatedTicket)
        {
            if (id != updatedTicket.ticketID)
                return BadRequest("ID no coincide");
            ICommand<TicketDTO?> command = new CommandEditTicket(_ticketServices, updatedTicket);
            var result = await command.Execute();
            return result is not null ? Ok(result) : NotFound();
        }

        // DELETE: api/Ticket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ICommand<bool> command = new CommandDeleteTicket(_ticketServices, id);
            var deleted = await command.Execute();
            return deleted ? NoContent() : NotFound();
        }
    }
}