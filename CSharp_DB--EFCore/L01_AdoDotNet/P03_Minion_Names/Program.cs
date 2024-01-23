using System.Data.SqlClient;

const string GetVillainById = @"SELECT Name FROM Villains WHERE Id = @Id";

const string GetOrderedMinionsByVilainId =
    @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) 
                  AS RowNum,
                     m.Name,  
                     m.Age
                FROM MinionsVillains AS mv
                JOIN Minions As m ON mv.MinionId = m.Id
               WHERE mv.VillainId = @Id
            ORDER BY m.Name";


const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";

using SqlConnection? sqlConnection = new SqlConnection(connectionString);

try
{
    await sqlConnection.OpenAsync();

    int id = int.Parse(Console.ReadLine());

    using SqlCommand getVillainCommand = new SqlCommand(GetVillainById, sqlConnection);
    getVillainCommand.Parameters.AddWithValue("@Id", id);
    var villain = await getVillainCommand.ExecuteScalarAsync();

    if (villain == null)
    {
        await Console.Out.WriteLineAsync($"No villain with ID {id} exists in the database.");
    }
    else
    {
        await Console.Out.WriteLineAsync($"Villain: {villain}");

        using SqlCommand getMinionsCommand = new SqlCommand(GetOrderedMinionsByVilainId, sqlConnection);
        getMinionsCommand.Parameters.AddWithValue("@Id", id);
        using SqlDataReader reader = await getMinionsCommand.ExecuteReaderAsync();

        if(reader.HasRows == false)
        {
            await Console.Out.WriteLineAsync("(no minions)");
        }

        while (await reader.ReadAsync())
        {
            await Console.Out.WriteLineAsync($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
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