namespace onetooneWithFluentAPI.Models
{
    public class Biography
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId {  get; set; }
        public Author Author { get; set; }
       
    }
}
