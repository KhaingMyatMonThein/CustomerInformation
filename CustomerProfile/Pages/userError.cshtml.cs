//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using CustomerProfile.Data;
//using System.Threading.Tasks;
//using System;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Linq;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using Microsoft.EntityFrameworkCore;

//namespace CustomerProfile.Pages
//{
//    public class UserModel : PageModel
//    {
//        private readonly CusDBContext _context;

//        public UserModel(CusDBContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public UserProfileModel UserProfile { get; set; }

//        public List<SelectListItem> NationalityList { get; set; }

//        // Corrected method name: OnGetAsync
//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            UserProfile = await _context.UserProfiles.FindAsync(id);
//            if (UserProfile == null)
//            {
//                return NotFound();
//            }

//            // Load NationalityList from the database
//            NationalityList = await _context.Nationalities
//                .Select(n => new SelectListItem
//                {
//                    Value = n.Id.ToString(),
//                    Text = n.CountryName
//                }).ToListAsync();

//            return Page();
//        }

//        // Method for handling form submission
//        public async Task<IActionResult> OnPostAsync()
//        {
//            try
//            {
//                // Repopulate NationalityList to re-render the dropdown
//                NationalityList = await _context.Nationalities
//                .Select(n => new SelectListItem
//                {
//                    Value = n.Id.ToString(),
//                    Text = n.CountryName
//                }).ToListAsync();

//                // Proceed with the rest of the logic for saving or updating the user
//                var existingUser = await _context.UserProfiles.FindAsync(UserProfile.Id);
//                if (existingUser != null)
//                {
//                    existingUser.Name = UserProfile.Name;
//                    existingUser.DOB = UserProfile.DOB;
//                    existingUser.Gender = UserProfile.Gender;
//                    existingUser.Age = UserProfile.Age;
//                    existingUser.Phone = UserProfile.Phone;
//                    existingUser.Email = UserProfile.Email;
//                    existingUser.Street = UserProfile.Street;
//                    existingUser.City = UserProfile.City;
//                    existingUser.NationalityID = UserProfile.NationalityID;


//                    TempData["Message"] = "User updated successfully";
//                }
//                else
//                {
//                    _context.UserProfiles.Add(UserProfile);
//                    TempData["Message"] = "User created successfully";
//                }


//                await _context.SaveChangesAsync();
//                return RedirectToPage("/Index");
//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError(string.Empty, "An error occurred while saving changes: " + ex.Message);

//                // Repopulate NationalityList to show dropdown after an error
//                NationalityList = await _context.Nationalities
//                    .Select(n => new SelectListItem
//                    {
//                        Value = n.Id.ToString(),
//                        Text = n.CountryName
//                    }).ToListAsync();

//                return Page();
//            }
//        }
//    }
//}