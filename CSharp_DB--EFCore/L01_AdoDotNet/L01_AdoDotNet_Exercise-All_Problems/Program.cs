
using L02_AdoDotNet_Exercise;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

internal class Program

//   1 - Connection String
//   2 - SQL Connection
//   3 - SQL Command
//   4 - SQL DataReader
{
    //   1 - Connection String
    const string connectionString = "Server=.;Database=MinionsDB;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=True;";
    static SqlConnection? sqlConnection;

    static async Task Main(string[] args)
    {

        //   2 - SQL Connection
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //await GetVillainsWithNumberOfMinions();                //   P02

            //await GetOrderedMinionsByVilainId(1);                  //   P03
            //await GetOrderedMinionsByVilainId(8);                  //

            //string minionInfoInput = Console.ReadLine();           //   P04
            //string villainInfoInput = Console.ReadLine();          //
            //await AddMinion(minionInfoInput, villainInfoInput);    //

            //string countryNameInput = Console.ReadLine();          //   P05
            //await ChangeTownNamesCasing(countryNameInput);         //

            //int villainId = int.Parse(Console.ReadLine());         //   P06
            //await RemoveVillain(villainId);                        //

            //await PrintAllMinionNames();                           //   P07

            //string minionIdsInput = Console.ReadLine();            //   P08
            //await IncreaseMinionAge(minionIdsInput);               //

            int minionAgeInput = int.Parse(Console.ReadLine());    //   P09
            await IncreaseAgeStoredProcedure(minionAgeInput);      //
        }
        finally
        {
            sqlConnection?.Close();
        }
    }

    //  --------------------------------------  
    //   P02_Villain_Names

    static async Task GetVillainsWithNumberOfMinions()
    {
        //   3 - SQL Command
        using SqlCommand getVillainsCommand = new SqlCommand(SqlQueries.GetVillainsWithNumberOfMinions, sqlConnection);

        //   4 - SQL DataReader
        using SqlDataReader sqlDataReader = await getVillainsCommand.ExecuteReaderAsync();

        while (await sqlDataReader.ReadAsync())
        {
            Console.WriteLine($"{sqlDataReader["Name"]} - {sqlDataReader["MinionsCount"]}");
        }
    }


    //  --------------------------------------  
    //   P03_Minion_Names

    static async Task GetOrderedMinionsByVilainId(int id)
    {
        using SqlCommand getVillainCommand = new SqlCommand(SqlQueries.GetVillainById, sqlConnection);
        getVillainCommand.Parameters.AddWithValue("@Id", id);
        var villain = await getVillainCommand.ExecuteScalarAsync();

        if (villain == null)
        {
            await Console.Out.WriteLineAsync($"No villain with ID {id} exists in the database.");
        }
        else
        {
            await Console.Out.WriteLineAsync($"Villain: {villain}");

            using SqlCommand getMinionsCommand = new SqlCommand(SqlQueries.GetOrderedMinionsByVilainId, sqlConnection);
            getMinionsCommand.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = await getMinionsCommand.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                await Console.Out.WriteLineAsync($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
            }

        }
    }


    //  --------------------------------------  
    //   P04_Add_Minion

    static async Task AddMinion(string minionInfo, string villainInfo)
    {
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

            using SqlCommand getTownId = new SqlCommand(SqlQueries.GetTownId, sqlConnection, transaction);
            getTownId.Parameters.AddWithValue("@townName", townName);
            var townResult = await getTownId.ExecuteScalarAsync();

            int townId = -1;
            if (townResult is null)
            {
                using SqlCommand cmdCreateTown = new(SqlQueries.CreateTown, sqlConnection, transaction);
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

            using SqlCommand getVillainId = new SqlCommand(SqlQueries.GetVillainId, sqlConnection, transaction);
            getVillainId.Parameters.AddWithValue("@Name", villainName);
            var villainResult = await getVillainId.ExecuteScalarAsync();

            int villainId = -1;
            if (villainResult is null)
            {
                using SqlCommand cmdCreateVillain = new(SqlQueries.CreateVillain, sqlConnection, transaction);
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


            using SqlCommand cmdCreateMinion = new(SqlQueries.CreateMinion, sqlConnection, transaction);
            cmdCreateMinion.Parameters.AddWithValue("@name", minionName);
            cmdCreateMinion.Parameters.AddWithValue("@age", minionAge);
            cmdCreateMinion.Parameters.AddWithValue("@townId", townId);

            int minionId = Convert.ToInt32(await cmdCreateMinion.ExecuteScalarAsync());

            using SqlCommand cmdMaping = new SqlCommand(SqlQueries.MapingMinionsVillains, sqlConnection, transaction);
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


    //  --------------------------------------  
    //   P05_Change_Town_Names_Casing

    static async Task ChangeTownNamesCasing(string countryName)
    {
        SqlTransaction transaction = sqlConnection.BeginTransaction();

        try
        {
            using SqlCommand cmdUpdateNames = new(SqlQueries.UPDATE_TOWN_CASING, sqlConnection, transaction);
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

            using SqlCommand cmdGetTownNames = new(SqlQueries.GET_TOWN_NAMES, sqlConnection, transaction);
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


    //  --------------------------------------  
    //   P06_Remove_Villain   *

    static async Task RemoveVillain(int villainId)
    {
        SqlTransaction transaction = sqlConnection.BeginTransaction();

        try
        {
            using SqlCommand cmdGetVillainName = new(SqlQueries.GetVillainName, sqlConnection, transaction);
            cmdGetVillainName.Parameters.AddWithValue("@villainId", villainId);
            var villainName = await cmdGetVillainName.ExecuteScalarAsync();

            if (villainName is null)
            {
                await Console.Out.WriteLineAsync("No such villain was found.");
                return;
            }

            StringBuilder sb = new StringBuilder();

            using SqlCommand cmdReleaseMinions =
                new(SqlQueries.ReleaseMinionsFromVillain, sqlConnection, transaction);
            cmdReleaseMinions.Parameters.AddWithValue("@villainId", villainId);
            int minionsReleased = await cmdReleaseMinions.ExecuteNonQueryAsync();

            using SqlCommand cmdDeleteVillain =
                new(SqlQueries.DeleteVillain, sqlConnection, transaction);
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


    //  --------------------------------------  
    //   P07_Print_All_Minion_Names   

    static async Task PrintAllMinionNames()
    {
        using SqlCommand cmdPrintMinions = new(SqlQueries.GetAllMinions, sqlConnection);
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


    //  --------------------------------------  
    //   P08_Increase_Minion_Age   

    static async Task IncreaseMinionAge(string minionIdsInput)
    {
        SqlTransaction transaction = sqlConnection.BeginTransaction();

        int[] minionIds = minionIdsInput
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        try
        {
            foreach (var id in minionIds)
            {
                using SqlCommand cmdUpdateMinion = new(SqlQueries.UpdateMinion, sqlConnection, transaction);
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

        using SqlCommand cmdPrintMinions = new(SqlQueries.GetAllMinionsAfterUpdate, sqlConnection, transaction);
        using SqlDataReader reader = await cmdPrintMinions.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            await Console.Out.WriteLineAsync($"{reader["Name"]} {reader["Age"]}");
        }

    }


    //  --------------------------------------  
    //   P09_Increase_Age_Stored_Procedure 

    static async Task IncreaseAgeStoredProcedure(int minionId)
    {
        SqlTransaction transaction = sqlConnection.BeginTransaction();

        try
        {
            using SqlCommand cmdCallUSP = new ("usp_GetOlder", sqlConnection, transaction);
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

        using SqlCommand cmdPrintMinion = new(SqlQueries.GetMinionDetails, sqlConnection);
        cmdPrintMinion.Parameters.AddWithValue("@Id", minionId);
        using SqlDataReader reader = await cmdPrintMinion.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            await Console.Out.WriteLineAsync($"{reader["Name"]} - {reader["Age"]} years old");
        }

    }

}