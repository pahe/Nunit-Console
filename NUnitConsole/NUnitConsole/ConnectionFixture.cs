using Microsoft.Data.SqlClient;
using NUnit.Framework;
using Testcontainers.MsSql;

namespace NUnitConsole
{
    [TestFixture]
    public class ConnectionFixture
    {
        [Test]
        [Ignore("")]
        public void TestConnection()
        {
            var connectionString = "connection";
            var connection = new SqlConnection(connectionString);
            connection.Open();
        }

        [Test]
        public async Task TestConnectionWithContainers()
        {
            //https://dotnet.testcontainers.org/modules/mssql/
            //You need to have docker installed in the machine that running the test. 

            MsSqlContainer sqlContainer = new MsSqlBuilder().Build();
            await sqlContainer.StartAsync();

            var connection = new SqlConnection(sqlContainer.GetConnectionString());
            connection.Open();
        }
    }
}
