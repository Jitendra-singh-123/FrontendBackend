using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiHostExercise.Models
{
	[Table("Player")]
	public class Player
	{
		[Key]
		public int PId { get; set; }
		[Required]
		public string PName { get; set; }
		[Required]
		public string PCountry { get; set; }
		[Required]
		public string PType { get; set; }
	}
}
