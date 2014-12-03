using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Marathon.IntegrationTests.Common
{
    public static class ScriptRunner
    {
        public static void RunScript()
        {
            const string connectionString = @"Data Source=localhost;Initial Catalog=Marathon;Integrated Security=true;";
            var filePath = Environment.CurrentDirectory + "\\..\\..\\..\\Marathon.Data\\SqlScripts\\";
            var file = new FileInfo(filePath + "00001_CreateDatabases.sql");
            var script = file.OpenText().ReadToEnd();
            var connection = new SqlConnection(connectionString);
            var server = new Server(new ServerConnection(connection));
            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
}
