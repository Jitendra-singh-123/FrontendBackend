using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo2.Models
{
    public class Player
    {
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Player Id")]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Player Name")]

        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Player Role")]

        public string Description { get; set; }
    }
}
