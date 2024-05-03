using System.Data;

namespace B2B_Deneme.ViewModels
{
    public class VMMusteriler
    {
        public List<DataRow> Musteriler { get; set; } = new List<DataRow>();
        public List<DataRow> Stoklar { get; set; } = new List<DataRow>();
        public DataTable CariBilgileri { get; set; } = new DataTable();
        public List<DataRow> CariSipBilgileri { get; set; } = new List<DataRow>();
        public List<DataRow> OrderPrintInformations { get; set; } = new List<DataRow>();
        public List<DataRow> OrderApprovals { get; set; } = new List<DataRow>();
        


    }
}
