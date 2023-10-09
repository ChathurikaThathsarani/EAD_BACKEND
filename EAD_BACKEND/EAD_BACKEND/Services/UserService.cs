/*
 * File: UserService.cs
 * Author: Wanni Arachchige H.S
 * Date: October 8, 2023
 * Description: This file defines the UserService class, which implements the IUserService interface.
 * Reference: 
 */

using EAD_BACKEND.IServices;
using EAD_BACKEND.Interfaces;
using EAD_BACKEND.Models;
using MongoDB.Driver;

namespace EAD_BACKEND.Services
{
    public class UserService  : IUserService
    {
        private readonly IMongoCollection<User> userObj;

        // Constructor to initialize the MongoDB collection
        public UserService(IUserDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            userObj = database.GetCollection<User>(settings.UserCollectionName);
            var indexModel = new CreateIndexModel<User> (
                Builders<User>.IndexKeys.Ascending(obj => obj.Nic),
                new CreateIndexOptions { Unique = true }
            );
            userObj.Indexes.CreateOne(indexModel);
        }

        // Method for creating a user
        public int CreateUser(User user)
        {
            try
            {
                userObj.InsertOne(user);
                return 1;
            }
            catch (MongoWriteException)
            {
                return -1;
            }
        }

        // Method for getting all users
        public List<User> GetUsers()
        {
            return userObj.Find(user => true).ToList();
        }

        // Method for getting a user by its ID
        public User GetUserByID(string userID)
        {
            return userObj.Find(user => user.Id == userID).FirstOrDefault();
        }

        // Method for login functionality
        public User LoginUser(string username)
        {
            return userObj.Find(user => user.Username == username).FirstOrDefault();
        }

        // Method for removing a user
        public void RemoveUser(string userID)
        {
            userObj.DeleteOne(user => user.Id == userID);
        }

        // Method for updating a user
        public void UpdateUser(string userID, User user)
        {
            userObj.ReplaceOne(user => user.Id == userID, user);
        }
    }
}
