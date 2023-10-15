using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Netpobre.Models
{
    public class Series
    {
        [Key]

        [Required]
        [Display(Name = "ID")]
        public int IdShow { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Show { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field required")]
        public int Seasons { get; set; }

        [Required(ErrorMessage = "Field required")]
        public int Episodes { get; set; }

        [Required(ErrorMessage = "Field required")]
        public string Actors { get; set; }

        [Required(ErrorMessage = "Field required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
