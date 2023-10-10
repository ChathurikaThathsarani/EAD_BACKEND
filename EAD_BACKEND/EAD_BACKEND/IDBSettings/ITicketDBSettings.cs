/*
 * File: ITicketDBSettings.cs
 * Author: Dombepola D.A.C.T
 * Date: October 8, 2023
 * Description: This file defines the ITicketDBSettings interface, which represents the database settings for the Ticket entity.
 * Reference: https://youtube.com/playlist?list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0&si=cyZFtfJ6-tAtDonz
 */

namespace EAD_BACKEND.Interfaces
{
    public interface ITicketDBSettings
    {
        string TicketCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
