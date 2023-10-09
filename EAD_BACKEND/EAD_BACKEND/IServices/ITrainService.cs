/*
 * File: ITrainService.cs
 * Author: Jayasingha U.A.C.L
 * Date: October 8, 2023
 * Description: This file defines the ITrainService interface, which represents the service contract for managing trains.
 * Reference: 
 */

using EAD_BACKEND.Models;
namespace EAD_BACKEND.IServices
{
    public interface ITrainService
    {
        List<Train> GetTrains();
        Train GetTrainById(string id);
        List<Train> GetRunningTrains();
        bool GetTicketForTrain(string train);
        int CreateTrain(Train train);
        void UpdateTrain(string id, Train train);
        void RemoveTrain(string id);
    }
}
