using Microsoft.Data.SqlClient;

string connectionString = "Server=.;Database=SoftUni;User Id=sa;Password=MSSQL*Pass01;TrustServerCertificate=true;";

using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{
    await sqlConnection.OpenAsync();

    string query = "SELECT FirstName, LastName, Salary FROM Employees WHERE Salary > @salaryParam";

    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
    {
        sqlCommand.Parameters.AddWithValue("@salaryParam", 70000);
        using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
        {
            while (await sqlDataReader.ReadAsync())
            {
                string firstName = sqlDataReader["FirstName"].ToString();             //  = sqlDataReader[0].ToString();
                string lastName = sqlDataReader["LastName"].ToString();               //  = sqlDataReader[1].ToString();
                decimal salary = decimal.Parse(sqlDataReader["Salary"].ToString());   //  = decimal.Parse(sqlDataReader[2].ToString());

                Console.WriteLine($"{firstName} {lastName} - {salary:f2}");
            }
        }
    }
}



//  ---    WithOut Brackets -->  When having more nested UsingS    ---
//        ------------------------------------------------------

//using SqlConnection sqlConnection = new SqlConnection(connectionString);

//sqlConnection.Open();

//string query = "SELECT FirstName, LastName, Salary FROM Employees WHERE Salary > @salaryParam";

//using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

//sqlCommand.Parameters.AddWithValue("@salaryParam", 70000);
//using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

//while (sqlDataReader.Read())
//{
//    string firstName = sqlDataReader["FirstName"].ToString();
//    string lastName = sqlDataReader["LastName"].ToString();
//    decimal salary = decimal.Parse(sqlDataReader["Salary"].ToString());

//    Console.WriteLine($"{firstName} {lastName} - {salary:f2}");
//}

