using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netpobre.Models
{
    public class Rents
    {
        [Key]
        public string Show { get; set; }
        public DateTime Date { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
                
        [ForeignKey("IdClient")]
        public Client Client { get; set; }

    }
}
