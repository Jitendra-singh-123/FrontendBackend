namespace CarRentalSystemProject.Models
{
    public class Model
    {
        public int Id { get; set; }
        public decimal DailyRate { get; set; }
        public string Name { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set;}
        public IEnumerable<Car> Cars { get; set; }
    }
}
