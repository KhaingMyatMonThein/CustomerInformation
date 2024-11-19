using CustomerProfile.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerProfile.Pages
{
    public class UserProfileModel
    {
        public int Id { get; set; } // Primary key

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int NationalityID { get; set; }
        public NationalityModel Nationality { get; set; }
       
    }
}
