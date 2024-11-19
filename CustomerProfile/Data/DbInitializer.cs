using System.Linq;
using System.Collections.Generic;
using CustomerProfile.Data;

namespace CustomerProfile.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CusDBContext context)
        {
            // Check if there are any nationalities already in the database
            if (context.Nationalities.Any())
            {
                return; // Database has already been seeded
            }

            // List of countries to seed
            var nationalities = new List<NationalityModel>
            {
                new NationalityModel { CountryName = "United States" },
                new NationalityModel { CountryName = "Myanmar" },
                new NationalityModel { CountryName = "Korea" },
                new NationalityModel { CountryName = "Canada" },
                new NationalityModel { CountryName = "United Kingdom" },
                new NationalityModel { CountryName = "Germany" },
                new NationalityModel { CountryName = "France" },
                new NationalityModel { CountryName = "Australia" },
                new NationalityModel { CountryName = "India" },
                new NationalityModel { CountryName = "Japan" },
                new NationalityModel { CountryName = "Brazil" },
                new NationalityModel { CountryName = "South Africa" }
            };

            // Add the nationalities to the context and save
            context.Nationalities.AddRange(nationalities);
            context.SaveChanges();
        }
    }
}
