using System.ComponentModel.DataAnnotations;

namespace Spender.Models
{
    public class Expense
    {
        
        public int Id { get; set; }
        [Required (ErrorMessage ="Value is required.")]
        public decimal Value { get; set; }

        [Required]
        [StringLength(30, MinimumLength =3, ErrorMessage ="description between 3 - 30 characters!")]
        public string description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
