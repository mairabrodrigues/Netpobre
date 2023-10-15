using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netpobre.Models
{
    public class Stars
    {
        [Key]
        public int IdClient { get; set; }
        public int IdShow { get; set; }

        [ForeignKey("IdClient")]
        public Client Client { get; set; }
        [ForeignKey("IdShow")]
        public Series Series { get; set; }
    }
}
