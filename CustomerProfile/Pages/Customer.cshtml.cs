using CustomerProfile.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerProfile.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly CusDBContext _context;

        public CustomerModel(CusDBContext context)
        {
            _context = context;
            NationalityList = new List<SelectListItem>();
            UserProfile = new UserProfileModel();
        }

        [BindProperty]
        public UserProfileModel UserProfile { get; set; }

        public List<SelectListItem> NationalityList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // If id is provided, load existing user profile
            if (id != null)
            {
                UserProfile = await _context.UserProfiles.FindAsync(id);
                if (UserProfile == null)
                {
                    return NotFound();
                }
            }

            // Load NationalityList from the database
            NationalityList = await _context.Nationalities
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.CountryName
                }).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Repopulate NationalityList to re-render the dropdown
                NationalityList = await _context.Nationalities
                    .Select(n => new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.CountryName
                    }).ToListAsync();

                var existingUser = await _context.UserProfiles.FindAsync(UserProfile.Id);
                if (existingUser != null)
                {
                    // Update existing user profile
                    existingUser.Name = UserProfile.Name;
                    existingUser.DOB = UserProfile.DOB;
                    existingUser.Gender = UserProfile.Gender;
                    existingUser.Age = UserProfile.Age;
                    existingUser.Phone = UserProfile.Phone;
                    existingUser.Email = UserProfile.Email;
                    existingUser.Street = UserProfile.Street;
                    existingUser.City = UserProfile.City;
                    existingUser.NationalityID = UserProfile.NationalityID;

                    TempData["Message"] = "User updated successfully";
                }
                else
                {
                    // Add new user profile
                    _context.UserProfiles.Add(UserProfile);
                    TempData["Message"] = "User created successfully";
                }

                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving changes: " + ex.Message);

                // Repopulate NationalityList to show dropdown after an error
                NationalityList = await _context.Nationalities
                    .Select(n => new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.CountryName
                    }).ToListAsync();
                
                return Page();
            }
        }
    }
}