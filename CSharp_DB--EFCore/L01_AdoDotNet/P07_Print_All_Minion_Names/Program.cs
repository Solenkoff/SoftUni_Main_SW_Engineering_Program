using System.Data.SqlClient;

const string GetAllMinions = @"SELECT Name FROM Minions";


const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";

using SqlConnection? sqlConnection = new SqlConnection(connectionString);

try
{
    await sqlConnection.OpenAsync();

    using SqlCommand cmdPrintMinions = new(GetAllMinions, sqlConnection);
    using SqlDataReader reader = await cmdPrintMinions.ExecuteReaderAsync();
    List<string> allMinions = new List<string>();

    while (await reader.ReadAsync())
    {
        allMinions.Add($"{reader["Name"].ToString()}");
    }

    for (int first = 0, last = allMinions.Count - 1; first <= last; first++, last--)
    {
        await Console.Out.WriteLineAsync($"{allMinions[first]}");

        if (last != first)
        {
            await Console.Out.WriteLineAsync($"{allMinions[last]}");
        }
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