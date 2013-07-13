using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoNet.Data
{
    public static class boFunctions
    {
        //public static void ExecuteSqlFunction(string StoredPRocedure, Dictionary<string, string> parametters)
        //{
        //    using (SqlConnection oConn = new SqlConnection(dbSetting.Default.AdoNetConnectionString))
        //    {
        //        using (SqlCommand oRS = oConn.CreateCommand())
        //        {
        //            oConn.Open();
        //            oRS.CommandType = CommandType.StoredProcedure;
        //            oRS.CommandText = StoredPRocedure;
        //            if (parametters != null && parametters.Count > 0)
        //            {
        //                foreach (var parametter in parametters)
        //                {
        //                    oRS.Parameters.AddWithValue(parametter.Key, parametter.Value);
        //                }
        //            }
        //            oRS.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public static void ExecuteSqlFunctionReturnValue(string StoredPRocedure, Dictionary<string, string> parametters, Action<DataSet> action)
        //{
        //    using (SqlConnection oConn = new SqlConnection(dbSetting.Default.AdoNetConnectionString))
        //    {
        //        using (SqlCommand oRS = oConn.CreateCommand())
        //        {
        //            oConn.Open();
        //            oRS.CommandType = CommandType.StoredProcedure;
        //            oRS.CommandText = StoredPRocedure;
        //            if (parametters != null && parametters.Count > 0)
        //            {
        //                foreach (var parametter in parametters)
        //                {
        //                    oRS.Parameters.AddWithValue(parametter.Key, parametter.Value);
        //                }
        //            }

        //            var ds = new DataSet();
        //            var adapter = new SqlDataAdapter(oRS);
        //            adapter.Fill(ds);

        //            if (action != null)
        //            {
        //                action(ds);
        //            }
        //        }
        //    }
        //}



        public static void ExecuteSqlQueryInsert(string query, Dictionary<string, object> parametters, Action<int> action)
        {
            string keys = "";
            string values = "";

            if (parametters != null && parametters.Count > 0)
            {
                foreach (var parametter in parametters)
                {
                    if (keys == string.Empty)
                    {
                        keys += parametter.Key;
                        values += "@" + parametter.Key;
                    }
                    else
                    {
                        keys += ", " + parametter.Key;
                        values += ", @" + parametter.Key;
                    }
                }
            }

            query += "(" + keys + ") VALUES (" + values + ") SET @ID = @@Identity RETURN";

            RunSQLQueryWithReturnID(query, parametters, CommandType.Text, action);
        }

        public static void ExecuteSqlQueryUpdate(string query, Dictionary<string, object> parametters, Action<SqlDataReader> action)
        {
            string keys = "";
            if (parametters != null && parametters.Count > 0)
            {
                foreach (var parametter in parametters)
                {
                    if (keys == string.Empty)
                    {
                        keys += "[" + parametter.Key + "] = @" + parametter.Key;
                    }
                    else
                    {
                        keys += ", [" + parametter.Key + "] = @" + parametter.Key;
                    }
                }
            }

            query += " SET " + keys;

            ExecuteSqlQueryReturnValue(query, parametters, CommandType.Text, action);
        }

        private static void RunSQLQueryWithReturnID(string queryText, Dictionary<string, object> parametters, CommandType commandType, Action<int> action)
        {
            using (SqlConnection oConn = new SqlConnection(dbSetting.Default.AdoNetConnectionString))
            {
                using (SqlCommand oRS = oConn.CreateCommand())
                {
                    oConn.Open();
                    oRS.CommandType = commandType;
                    oRS.CommandText = queryText;
                    if (parametters != null && parametters.Count > 0)
                    {
                        foreach (var parametter in parametters)
                        {
                            oRS.Parameters.AddWithValue(parametter.Key, parametter.Value);
                        }
                    }

                    // output parameters
                    SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    oRS.Parameters.Add(param);

                    oRS.ExecuteNonQuery();

                    if (action != null)
                    {
                        action(int.Parse(oRS.Parameters["@ID"].Value.ToString()));
                    }
                }
            }
        }

        public static void ExecuteSqlQueryReturnValue(string queryText, Dictionary<string, object> parametters, CommandType commandType, Action<SqlDataReader> action)
        {
            using (SqlConnection oConn = new SqlConnection(dbSetting.Default.AdoNetConnectionString))
            {
                using (SqlCommand oRS = oConn.CreateCommand())
                {
                    oConn.Open();
                    oRS.CommandType = commandType;
                    oRS.CommandText = queryText;
                    if (parametters != null && parametters.Count > 0)
                    {
                        foreach (var parametter in parametters)
                        {
                            oRS.Parameters.AddWithValue(parametter.Key, parametter.Value);
                        }
                    }

                    SqlDataReader rdr = oRS.ExecuteReader(CommandBehavior.CloseConnection);
                    if (action != null)
                    {
                        action(rdr);
                    }
                }
            }
        }
    }
}
