using System.ComponentModel.DataAnnotations;

namespace BangazonOrientation.API.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }
        [MinLength(3)]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [MinLength(3)]
        [MaxLength(255)]
        public string CustomerStreetAddress { get; set; }
        [MinLength(3)]
        [MaxLength(100)]
        public string CustomerCity { get; set; }
        [StringLength(2)]
        public string CustomerState { get; set; }
        [StringLength(5)]
        public string CustomerZip { get; set; }
        [StringLength(10)]
        public string CustomerPhone { get; set; }
    }
}