using System;
using System.Data;
using System.Data.SqlClient;
using AdoNet.Data;

namespace GetNameAndDescriptionFromCategories
{
    class Program
    {
        static void Main()
        {
            string query = "SELECT CategoryName, Description from [dbo].[Categories]";
            boFunctions.ExecuteSqlQueryReturnValue(query, null, CommandType.Text, Action);
        }

        private static void Action(SqlDataReader sqlDataReader)
        {
            while (sqlDataReader.Read())
            {
                Console.WriteLine("CategoryName: {0}\nDesccription: {1}" + Environment.NewLine, sqlDataReader[0], sqlDataReader[1]);
            }
        }
    }
}
