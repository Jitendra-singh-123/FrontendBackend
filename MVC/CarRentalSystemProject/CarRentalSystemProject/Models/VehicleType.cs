namespace CarRentalSystemProject.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Code { get; set; }    
        public string Description { get; set; }
        public IEnumerable<Car> cars { get; set; }
    }
}
