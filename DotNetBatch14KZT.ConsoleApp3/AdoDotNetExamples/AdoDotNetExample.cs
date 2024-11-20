using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14KZT.ConsoleApp3.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _connectionString = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-C0JBC3O\\MSSQLSERVER2022",
            InitialCatalog = "test_db",
            UserID = "sa",
            Password = "Kyawzin@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection con = new SqlConnection(_connectionString.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from tbl_blog", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            con.Close();

            foreach(DataRow dr in dt.Rows)
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
            SqlConnection con = new SqlConnection(_connectionString.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand($"Select * from tbl_blog where blog_id='{id}'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            con.Close();

            if(dt.Rows.Count < 0)
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

        public void Create(string title, string author, string content)
        {
            string query = @$"Insert INTO [dbo].[tbl_blog]
                                ([blog_title],
                                 [blog_author],
                                 [blog_content]) 
                        VALUES ('{title}',
                                '{author}',
                                '{content}')";


            SqlConnection con = new SqlConnection(_connectionString.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            int result = cmd.ExecuteNonQuery();

            con.Close() ;

            string message = result > 0 ? "Successfully Created!" : "Create Fail!";
            Console.WriteLine(message);
        }

        public void Update(string id, string title, string author, string content)
        {
            string query = @$"UPDATE [dbo].[tbl_blog]
                                SET [blog_title] = '{title}'
                                    ,[blog_author] = '{author}'
                                    ,[blog_content] = '{content}'
                                WHERE blog_id = '{id}'";

            SqlConnection con = new SqlConnection(_connectionString.ConnectionString);
            con.Open() ;

            SqlCommand cmd = new SqlCommand(query, con);
            int result = cmd.ExecuteNonQuery();

            con.Close();

            string message = result > 0 ? "Successfully Updated!" : "Fail to Update the Data!";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            SqlConnection con = new SqlConnection(_connectionString.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(@$"DELETE FROM [dbo].[tbl_blog]
                                                WHERE blog_id = '{id}'", con);
            int result = cmd.ExecuteNonQuery();

            con.Close() ;

            string message = result > 0 ? "Delete Success!" : "Fail to Delete!";
            Console.WriteLine(message);
        }
    }
}
