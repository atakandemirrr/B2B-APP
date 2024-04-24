



using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B2B_Deneme.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public DateTime CreDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        [Required]
        [MaxLength(25)]
        public string Email { get; set; }

        [Required]
        [MaxLength(25)]
        public string CkKod { get; set; }


    }
}

