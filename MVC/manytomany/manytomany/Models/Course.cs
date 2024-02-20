namespace manytomany.Models
{
    public class Course
    {
        

        public int Id { get; set; }
        public string title { get; set; }
        public virtual ICollection<Student> Students { get; set;}
    }
}
