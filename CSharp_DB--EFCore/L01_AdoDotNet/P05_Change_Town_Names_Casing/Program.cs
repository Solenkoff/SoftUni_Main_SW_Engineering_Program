using System.Data.SqlClient;
using System.Text;

const string UPDATE_TOWN_CASING =
    @"UPDATE Towns
         SET Name = UPPER(Name)
       WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

const string GET_TOWN_NAMES =
    @"SELECT t.Name
        FROM Towns as t
        JOIN Countries AS c ON c.Id = t.CountryCode
       WHERE c.Name = @countryName";


const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";

using SqlConnection? sqlConnection = new SqlConnection(connectionString);

try
{
    await sqlConnection.OpenAsync();

    SqlTransaction transaction = sqlConnection.BeginTransaction();

    try
    {
        string countryName = Console.ReadLine();

        using SqlCommand cmdUpdateNames = new(UPDATE_TOWN_CASING, sqlConnection, transaction);
        cmdUpdateNames.Parameters.AddWithValue("@countryName", countryName);
        int countOfUpdatedTowns = await cmdUpdateNames.ExecuteNonQueryAsync();

        if (countOfUpdatedTowns == 0)
        {
            await Console.Out.WriteLineAsync("No town names were affected.");
            return;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{countOfUpdatedTowns} town names were affected.");

        List<string> townNames = new List<string>();

        using SqlCommand cmdGetTownNames = new(GET_TOWN_NAMES, sqlConnection, transaction);
        cmdGetTownNames.Parameters.AddWithValue("@countryName", countryName);
        using SqlDataReader reader = await cmdGetTownNames.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            townNames.Add($"{reader["Name"].ToString()}");
        }

        sb.AppendLine($"[{string.Join(", ", townNames)}]");
        await Console.Out.WriteLineAsync(sb.ToString());

        await transaction.CommitAsync();

    }
    catch (Exception)
    {
        await Console.Out.WriteLineAsync("ERROR");

        await transaction.RollbackAsync();
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