using System.ComponentModel.DataAnnotations;

namespace LoggingInWebAPI
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public double? Average { get; set; }
    }
}
