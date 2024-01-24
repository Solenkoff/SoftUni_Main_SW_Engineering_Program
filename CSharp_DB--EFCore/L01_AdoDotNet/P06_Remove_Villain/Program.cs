using System.Data.SqlClient;
using System.Text;

const string GetVillainName = @"SELECT Name FROM Villains WHERE Id = @villainId";
const string ReleaseMinionsFromVillain = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
const string DeleteVillain = @"DELETE FROM Villains WHERE Id = @villainId";

const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";

using SqlConnection? sqlConnection = new SqlConnection(connectionString);

try
{
    await sqlConnection.OpenAsync();

    int villainId = int.Parse(Console.ReadLine());

    SqlTransaction transaction = sqlConnection.BeginTransaction();

    try
    {
        using SqlCommand cmdGetVillainName = new(GetVillainName, sqlConnection, transaction);
        cmdGetVillainName.Parameters.AddWithValue("@villainId", villainId);
        var villainName = await cmdGetVillainName.ExecuteScalarAsync();

        if (villainName is null)
        {
            await Console.Out.WriteLineAsync("No such villain was found.");
            return;
        }

        StringBuilder sb = new StringBuilder();

        using SqlCommand cmdReleaseMinions =
            new(ReleaseMinionsFromVillain, sqlConnection, transaction);
        cmdReleaseMinions.Parameters.AddWithValue("@villainId", villainId);
        int minionsReleased = await cmdReleaseMinions.ExecuteNonQueryAsync();

        using SqlCommand cmdDeleteVillain =
            new(DeleteVillain, sqlConnection, transaction);
        cmdDeleteVillain.Parameters.AddWithValue("@villainId", villainId);
        int villainsDeleted = await cmdDeleteVillain.ExecuteNonQueryAsync();

        if (villainsDeleted == 1)
        {
            sb.AppendLine($"{villainName} was deleted.");
            sb.AppendLine($"{minionsReleased} minions were released.");
            await Console.Out.WriteLineAsync(sb.ToString().Trim());
        }

        transaction.Commit();

    }
    catch
    {
        transaction.Rollback();
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