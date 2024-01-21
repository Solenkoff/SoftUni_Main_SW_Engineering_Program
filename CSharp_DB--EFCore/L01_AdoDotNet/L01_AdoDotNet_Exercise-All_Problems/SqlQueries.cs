namespace L02_AdoDotNet_Exercise
{
    using Microsoft.VisualBasic;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public static class SqlQueries
    {
        // P02
        public const string GetVillainsWithNumberOfMinions = 
            @"SELECT v.[Name]
            	   , COUNT(mv.MinionId) AS MinionsCount
                FROM Villains AS v
                JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
            GROUP BY v.[Name]
              HAVING COUNT(mv.MinionId) > 3
            ORDER BY MinionsCount DESC";


        // P03
        public const string GetVillainById = @"SELECT Name FROM Villains WHERE Id = @Id";

        public const string GetOrderedMinionsByVilainId = 
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) 
                  AS RowNum,
                     m.Name,  
                     m.Age
                FROM MinionsVillains AS mv
                JOIN Minions As m ON mv.MinionId = m.Id
               WHERE mv.VillainId = @Id
            ORDER BY m.Name";


        // P04
        public const string GetTownId = @"SELECT Id FROM Towns WHERE Name = @townName";
        public const string CreateTown = @"INSERT INTO Towns ([Name]) OUTPUT inserted.Id VALUES (@townName)";
        public const string GetVillainId = @"SELECT Id FROM Villains WHERE Name = @Name";
        public const string CreateVillain = 
            @"INSERT INTO Villains ([Name], EvilnessFactorId) OUTPUT inserted.Id VALUES (@villainName, @evilnessFactor)";
        public const string CreateMinion = 
            @"INSERT INTO Minions(Name, Age, TownId) OUTPUT inserted.Id VALUES(@name, @age, @townId)";
        public const string MapingMinionsVillains = 
            @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";


        // P05
        public const string UPDATE_TOWN_CASING = 
            @"UPDATE Towns
                 SET Name = UPPER(Name)
               WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string GET_TOWN_NAMES = 
            @"SELECT t.Name
                FROM Towns as t
                JOIN Countries AS c ON c.Id = t.CountryCode
               WHERE c.Name = @countryName";


        // P06
        public const string GetVillainName = @"SELECT Name FROM Villains WHERE Id = @villainId";
        public const string ReleaseMinionsFromVillain = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
        public const string DeleteVillain = @"DELETE FROM Villains WHERE Id = @villainId";


        // P07
        public const string GetAllMinions = @"SELECT Name FROM Minions";


        // P08
        public const string UpdateMinion = 
            @" UPDATE Minions
           SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
         WHERE Id = @Id";

        public const string GetAllMinionsAfterUpdate = @"SELECT Name, Age FROM Minions";


        // P09
        public const string Create_USP_GetOlder = @"GO
                                               CREATE PROC usp_GetOlder @id INT
                                                   AS
                                               UPDATE Minions
                                                  SET Age += 1
                                                WHERE Id = @id";

        public const string GetMinionDetails = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
        


    }
}
        
