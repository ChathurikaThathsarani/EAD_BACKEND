/*
 * File: Train.cs
 * Author: Jayasingha U.A.C.L
 * Date: October 8, 2023
 * Description: This file contains the definition of the Train class.
 * Reference: 
 */

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace EAD_BACKEND.Models
{
    public class Train
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("name")]
        [Required]
        public string Name { get; set; } = "";

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

        [BsonElement("cancel")]
        [Required]
        public bool Cancel { get; set; }
    }
}
