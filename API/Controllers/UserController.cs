using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly Context context;

        public UsersController(Context _Context)
        {
            context = _Context;
        }

        [HttpGet("{GetUsers}")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users  = await context.Users.ToListAsync();
            return users;
        }
   
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int Id)
        {
            var user = await context.Users.FindAsync(Id);
            if(user == null) return NotFound();
            return user;
        }
    }
}