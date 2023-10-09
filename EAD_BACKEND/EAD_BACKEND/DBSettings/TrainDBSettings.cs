/*
 * File: TrainDBSettings.cs
 * Author: Jayasingha U.A.C.L
 * Date: October 8, 2023
 * Description: This file defines the TrainDBSettings class, which represents the implemenattion for the ITrainDBSettings interface.
 * Reference: 
 */

using EAD_BACKEND.Interfaces;
namespace EAD_BACKEND.Implementations
{
    public class TrainDBSettings : ITrainDBSettings
    {
        public string TrainCollectionName { get; set; } = "";
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
    }
}

