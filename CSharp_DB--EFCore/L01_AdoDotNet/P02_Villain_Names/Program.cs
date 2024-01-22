using System.Data.SqlClient;

const string GetVillainsWithNumberOfMinions =
            @"SELECT v.[Name]
            	   , COUNT(mv.MinionId) AS MinionsCount
                FROM Villains AS v
                JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
            GROUP BY v.[Name]
              HAVING COUNT(mv.MinionId) > 3
            ORDER BY MinionsCount DESC";


//   1 - Connection String
const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";


//   2 - SQL Connection
using SqlConnection? sqlConnection = new SqlConnection(connectionString);

try
{
    await sqlConnection.OpenAsync();

    //   3 - SQL Command
    using SqlCommand getVillainsCommand = new SqlCommand(GetVillainsWithNumberOfMinions, sqlConnection);

    //   4 - SQL DataReader
    using SqlDataReader sqlDataReader = await getVillainsCommand.ExecuteReaderAsync();

    while (await sqlDataReader.ReadAsync())
    {
        await Console.Out.WriteLineAsync($"{sqlDataReader["Name"]} - {sqlDataReader["MinionsCount"]}");
    }

}
catch
{
    await Console.Out.WriteLineAsync("ERROR");
}
finally
{
    await sqlConnection.CloseAsync();
}
