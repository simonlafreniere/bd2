using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Oracle.ManagedDataAccess.Client;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataAdapter = Oracle.ManagedDataAccess.Client.OracleDataAdapter;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;
using OracleParameter = Oracle.ManagedDataAccess.Client.OracleParameter;

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

        public void reserver(int idclient, int idchambre, DateTime debut, DateTime fin)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = "pr_reservation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("leclient", OracleDbType.Int32).Value = idclient;
                cmd.Parameters.Add("lachambre", OracleDbType.Int32).Value = idchambre;
                cmd.Parameters.Add("ledebut", OracleDbType.Date).Value = debut;
                cmd.Parameters.Add("lafin", OracleDbType.Date).Value = fin;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }


        // retourne un DataSet avec le contenu d'une procedure qui retourne plusieurs résultats
        public DataSet GetSelectProc(string Nom_Procedure)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                DataSet dataset = new DataSet();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = Nom_Procedure;
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter curseur =
                    new OracleParameter("curseur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(curseur);
                connection.Open();
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(dataset);

                cmd.Dispose();
                connection.Close();
                return dataset;
            }
        }

        public DataSet getClients()
        {
            DataSet dataset = new DataSet();
            OracleConnection myBD = new OracleConnection(connectionString);
            dataset = GetSelectProc("pr_get_clients");

            return dataset;
        }

        public DataSet getChambres()
        {
            DataSet dataset = new DataSet();
            OracleConnection myBD = new OracleConnection(connectionString);
            dataset = GetSelectProc("pr_get_chambres");

            return dataset;
        }
    }
}

