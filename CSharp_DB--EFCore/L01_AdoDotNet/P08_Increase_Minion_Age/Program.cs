using System.Data.SqlClient;

const string UpdateMinion =
          @" UPDATE Minions
         SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
       WHERE Id = @Id";

const string GetAllMinionsAfterUpdate = @"SELECT Name, Age FROM Minions";


const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";

using SqlConnection? sqlConnection = new SqlConnection(connectionString);

try
{
    await sqlConnection.OpenAsync();

    SqlTransaction transaction = sqlConnection.BeginTransaction();

    int[] minionIds = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    try
    {
        foreach (var id in minionIds)
        {
            using SqlCommand cmdUpdateMinion = new(UpdateMinion, sqlConnection, transaction);
            cmdUpdateMinion.Parameters.AddWithValue("@Id", id);
            await cmdUpdateMinion.ExecuteNonQueryAsync();
        }

        await transaction.CommitAsync();

    }
    catch (Exception)
    {
        await Console.Out.WriteLineAsync("ERROR");

        await transaction.RollbackAsync();
    }

    using SqlCommand cmdPrintMinions = new(GetAllMinionsAfterUpdate, sqlConnection, transaction);
    using SqlDataReader reader = await cmdPrintMinions.ExecuteReaderAsync();

    while (await reader.ReadAsync())
    {
        await Console.Out.WriteLineAsync($"{reader["Name"]} {reader["Age"]}");
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