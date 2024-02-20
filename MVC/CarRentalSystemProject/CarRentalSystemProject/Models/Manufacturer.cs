namespace CarRentalSystemProject.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public IEnumerable<Model> Models { get; set; }
    }
}
