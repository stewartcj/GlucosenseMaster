using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlucoSmart.Data;
using GlucoSmartAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlucoSmartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly GlucoSmartDb _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserController(GlucoSmartDb context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //GET: api/ApplicationUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetApplicationUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //GET: api/ApplicationUsers/<username>
        [HttpGet("{username},{password}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUser(string username, string password)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            bool verifiedPassword = await _userManager.CheckPasswordAsync(user, password);


            

            if (user == null || !verifiedPassword)
            {
                return NotFound();
            }

            
            
            return user;
        }
        /*
        // PUT: api/ApplicationUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationUser(string userName, ApplicationUser ApplicationUser)
        {
            var user = await _context.Users.
            if (user == null)
            {
                return BadRequest();
            }

            _context.Entry(ApplicationUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(userName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/ApplicationUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostApplicationUser(ApplicationUser ApplicationUser)
        {
            _context.Users.Add(ApplicationUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetApplicationUser), new { id = ApplicationUser.Id }, ApplicationUser);
        }

        // DELETE: api/ApplicationUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplicationUser>> DeleteApplicationUser(string id)
        {
            var ApplicationUser = await _context.Users.FindAsync(id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            _context.Users.Remove(ApplicationUser);
            await _context.SaveChangesAsync();

            return ApplicationUser;
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
