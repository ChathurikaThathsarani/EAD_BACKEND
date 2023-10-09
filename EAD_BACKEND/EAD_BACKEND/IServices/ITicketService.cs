/*
 * File: ITicketService.cs
 * Author: Dombepola D.A.C.T
 * Date: October 8, 2023
 * Description: This file defines the ITicketService interface, which represents the service contract for managing tickets.
 * Reference: 
 */

using EAD_BACKEND.Models;
namespace EAD_BACKEND.IServices
{
    public interface ITicketService
    {
        List<Ticket> GetTickets();
        List<Ticket> GetTicketByUser(string user_id);
        Ticket GetTicketByID(string id);
        int CreateTicket(Ticket ticket);
        void UpdateTicket(string id, Ticket ticket);
        void RemoveTicket(string id);
    }
}
