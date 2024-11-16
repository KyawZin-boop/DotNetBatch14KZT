// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System;
using System.Data;

SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
connectionStringBuilder.DataSource = "DESKTOP-C0JBC3O\\MSSQLSERVER2022"; //server name
connectionStringBuilder.InitialCatalog = "test_db"; //database name
connectionStringBuilder.UserID = "sa";
connectionStringBuilder.Password = "Kyawzin@123";
connectionStringBuilder.TrustServerCertificate = true;

SqlConnection con = new SqlConnection(connectionStringBuilder.ConnectionString);

con.Open();

String query = "Select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, con);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

con.Close();

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["blog_title"]);
    Console.WriteLine(dr["blog_author"]);
    Console.WriteLine(dr["blog_content"]);
}