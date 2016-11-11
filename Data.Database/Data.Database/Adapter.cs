using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        protected SqlConnection _sqlConn;
        public SqlConnection SqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }

        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";


        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        protected void OpenConnection()
        {
            string conectionString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConn = new SqlConnection(conectionString);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
