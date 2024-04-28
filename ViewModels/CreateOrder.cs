using System.Data;

namespace B2B_Deneme.ViewModels
{
    public class CreateOrder
    {
        public DataTable CariBilgileri { get; set; } = new DataTable();
        public DataTable Stoklar { get; set; } = new DataTable();
    }
}
