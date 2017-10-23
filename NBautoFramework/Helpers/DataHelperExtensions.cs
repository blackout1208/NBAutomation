using System;
using System.Data;
using System.Data.SqlClient;

namespace NBautoFramework.Helpers
{
    /// <summary>
    /// Extension for the database connection
    /// </summary>
    public static class DataHelperExtensions
    {

        /// <summary>
        /// Opens the connection
        /// </summary>
        /// <param name="sqlConnection">The sql connector</param>
        /// <param name="connectionString">The DB path.</param>
        /// <returns>The sql connecto ready to be used</returns>
        public static SqlConnection DBconnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                if (sqlConnection == null)
                {
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                }
                return sqlConnection;
            }
            catch (Exception e)
            {
                LogHelpers.Write("ERROR :: " + e.Message);
            }

            return null;
        }


        /// <summary>
        /// Closes the connection
        /// </summary>
        /// <param name="sqlConnection">The sql connector</param>
        private static void DBclose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                LogHelpers.Write("ERROR ::" + e.StackTrace);
            }
        }

        /// <summary>
        /// Executes the query to the database
        /// </summary>
        /// <param name="sqlConnection">The sql connector</param>
        /// <param name="query">The query to be executed in database</param>
        /// <returns>The result of the query.</returns>
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string query)
        {
            try
            {
                //Checking the state of the connection
                if (sqlConnection.State == ConnectionState.Broken || sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                var dataAdapter = new SqlDataAdapter
                {
                    SelectCommand = new SqlCommand(query, sqlConnection)
                    {
                        CommandType = CommandType.Text
                    }
                };

                var dataset = new DataSet();
                dataAdapter.Fill(dataset, "table");
                DBclose(sqlConnection);
                return dataset.Tables["table"];
            }
            catch (Exception e)
            {
                DBclose(sqlConnection);
                LogHelpers.Write("ERROR ::" + e.Message);
            }
            finally
            {
                DBclose(sqlConnection);
            }

            return null;
        }
    }
}
