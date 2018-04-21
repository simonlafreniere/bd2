using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public void getClients(/*ref int[] idclients, ref string[] nomclients, ref string[] prenomclients*/)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandText = "pr_get_clients";
                cmd.CommandType = CommandType.StoredProcedure;

                OracleDataReader reader;

                OracleParameter client=new OracleParameter("clientid", OracleDbType.Int32);
                client.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(client);

                OracleParameter nom = new OracleParameter("lenom", OracleDbType.Varchar2);
                client.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(nom);

                OracleParameter prenom = new OracleParameter("leprenom", OracleDbType.Int32);
                client.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(prenom);
                
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetValue(0));
                }
                //cmd.ExecuteNonQuery();
                reader.Close();
                connection.Close();
            }
        }
    }
}
