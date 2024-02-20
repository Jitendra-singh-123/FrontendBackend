using System.ComponentModel.DataAnnotations;

namespace MVCDemo2.Models
{
    public class Customer
    {
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Customer Id" )]
        public int CustomerId { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Customer Email")]
        public string CEmail { get; set; }

        [Microsoft.Build.Framework.Required]
        [Display(Name = "Customer Over Draft Limit")]
        [Range(1,1000,ErrorMessage ="Over Draft limit should be within 1000")] //display range and error
        public int OverDraftLimit { get; set; }
    }
}
