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
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.CARI_HESAPLAR", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        }
}
