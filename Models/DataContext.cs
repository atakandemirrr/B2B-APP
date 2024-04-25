using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace B2B_Deneme.Models
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<CandidateUser> CandidateUsers { get; set; }

        public DataTable Musteri()
        {
            using (SqlConnection connection = new SqlConnection("Server=Fdb-TECH;Database=MikroDB_V16_Fdbtech;Trusted_Connection=True;MultipleActiveResultSets=true;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY cari_unvan1) AS Sira,cari_kod,cari_unvan1,cari_EMail,cari_CepTel,cari_vdaire_adi,cari_vdaire_no FROM dbo.CARI_HESAPLAR", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable Stok()
        {
            using (SqlConnection connection = new SqlConnection("Server=Fdb-TECH;Database=MikroDB_V16_Fdbtech;Trusted_Connection=True;MultipleActiveResultSets=true;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT sto_kod,sto_isim, dbo.fn_EldekiMiktar(sto_kod) Miktar,sfiyat_fiyati FROM [dbo].[STOKLAR] S LEFT JOIN dbo.STOK_SATIS_FIYAT_LISTELERI F ON  S.sto_kod = F.sfiyat_stokkod", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

    }
}
