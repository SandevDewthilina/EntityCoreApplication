using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCoreApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityCoreApplication.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly SchoolContext _context;

        public UserDetailsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GetUserData(string username, string password)
        {

            var user = await _context.Users.FirstOrDefaultAsync(user =>
                user.username.Equals(username) && user.password.Equals(password));
            if (user != null)
            {
                return Ok(Json(user));
            }
            return NotFound();
        }
    }
}
