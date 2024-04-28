using B2B_Deneme.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;

namespace B2B_Deneme.Models
{
    public class DataContext :DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CandidateUser> CandidateUsers { get; set; }
        public DbSet<Order> Orders { get; set; }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("MikroConnection");
        }

        public DataTable Musteri()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT top 10 sto_kod,sto_isim, dbo.fn_EldekiMiktar(sto_kod) Miktar,sfiyat_fiyati FROM [dbo].[STOKLAR] S LEFT JOIN dbo.STOK_SATIS_FIYAT_LISTELERI F ON  S.sto_kod = F.sfiyat_stokkod where sfiyat_fiyati not in  ('')", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable CariBilgileri(string Mail )
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT  C.cari_unvan1 as Unvan, CONCAT('SİP','-',ISNULL(MAX(O.SipSira),0)+1) as Sip  FROM dbo.CARI_HESAPLAR C LEFT JOIN  [B2BAPP].[dbo].[Orders] O ON   C.cari_kod = O.CariKod COLLATE Turkish_CI_AS WHERE C.cari_EMail = '"+ Mail + "'  GROUP BY  C.cari_unvan1", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable CariSipBilgileri(string Mail)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();  
                SqlCommand command = new SqlCommand("SELECT CONCAT('SİP', '-', O.SipSira) as SipNo,O.CreDate KTRH,O.CreDate TESTRH,SUM(O.Total) SIPTUTAR FROM [B2BAPP].[dbo].[Orders] O LEFT JOIN  dbo.CARI_HESAPLAR C  ON   C.cari_kod = O.CariKod COLLATE Turkish_CI_AS WHERE C.cari_EMail = '" + Mail + "' GROUP BY O.SipSeri, O.SipSira, O.CreDate", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

    }
}
