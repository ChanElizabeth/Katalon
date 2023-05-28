using System;
using System.Linq;
using System.Threading.Tasks;
using FirstProj.Data;
using FirstProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Action Methods

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_db.Users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers([FromBody] Users objUsers)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error while creating new user");
            }
            _db.Users.Add(objUsers);
            await _db.SaveChangesAsync();

            return new JsonResult("User successfully created");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUsers([FromRoute] int Id, [FromBody] Users objUsers)
        {
            if (objUsers == null || Id != objUsers.Id)
            {
                return new JsonResult("User Was Not Found");
            }
            else
            {
                _db.Users.Update(objUsers);
                await _db.SaveChangesAsync();
                return new JsonResult("User Was Updated Successfully");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int Id)
        {
            var findEmployee = await _db.Users.FindAsync(Id);
            if (findEmployee == null)
            {
                return NotFound();
            }
            else
            {
                _db.Users.Remove(findEmployee);
                await _db.SaveChangesAsync();
                return new JsonResult("User Was Deleted Successfully");
            }
        }
    }
}
