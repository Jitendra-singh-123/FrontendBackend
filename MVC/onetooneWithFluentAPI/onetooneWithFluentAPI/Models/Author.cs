namespace onetooneWithFluentAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Biography Biography { get; set; }
        
    }
}
