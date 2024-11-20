using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14KZT.ConsoleApp
{
    public class AppSettings
    {
        public static SqlConnectionStringBuilder ConnectionStringBuilder { get; } = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-C0JBC3O\\MSSQLSERVER2022",
            InitialCatalog = "test_db",
            UserID = "sa",
            Password = "Kyawzin@123",
            TrustServerCertificate = true,
        };
    }
}
