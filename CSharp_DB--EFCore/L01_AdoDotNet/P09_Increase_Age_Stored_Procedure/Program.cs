using System.Data;
using System.Data.SqlClient;

const string GetMinionDetails = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";

using SqlConnection? sqlConnection = new SqlConnection(connectionString);

try
{
    await sqlConnection.OpenAsync();

    int minionId = int.Parse(Console.ReadLine());

    SqlTransaction transaction = sqlConnection.BeginTransaction();

    try
    {
        using SqlCommand cmdCallUSP = new("usp_GetOlder", sqlConnection, transaction);
        cmdCallUSP.CommandType = CommandType.StoredProcedure;
        cmdCallUSP.Parameters.AddWithValue("@id", minionId);
        await cmdCallUSP.ExecuteNonQueryAsync();

        await transaction.CommitAsync();
    }
    catch (Exception)
    {
        await Console.Out.WriteLineAsync("ERROR");

        await transaction.RollbackAsync();
    }

    using SqlCommand cmdPrintMinion = new(GetMinionDetails, sqlConnection);
    cmdPrintMinion.Parameters.AddWithValue("@Id", minionId);
    using SqlDataReader reader = await cmdPrintMinion.ExecuteReaderAsync();

    while (await reader.ReadAsync())
    {
        await Console.Out.WriteLineAsync($"{reader["Name"]} - {reader["Age"]} years old");
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