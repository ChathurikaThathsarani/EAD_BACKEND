/*
 * File: TrainService.cs
 * Author: Jayasingha U.A.C.L
 * Date: October 8, 2023
 * Description: This file defines the TrainService class, which implements the ITrainService interface.
 * Reference: https://youtu.be/dsvL22_w88I?feature=shared
 */

using EAD_BACKEND.IServices;
using EAD_BACKEND.Models;
using EAD_BACKEND.Interfaces;
using MongoDB.Driver;

namespace EAD_BACKEND.Services
{
    public class TrainService : ITrainService
    {
        private readonly IMongoCollection<Train> trainObj;
        private readonly IMongoCollection<Ticket> ticketObj;
        private string ticketCollection = "tickets";

        // Constructor to initialize the MongoDB collection
        public TrainService(ITrainDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            trainObj = database.GetCollection<Train>(settings.TrainCollectionName);
            ticketObj = database.GetCollection<Ticket>(ticketCollection);
        }

        // Method for creating a train
        public int CreateTrain(Train train)
        {
            try
            {
                trainObj.InsertOne(train);
                return 1;
            }
            catch (MongoWriteException)
            {
                return -1;
            }
        }

        // Method for getting tickets for particular train
        public bool GetTicketForTrain(string trainID)
        {
            return ticketObj.CountDocuments(ticket => ticket.TrainId == trainID) == 0;
        }

        // Method for getting trains
        public List<Train> GetTrains()
        {
            return trainObj.Find(train => true).ToList();
        }

        // Method for getting running trains
        public List<Train> GetRunningTrains()
        {
            return trainObj.Find(train => train.Cancel == false).ToList();
        }

        // Method for getting train by ID
        public Train GetTrainById(string trainID)
        {
            return trainObj.Find(train => train.Id == trainID).FirstOrDefault();
        }

        // Method for removing a train by id 
        public void RemoveTrain(string trainID)
        {
            trainObj.DeleteOne(train => train.Id == trainID);
        }

        // Method for updating a train by id 
        public void UpdateTrain(string trainID, Train train)
        {
            trainObj.ReplaceOne(train => train.Id == trainID, train);
        }
    }
}
