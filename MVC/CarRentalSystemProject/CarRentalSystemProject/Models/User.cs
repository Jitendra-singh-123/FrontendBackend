using Microsoft.AspNetCore.Identity;

namespace CarRentalSystemProject.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Rental> Rentals { get; set; }
    }
}
