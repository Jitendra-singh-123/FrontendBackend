using System.ComponentModel.DataAnnotations;

namespace MVCDemo2.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Date of Joining is required.")]
        public DateTime DOJ { get; set; }
    }
}
