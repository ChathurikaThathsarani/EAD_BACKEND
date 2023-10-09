/*
 * File: ITrainDBSettings.cs
 * Author: Jayasingha U.A.C.L
 * Date: October 8, 2023
 * Description: This file defines the ITrainDBSettings interface, which represents the database settings for the Train entity.
 * Reference: 
 */

namespace EAD_BACKEND.Interfaces
{
    public interface ITrainDBSettings
    {
        string TrainCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
