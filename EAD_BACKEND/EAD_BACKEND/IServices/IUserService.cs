/*
 * File: IUserService.cs
 * Author: Wanni Arachchige H.S
 * Date: October 8, 2023
 * Description: This file defines the IUserService interface, which represents the service contract for managing users.
 * Reference: 
 */

using EAD_BACKEND.Models;
namespace EAD_BACKEND.IServices
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserByID(string userID);
        User LoginUser(string username);
        int CreateUser(User user);
        void UpdateUser(string userID, User user);
        void RemoveUser(string userID);
        User GetUserByNic(string nic);
    }
}
