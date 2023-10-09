/*
 * File: TicketDBSettings.cs
 * Author: Dombepola D.A.C.T
 * Date: October 8, 2023
 * Description: This file defines the TicketDBSettings class, which represents the implemenattion for the ITicketDBSettings interface.
 * Reference: 
 */

using EAD_BACKEND.Interfaces;
namespace EAD_BACKEND.Implementations
{
    public class TicketDBSettings : ITicketDBSettings
    {
        public string TicketCollectionName { get; set; } = "";
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
    }
}
