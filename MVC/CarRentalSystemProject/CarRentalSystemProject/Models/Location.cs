namespace CarRentalSystemProject.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Code { get; set; }    
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
