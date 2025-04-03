using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace NEWCLASS
{
    public class ReviewDbContext
    {
        static SqlConnection connection = new SqlConnection("Data Source=LTIN593805;Initial Catalog=ReviewDatabase;Integrated Security=True;TrustServerCertificate=true");

        #region Connection
        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        #endregion

        #region Private Methods 
        private SqlParameter createSqlParameter(string name, object value)
        {
            SqlParameter objSqlParameter = new SqlParameter(name, value);
            return objSqlParameter;
        }
        public DataSet ConvertDataReaderToDataSet(SqlDataReader reader)
        {
            DataSet dataSet = new DataSet();
            do
            {
                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        string columnName = (string)dataRow["ColumnName"];
                        DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                        dataTable.Columns.Add(column);
                    }

                    dataSet.Tables.Add(dataTable);

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);
                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());
            return dataSet;
        }
        #endregion

        #region SQL Specific
        public int InsertUpdateOrDelete(string QueryOrSPName, nameValuePairList NameValuePairObject, bool IsSP = false)
        {
            SqlCommand cmdObject = new SqlCommand(QueryOrSPName, GetConnection());

            if (IsSP)
            {
                cmdObject.CommandType = CommandType.StoredProcedure;
            }

            foreach (nameValuePair objList in NameValuePairObject)
            {
                cmdObject.Parameters.Add(createSqlParameter(objList.ColName, objList.Value));
            }

            int status = 0;

            try
            {
                status = cmdObject.ExecuteNonQuery();
                return status;
            }
            catch (Exception exp)
            {
                // Log the exception (you can use a logging framework like Serilog or NLog)
                Console.WriteLine($"An error occurred: {exp.Message}");
                return status;
            }
            finally
            {
                CloseConnection();
            }
        }

        public object FetchScalar(string selectQuery, nameValuePairList nvpList)
        {
            SqlCommand command = new SqlCommand(selectQuery, GetConnection());
            foreach (var nvp in nvpList)
            {
                command.Parameters.Add(createSqlParameter(nvp.ColName, nvp.Value));
            }

            try
            {
                return command.ExecuteScalar();
            }
            catch (Exception exp)
            {
                // Log the exception (you can use a logging framework like Serilog or NLog)
                Console.WriteLine($"An error occurred: {exp.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int InsertUpdateOrDelete(string InsertQuery)
        {
            SqlCommand cmdObject = new SqlCommand(InsertQuery, GetConnection());

            int status = 0;

            try
            {
                status = cmdObject.ExecuteNonQuery();
                return status;
            }
            catch (Exception exp)
            {
                // Log the exception (you can use a logging framework like Serilog or NLog)
                Console.WriteLine($"An error occurred: {exp.Message}");
                return status;
            }
            finally
            {
                CloseConnection();
            }
        }

        public object FetchCount(string Query)
        {
            SqlCommand sqlCommand = new SqlCommand(Query, GetConnection());

            try
            {
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception exp)
            {
                // Log the exception (you can use a logging framework like Serilog or NLog)
                Console.WriteLine($"An error occurred: {exp.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet FillMultipleTables(string FirstQuery, string SecondQuery)
        {
            string Query = FirstQuery + ";" + SecondQuery;
            SqlCommand cmdObject = new SqlCommand(Query, GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmdObject);
            DataSet dsQuery = new DataSet();
            adapter.Fill(dsQuery);
            CloseConnection();
            return dsQuery;
        }

        public DataTable FillAndReturnDataTable(string SelectQuery, nameValuePairList nvpList = null)
        {
            SqlCommand cmdObject = new SqlCommand(SelectQuery, GetConnection());

            if (nvpList != null)
            {
                foreach (nameValuePair objList in nvpList)
                {
                    cmdObject.Parameters.Add(createSqlParameter(objList.ColName, objList.Value));
                }
            }

            SqlDataAdapter adp = new SqlDataAdapter(cmdObject);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            CloseConnection();
            return dt;
        }

        public DataTable FillAndReturnDataSet(string Query, nameValuePairList NameValuePairObject)
        {
            try
            {
                SqlCommand CommandObject = new SqlCommand(Query, GetConnection());

                foreach (nameValuePair objList in NameValuePairObject)
                {
                    CommandObject.Parameters.Add(createSqlParameter(objList.ColName, objList.Value));
                }

                SqlDataReader ReaderObject = CommandObject.ExecuteReader();
                DataSet ds = ConvertDataReaderToDataSet(ReaderObject);

                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework like Serilog or NLog)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet FillAndReturnDataSet(string Query)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Query, GetConnection());
            DataSet ds = new DataSet();
            adp.Fill(ds);
            CloseConnection();
            return ds;
        }
        #endregion
    }

    #region Name Value Pair and List...
    public class nameValuePairList : List<nameValuePair>
    {
    }

    public class nameValuePair
    {
        public string ColName { get; set; }
        public object Value { get; set; }
        public nameValuePair(string Name, object ColValue)
        {
            this.ColName = Name;
            this.Value = ColValue;
        }
    }
    #endregion
}
