/*
 * File: UserController.cs
 * Author: Wanni Arachchige H.S
 * Date: October 8, 2023
 * Description: This file defines the UserController, which implements the controllers for user.
 * Reference: https://youtu.be/dsvL22_w88I?feature=shared
 */

using Microsoft.AspNetCore.Mvc;
using EAD_BACKEND.IServices;
using EAD_BACKEND.Models;

namespace EAD_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        // Constructor to initialize the userService instance 
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        // Controller for getting all users
        [HttpGet]
        public ActionResult<List<User>> GetUsersController()
        {
            return userService.GetUsers();
        }

        // Controller for getting user by its ID
        [HttpGet("{id}")]
        public ActionResult<User> GetUserByIDController(string id)
        {
            var available = userService.GetUserByID(id);

            if (available == null)
            {
                return NotFound($"User cannot be found");
            }

            return available;
        }

        [HttpGet("login/{username}/{password}")]
        public ActionResult<User> LoginUserController(string username, string password)
        {
            var available = userService.LoginUser(username);

            if (available == null)
            {
                return Ok($"User cannot be found");
            }
            else if (available.Password == password && available.Activation == true)
            {
                return available;
            }
            else if (available.Password == password && available.Activation == false)
            {
                return Ok($"Activation for login is failed");
            }
            else
            {
                return Ok($"Login is unsuccessful");
            }

        }

        // Controller for creating a user
        [HttpPost]
        public ActionResult CreateUserController([FromBody] User user)
        {
            var available = userService.CreateUser(user);

            if (available == -1)
            {
                return NotFound($"User is exist");
            }
            else
            {
                return Ok($"User is successfully created");
            }
        }

        // Controller for updating a user
        [HttpPut("{id}")]
        public ActionResult UpdateUserController(string id, [FromBody] User user)
        {

            var available = userService.GetUserByID(id);

            if (available == null)
            {
                return NotFound($"User cannot be found");
            }

            userService.UpdateUser(id, user);

            return Ok($"User is successfully updated");

        }

        // Controller for deleting a user
        [HttpDelete("{id}")]
        public ActionResult DeleteUserController(string id)
        {
            var available = userService.GetUserByID(id);

            if (available == null)
            {
                return NotFound($"User cannot be found");
            }

            userService.RemoveUser(available.Id);

            return Ok($"User is successfully deleted");
        }

        // Controller for getting a user by NIC
        [HttpGet("getByNic/{nic}")]
        public ActionResult<User> GetUserByNicController(string nic)
        {
            var available = userService.GetUserByNic(nic);

            if (available == null)
            {
                return NotFound($"User with NIC {nic} cannot be found");
            }

            return available;
        }

    }
}
