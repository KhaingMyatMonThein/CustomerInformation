


using CustomerProfile.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProfile.Pages
{
    public class ReportModel : PageModel
    {
        private readonly CusDBContext _context;

        public ReportModel(CusDBContext context)
        {
            _context = context;
        }

        public List<UserProfileModel> Users { get; set; }

        public List<SelectListItem> NationalityList { get; set; }

        public async Task OnGetAsync(int? nationalityId)
        {
            // Load all nationalities for the filter dropdown
            NationalityList = await _context.Nationalities
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.CountryName
                }).ToListAsync();

            // Filter users based on selected nationality ID
            if (nationalityId.HasValue && nationalityId.Value > 0)
            {
                Users = await _context.UserProfiles
                    .Include(u => u.Nationality) // Assuming you have a navigation property for Nationality
                    .Where(u => u.NationalityID == nationalityId.Value)
                    .ToListAsync();
            }
            else
            {
                Users = await _context.UserProfiles.Include(u => u.Nationality).ToListAsync();
            }
        }
    }
}