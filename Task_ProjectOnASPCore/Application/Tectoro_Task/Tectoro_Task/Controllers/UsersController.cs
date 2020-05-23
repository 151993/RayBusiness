using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tectoro_Task.Models;
using Tectoro_Task.Repository;

namespace Tectoro_Task.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DomainContext _context;
        private IPostRepository _postRepository;
        //private object _postRepository;

        //public UsersController(DomainContext context, IPostRepository repository)
        //{
        //    _context = context;
        //}
        public UsersController(IPostRepository postRepository, DomainContext context)
        {
            _postRepository = postRepository;
            _context = context;
        }

        /// <summary>
        /// Get All User Details
        /// </summary>
        [HttpGet]
        [ActionName("User")]
        public ActionResult<List<Users>> GetUsers()
        {
            return _postRepository.GetUsers();
        }

        /// <summary>
        /// Add User Details
        /// </summary>
        [HttpPost]
        [ActionName("AddUser")]
        public async Task<ActionResult> AddUser(Users users)
        {
            _postRepository.AddUser(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        /// <summary>
        /// Update User Details
        /// </summary>
        [HttpPost]
        [ActionName("UpdateUsers")]
        public async Task<IActionResult> UpdateUsers( Users users)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _postRepository.UpdateUser(users);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        [HttpDelete]
        [ActionName("DeleteUsers")]
        public async Task<IActionResult> DeleteUsers(int id)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _postRepository.DeleteUser(id);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Retrieve all Managers with their associated clients
        /// </summary>
        [HttpGet]
        [ActionName("ManagerClientDetails")]
        public List<Helper> GetDetails()
        {
            return _postRepository.GetDetails();
        }

        /// <summary>
        /// Retrieve all Clients including their Manager
        /// </summary>
        [HttpGet]
        [ActionName("ClientManagerDetails")]
        public List<Helper> ClientManagerDetails()
        {
            return _postRepository.ClientManagerDetails();
        }

        /// <summary>
        /// For a specified Manager username, retrieve a list of its clients
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetManagerAllClients")]
        public List<Helper> GetManagerAllClients(string userName)
        {
            return _postRepository.GetManagerAllClients(userName);
        }



        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
