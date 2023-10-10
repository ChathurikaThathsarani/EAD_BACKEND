/*
 * File: Ticket.cs
 * Author: Dombepola D.A.C.T
 * Date: October 8, 2023
 * Description: This file contains the definition of the Ticket class.
 * Reference: https://youtu.be/dsvL22_w88I?feature=shared 
 */

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace EAD_BACKEND.Models
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("trainId")]
        [Required]
        public string TrainId { get; set; } = "";

        [BsonElement("dateTime")]
        [Required]
        public string DateTime { get; set; } = "";

        [BsonElement("start")]
        [Required]
        public string Start { get; set; } = "";

        [BsonElement("end")]
        [Required]
        public string End { get; set; } = "";

        [BsonElement("price")]
        [Required]
        public double Price { get; set; }

        [BsonElement("noOfTicket")]
        [Required]
        public int NoOfTicket { get; set; }

        [BsonElement("userId")]
        [Required]
        public string UserId { get; set; } = "";

        [BsonElement("total")]
        [Required]
        public double Total { get; set; }

    }
}
