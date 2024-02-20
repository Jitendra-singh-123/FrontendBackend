namespace CarRentalSystemProject.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int StatusId {  get; set; }
        public Status Status { get; set; }

        public int CarId {  get; set; } 
        public Car Car { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
