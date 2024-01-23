using System.Data.SqlClient;

const string GetTownId = @"SELECT Id FROM Towns WHERE Name = @townName";
const string CreateTown = @"INSERT INTO Towns ([Name]) OUTPUT inserted.Id VALUES (@townName)";
const string GetVillainId = @"SELECT Id FROM Villains WHERE Name = @Name";
const string CreateVillain =
    @"INSERT INTO Villains ([Name], EvilnessFactorId) OUTPUT inserted.Id VALUES (@villainName, @evilnessFactor)";
const string CreateMinion =
    @"INSERT INTO Minions(Name, Age, TownId) OUTPUT inserted.Id VALUES(@name, @age, @townId)";
const string MapingMinionsVillains =
    @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";



const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";

using SqlConnection? sqlConnection = new SqlConnection(connectionString);

try
{
    await sqlConnection.OpenAsync();

    string minionInfo = Console.ReadLine();           
    string villainInfo = Console.ReadLine(); 

    SqlTransaction transaction = sqlConnection.BeginTransaction();

    string[] minionData = minionInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string[] villainData = villainInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string minionName = minionData[1];
    int minionAge = int.Parse(minionData[2]);
    string townName = minionData[3];
    string villainName = villainData[1];

    try
    {
        #region Town

        using SqlCommand getTownId = new SqlCommand(GetTownId, sqlConnection, transaction);
        getTownId.Parameters.AddWithValue("@townName", townName);
        var townResult = await getTownId.ExecuteScalarAsync();

        int townId = -1;
        if (townResult is null)
        {
            using SqlCommand cmdCreateTown = new(CreateTown, sqlConnection, transaction);
            cmdCreateTown.Parameters.AddWithValue("@townName", townName);
            townId = Convert.ToInt32(await cmdCreateTown.ExecuteScalarAsync());

            await Console.Out.WriteLineAsync($"Town {townName} was added to the database.");
        }
        else
        {
            townId = (int)townResult;
        }

        #endregion


        #region Villain

        using SqlCommand getVillainId = new SqlCommand(GetVillainId, sqlConnection, transaction);
        getVillainId.Parameters.AddWithValue("@Name", villainName);
        var villainResult = await getVillainId.ExecuteScalarAsync();

        int villainId = -1;
        if (villainResult is null)
        {
            using SqlCommand cmdCreateVillain = new(CreateVillain, sqlConnection, transaction);
            cmdCreateVillain.Parameters.AddWithValue("@villainName", villainName);
            cmdCreateVillain.Parameters.AddWithValue("@evilnessFactor", 4);
            villainId = Convert.ToInt32(await cmdCreateVillain.ExecuteScalarAsync());

            await Console.Out.WriteLineAsync($"Villain {villainName} was added to the database.");
        }
        else
        {
            villainId = (int)villainResult;
        }

        #endregion


        #region Minion


        using SqlCommand cmdCreateMinion = new(CreateMinion, sqlConnection, transaction);
        cmdCreateMinion.Parameters.AddWithValue("@name", minionName);
        cmdCreateMinion.Parameters.AddWithValue("@age", minionAge);
        cmdCreateMinion.Parameters.AddWithValue("@townId", townId);

        int minionId = Convert.ToInt32(await cmdCreateMinion.ExecuteScalarAsync());

        using SqlCommand cmdMaping = new SqlCommand(MapingMinionsVillains, sqlConnection, transaction);
        cmdMaping.Parameters.AddWithValue("@minionId", minionId);
        cmdMaping.Parameters.AddWithValue("@villainId", villainId);
        await cmdMaping.ExecuteNonQueryAsync();

        await Console.Out.WriteLineAsync($"Successfully added {minionName} to be minion of {villainName}.");


        #endregion

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