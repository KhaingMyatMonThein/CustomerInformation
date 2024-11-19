using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerProfile.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CustomerProfile.Pages
{
    public class AdminModel : PageModel
    {
        private readonly CusDBContext _context;

        public AdminModel(CusDBContext context)
        {
            _context = context;
        }

        public List<UserProfileModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.UserProfiles
                .Include(u => u.Nationality)
                .ToListAsync();

            var cnt = Users.Count();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _context.UserProfiles.FindAsync(id);
            if (user != null)
            {
                _context.UserProfiles.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
