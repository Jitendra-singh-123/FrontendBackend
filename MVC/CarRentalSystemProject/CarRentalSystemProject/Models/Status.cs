namespace CarRentalSystemProject.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public IEnumerable<Rental> Rentals { get; set; }
    }
}
