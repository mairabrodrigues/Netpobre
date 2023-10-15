using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Netpobre.Models
{
    public class Client
    {
        [Key]

        public int ID { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Field required")]
        public string UserClient { get; set; }

        [Required(ErrorMessage = "Field required")]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password{ get; set; }
        public ICollection<Rents> Rents { get; set;}
    }
}
