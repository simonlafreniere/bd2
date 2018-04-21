using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Oracle.ManagedDataAccess.Client;

namespace SMI1002_TP1
{
    class InterfaceBD
    {
        private const string DB_HOST = "neptune.uqtr.ca";
        private const int DB_PORT = 1521;
        private const string DB_SID = "coursbd";
        private const string DB_USERNAME = "SMI1002_09";
        private const string DB_PASSWORD = "67bdvm73";

        private string connectionString;
        //private OracleConnection connection;
        public InterfaceBD()
        {
            connectionString =
                $"Data source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST ={DB_HOST})(PORT = {DB_PORT}))" +
                $"(CONNECT_DATA = (SID ={DB_SID})));" +
                $"User Id = {DB_USERNAME}; Password = {DB_PASSWORD}";
        }

       
      
        /*
        public bool ouvrirConnexion()
        {
            try
            {
                connection.Open();
            }
            catch (OracleException e)
            {
                MessageBox.Show(e.Message, "Erreur lors de   l'ouverture de la connexion Oracle");
                return false;
            }

            return true;
        }

        public bool fermerConnexion()
        {
            try
            {
                connection.Close();
            }
            catch (OracleException e)
            {
                MessageBox.Show(e.Message, "Erreur lors de la fermeture de la connexion Oracle");
                return false;
            }
            return true;
        }

        public bool connexionEstOuverte()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                return true;

            return false;
        }*/

        public void insertData(string sql)
        {

            /*using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand("p", connection))
            {
                command.Parameters.Add(new OracleParameter("PRIX", 50));
                command.Parameters.Add(new OracleParameter("IDDORTOIR", 1));
                
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }*/
            OracleConnection connection = new OracleConnection(connectionString);
            //GIVE PROCEDURE NAME
            OracleCommand command = new OracleCommand("p", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("PRIX", 5000));
            command.Parameters.Add(new OracleParameter("IDDORTOIR", 1));

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

    }
}
