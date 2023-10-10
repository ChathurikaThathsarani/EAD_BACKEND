/*
 * File: TicketController.cs
 * Author: Dombepola D.A.C.T
 * Date: October 8, 2023
 * Description: This file defines the TicketController, which implements the controllers for ticket.
 * Reference: https://youtu.be/dsvL22_w88I?feature=shared
 */

using EAD_BACKEND.IServices;
using EAD_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAD_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        // Constructor to initialize the ticketService instance 
        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        // Controller for getting all the tickets
        [HttpGet]
        public ActionResult<List<Object>> GetTicketsController()
        {
            return ticketService.GetTickets();
        }

        // Controller for getting ticket by its ID
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicketByIDController(string id)
        {
            var available = ticketService.GetTicketByID(id);

            if (available == null)
            {
                return NotFound($"Ticket cannot be found");
            }

            return available;
        }

        // Controller for getting tickets by the user id
        [HttpGet("user/{id}")]
        public ActionResult<List<Ticket>> GetTicketByUserIDController(string id)
        {
            var available = ticketService.GetTicketByUser(id);

            if (available == null)
            {
                return NotFound($"Tickets cannot be found");
            }

            return available;
        }

        // Controller for creating a ticket
        [HttpPost]
        public ActionResult CreateTicketController([FromBody] Ticket ticket)
        {
            var available = ticketService.CreateTicket(ticket);

            if (available == -1)
            {
                return NotFound($"Ticket is exist");
            }
            else
            {
                return Ok($"Ticket is successfully created");
            }
        }

        // Controller for updating a ticket
        [HttpPut("{id}")]
        public ActionResult UpdateTicketController(string id, [FromBody] Ticket ticket)
        {

            var available = ticketService.GetTicketByID(id);

            if (available == null)
            {
                return NotFound($"Ticket cannot be found");
            }

            ticketService.UpdateTicket(id, ticket);

            return Ok($"Ticket is successfully updated");

        }

        // Controller for deleting a ticket
        [HttpDelete("{id}")]
        public ActionResult DeleteTicketController(string id)
        {
            var available = ticketService.GetTicketByID(id);

            if (available == null)
            {
                return NotFound($"Ticket cannot be found");
            }

            ticketService.RemoveTicket(available.Id);

            return Ok($"Ticket is successfully deleted");
        }

    }
}
