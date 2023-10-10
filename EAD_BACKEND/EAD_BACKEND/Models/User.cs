/*
 * File: User.cs
 * Author: Wanni Arachchige H.S
 * Date: October 8, 2023
 * Description: This file contains the definition of the User class.
 * Reference: https://youtu.be/dsvL22_w88I?feature=shared
 */

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace EAD_BACKEND.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("name")]
        [Required]
        public string Name { get; set; } = "";

        [BsonElement("nic")]
        [BsonRequired]
        [Required]
        public string Nic { get; set; } = "";

        [BsonElement("username")]
        [Required]
        public string Username { get; set; } = "";

        [BsonElement("password")]
        [Required]
        public string Password { get; set; } = "";

        [BsonElement("privilege")]
        public int Privilege { get; set; }

        [BsonElement("activation")]
        public bool Activation { get; set; } 
    }
}
