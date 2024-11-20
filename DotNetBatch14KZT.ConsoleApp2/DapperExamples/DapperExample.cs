using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetBatch14KZT.ConsoleApp2.Dtos;
using Microsoft.Data.SqlClient;

namespace DotNetBatch14KZT.ConsoleApp2.DapperExamples;

public class DapperExample
{
    private readonly string _connectionString = AppSettings.ConnectionStringBuilder.ToString();
}
