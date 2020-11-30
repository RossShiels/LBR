using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace LBR.DAL
{
    public static class DataAccess
    {       
        private static string _connectionString;
        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public static DataTable DataConnection(string sql)
        {
            if (sql == null || string.IsNullOrEmpty(_connectionString))
                return null;

            string connString = _connectionString;
            SqlConnection cnn;                               

            cnn = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(sql, cnn);
            DataTable dataTable = new DataTable();
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                cnn.Close();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return null;
            }

            return dataTable;
        }

    }
}
