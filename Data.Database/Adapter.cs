using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";

        private SqlConnection _sqlConn;
        public SqlConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }

        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        protected void OpenConnection()
        {
            string Conn = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

            // ESTO ESTA MAL PERO FUNCIONA
            // PASO 10 11 12 LAB 05
            // SUPONGO QUE SE HACIA CON APP.CONFIG  COMO LO HICIMOS

            #region Hardcore ConnString
            // HARDCODEADO PARA TESTING

            // Santi - Lau
            //sqlConn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = tp2_net; Integrated Security = true");

            // Facu
            sqlConn = new SqlConnection("Data Source = localhost; Initial Catalog = tp2_net; Integrated Security = true");
            #endregion

            // Por App.config
             

            // sqlConn = new SqlConnection(Conn);

            sqlConn.Open();

            //throw new Exception("Metodo no implementado");
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;

            //throw new Exception("Metodo no implementado");
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
