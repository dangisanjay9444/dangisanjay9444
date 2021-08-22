using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("API/Users")]
    public class UsersController : ControllerBase
    {
       private readonly ApplicationDbContext _context;
       public UsersController(ApplicationDbContext context)
       {
           _context = context;
       } 

       [HttpGet]
       // It will return the list of all the users
       // Asynchronous Code
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //var users = _context.Users.ToList();
            //return users;
            //If we are not performing any action on the returned results then we can return
            // without using the variables.

            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        // It will retun the result for the specific user
        //API/Users/2
        //Asynchronous Code
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            //var user = _context.Users.Find(id);
            //return user;

            //If we are not performing any action on the returned results then we can return
            // without using the variables.
            // Find will find the entity with the given primary key
            return await _context.Users.FindAsync(id);
        }
        
    }
}