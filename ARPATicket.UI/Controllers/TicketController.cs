using ARPATicket.UI.Models;
using ARPATicket.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ARPATicket.UI.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketAPIServices _ticketAPIServices;
        private readonly IUserAPIServices _userAPIServices;

        public TicketController(ITicketAPIServices ticketAPIServices, IUserAPIServices userAPIServices)
        {
            _ticketAPIServices = ticketAPIServices;
            _userAPIServices = userAPIServices;
        }
        // GET: TicketController
        public async Task<ActionResult> Index()
        {
            var users = _userAPIServices.GetAllUsersAsync().Result;
            ViewBag.Users = users.ToDictionary(u => u.userID, u => u);
            var tickets = await _ticketAPIServices.GetAllTicketsAsync();
            return View(tickets);
        }

        // GET: TicketController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var users = await _userAPIServices.GetAllUsersAsync();
            ViewBag.Users = users.ToDictionary(u => u.userID, u => u.name);
            var ticket = await _ticketAPIServices.GetTicketByIDAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // GET: TicketController/Create
        public async Task<ActionResult> Create()
        {
            var users = await _userAPIServices.GetAllUsersAsync();
            ViewBag.Users = users.ToDictionary(u => u.userID, u => u);
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TicketAddDTO newTicket)
        {
            // Si assignedUserID es 0, convertir a null
            if (newTicket.assignedUserID == 0)
                newTicket.assignedUserID = null;

            if (ModelState.IsValid)
            {
                var createdTicket = await _ticketAPIServices.CreateTicketAsync(newTicket);
                if (createdTicket != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(newTicket);
        }

        // GET: Ticket/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var ticket = await _ticketAPIServices.GetTicketByIDAsync(id);
            if (ticket == null) return NotFound();
            var users = await _userAPIServices.GetAllUsersAsync();
            ViewBag.Users = users.ToDictionary(u => u.userID, u => u);
            var editDto = new TicketEditDTO
            {
                ticketID = ticket.ticketID,
                title = ticket.title,
                description = ticket.description,
                status = ticket.status,
                assignedUserID = ticket.assignedUserID
            };
            return View(editDto);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TicketEditDTO updatedTicket)
        {
            if (!ModelState.IsValid) return View(updatedTicket);

            var updated = await _ticketAPIServices.UpdateTicketAsync(updatedTicket);
            if (updated != null)
                return RedirectToAction(nameof(Index));

            return View(updatedTicket);
        }

        // GET: Ticket/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var ticket = await _ticketAPIServices.GetTicketByIDAsync(id);
            if (ticket == null) return NotFound();
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _ticketAPIServices.DeleteTicketAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}