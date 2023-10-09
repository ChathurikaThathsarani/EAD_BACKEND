/*
 * File: TrainController.cs
 * Author: Jayasingha U.A.C.L
 * Date: October 8, 2023
 * Description: This file defines the TrainController, which implements the controllers for train.
 * Reference: 
 */

using EAD_BACKEND.IServices;
using EAD_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAD_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController :  ControllerBase
    {
        private readonly ITrainService trainService;

        // Constructor to initialize the trainService instance 
        public TrainController(ITrainService trainService)
        {
            this.trainService = trainService;
        }
        // Controller for getting all the trains
        [HttpGet]
        public ActionResult<List<Train>> GetTrainsController()
        {
            return trainService.GetTrains();
        }

        // Controller for getting all the running trains
        [HttpGet("running")]
        public ActionResult<List<Train>> GetRunningTrainsController()
        {
            return trainService.GetRunningTrains();
        }

        // Controller for getting the train by its ID
        [HttpGet("{id}")]
        public ActionResult<Train> Get(string id)
        {
            var available = trainService.GetTrainById(id);

            if (available == null)
            {
                return NotFound($"Train cannot be found");
            }

            return available;
        }

        // Controller for creating a  train
        [HttpPost]
        public ActionResult CreateTrainController([FromBody] Train train)
        {
            var available = trainService.CreateTrain(train);

            if (available == -1)
            {
                return NotFound($"Train is exist");
            }
            else
            {
                return Ok($"Train is successfully created");
            }
        }

        // Controller for updating a train by its ID
        [HttpPut("{id}")]
        public ActionResult UpdateTrainController(string id, [FromBody] Train train)
        {

            var available = trainService.GetTrainById(id);

            if (available == null)
            {
                return NotFound($"Train cannot be found");
            }

            trainService.UpdateTrain(id, train);

            return Ok($"Train is successfully updated");

        }

        // Controller for deleting a train by its ID
        [HttpDelete("{id}")]
        public ActionResult DeleteTrainController(string id)
        {
            var available = trainService.GetTrainById(id);

            if (available == null)
            {
                return NotFound($"Train cannot be found");
            }

            if (trainService.GetTicketForTrain(available.Id) == true)
            {
                return Ok($"Tickets are avalable for the train");
            }
            else
            {
                trainService.RemoveTrain(available.Id);
                return Ok($"Train is successfully deleted");
            }

        }

    }
}
