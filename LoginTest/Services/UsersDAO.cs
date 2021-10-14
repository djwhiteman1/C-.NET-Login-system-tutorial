using LoginTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTest.Services
{
    public class UsersDAO
    {

        String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Login test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool findUserByNameAndPassword(UserModel user) 
        {
            bool success = false;
            String sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        success = true;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
           
            return success;
        }
    }
}
