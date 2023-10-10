/*
 * File: TicketService.cs
 * Author: Dombepola D.A.C.T
 * Date: October 8, 2023
 * Description: This file defines the TicketService class, which implements the ITicketService interface.
 * Reference: https://youtu.be/dsvL22_w88I?feature=shared
 */

using EAD_BACKEND.IServices;
using EAD_BACKEND.Models;
using EAD_BACKEND.Interfaces;
using MongoDB.Driver;
using EAD_BACKEND.Implementations;

namespace EAD_BACKEND.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMongoCollection<Ticket> _ticketObj;
        UserService userService;

        // Constructor to initialize the MongoDB collection
        public TicketService(ITicketDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _ticketObj = database.GetCollection<Ticket>(settings.TicketCollectionName);
            var userDBSettings = new UserDBSettings
            {
                DatabaseName = "EAD_DB",
                UserCollectionName = "users",
               
            };
            var mongoClientForUser = new MongoClient("mongodb://localhost:27017/EAD_DB");
            userService = new UserService(userDBSettings, mongoClientForUser);
        }

        // Method for creating a new ticket
        public int CreateTicket(Ticket ticket)
        {
            try
            {
                _ticketObj.InsertOne(ticket);
                return 1;
            }
            catch (MongoWriteException)
            {
                return -1;
            }
        }

        // Method for retrieve all tickets from the database
        public List<Object> GetTickets()
        {
            var ticketData = _ticketObj.Find(_ => true).ToList();
            var ticketsWithUserNIC = new List<object>();

            foreach (var ticket in ticketData)
            {
                var user = userService.GetUserByID(ticket.UserId);
                if (user != null)
                {
                    var ticketWithUserNIC = new
                    {
                        id = ticket.Id,
                        trainId = ticket.TrainId,
                        dateTime = ticket.DateTime,
                        start = ticket.Start,
                        end = ticket.End,
                        price = ticket.Price,
                        noOfTicket = ticket.NoOfTicket,
                        userId = ticket.UserId,
                        total = ticket.Total,
                        nic = user.Nic
                    };

                    ticketsWithUserNIC.Add(ticketWithUserNIC);
                }
            }

            return ticketsWithUserNIC;
        }

        // Method for retrieving tickets by user ID from the database
        public List<Ticket> GetTicketByUser(string userId)
        {
            return _ticketObj.Find(ticket => ticket.UserId == userId).ToList();
        }

        // Method for retrieving a ticket by its ID from the database
        public Ticket GetTicketByID(string ticketID)
        {
            return _ticketObj.Find(ticket => ticket.Id == ticketID).FirstOrDefault();
        }

        // Method for removing a ticket from the database by its ID
        public void RemoveTicket(string tickcetID)
        {
            _ticketObj.DeleteOne(ticket => ticket.Id == tickcetID);
        }

        // Method for updating a ticket in the database by its ID
        public void UpdateTicket(string ticketId, Ticket ticket)
        {
            _ticketObj.ReplaceOne(ticket => ticket.Id == ticketId, ticket);
        }
    }
}
