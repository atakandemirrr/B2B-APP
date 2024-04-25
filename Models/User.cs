



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
        public DateTime UpdateDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        [Required]
        [MaxLength(25)]
        public string Email { get; set; }
        public bool IsPasivve { get; set; }/*0 aktif 1 pasif*/
        public bool IsAdmin { get; set; }/*0 hayır 1 evet*/

    }
}

