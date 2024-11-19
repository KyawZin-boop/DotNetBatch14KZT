using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DotNetBatch14KZT.ConsoleApp2.AdoDotNetExamples;

public class AdoDotNetExample
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "DESKTOP-C0JBC3O\\MSSQLSERVER2022", //server name
        InitialCatalog = "test_db", //database name
        UserID = "sa",
        Password = "Kyawzin@123",
        TrustServerCertificate = true
    };

    public void Read()
    {
        SqlConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        con.Open();

        SqlCommand cmd = new SqlCommand("Select * from tbl_blog", con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        con.Close();

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("id = " + dr["blog_id"]);
            Console.WriteLine("title = " + dr["blog_title"]);
            Console.WriteLine("author = " + dr["blog_author"]);
            Console.WriteLine("content = " + dr["blog_content"]);
            Console.WriteLine("");
        }
    }

    public void Edit(string id)
    {
        SqlConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand($"Select * from tbl_blog where blog_id='{id}'", con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        con.Close();

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("Data not found!");
            return;
        }

        DataRow row = dt.Rows[0];

        Console.WriteLine("id = " + row["blog_id"]);
        Console.WriteLine("title = " + row["blog_title"]);
        Console.WriteLine("author = " + row["blog_author"]);
        Console.WriteLine("content = " + row["blog_content"]);
    }
}
