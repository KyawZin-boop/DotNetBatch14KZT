using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBatch14KZT.ConsoleApp.Dtos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBatch14KZT.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly string _connectionString = AppSettings.ConnectionStringBuilder.ConnectionString;

        public void Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            List<BlogDtos> lst = connection.Query<BlogDtos>("Select * from tbl_blog").ToList();

            foreach (BlogDtos item in lst)
            {
                Console.WriteLine(item.blog_id);
                Console.WriteLine(item.blog_title);
                Console.WriteLine(item.blog_author);
                Console.WriteLine(item.blog_content);
                Console.WriteLine("");
            }

        }

        public void Edit(string id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            var item = connection.Query<BlogDtos>($"Select * from tbl_blog where blog_id='{id}'").FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("Data not found!");
                return;
            }

            Console.WriteLine(item.blog_id);
            Console.WriteLine(item.blog_title);
            Console.WriteLine(item.blog_author);
            Console.WriteLine(item.blog_content);
        }

        public void Create(string title, string author, string content)
        {
            string query = @$"INSERT INTO [dbo].[tbl_blog]
                               ([blog_title]
                               ,[blog_author]
                               ,[blog_content])
                         VALUES
                               ('{title}'
                               ,'{author}'
                               ,'{content}')";

            using IDbConnection connection = new SqlConnection(_connectionString);

            //var result = connection.Query<BlogDtos>(query).FirstOrDefault();
            var result = connection.Execute(query);

            string message = result > 0 ? "Create Success!" : "Create Fail!";
            Console.WriteLine(message);
        }

        public void Update(string id)
        {
            string query = $@"UPDATE [dbo].[tbl_blog]
                                           SET [blog_title] = 'dapperUpdateTitle'
                                              ,[blog_author] = 'dapperUpdateAuthor'
                                              ,[blog_content] = 'dapperUpdateContent'
                                         WHERE blog_id = '{id}'";

            using IDbConnection connection = new SqlConnection(_connectionString);

            var result = connection.Execute(query);

            string message = result > 0 ? "Update Success!" : "Fail to Update!";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            var result = connection.Execute($@"DELETE FROM [dbo].[tbl_blog] WHERE blog_id = '{id}'");

            string message = result > 0 ? "Delete Success!" : "Fail to Delete!";
            Console.WriteLine(message);

        }
    }
}
