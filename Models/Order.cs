using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B2B_Deneme.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTableId { get; set; }

        public DateTime CreDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string SipSeri { get; set; }
        public int SipSira { get; set; }


        [Required]
        [MaxLength(25)]
        public string CariKod { get; set; }
        public string StokKod { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Statu { get; set; }/*0 beklemede 1 onaylandı 2 rededildi*/
      
    }
}
