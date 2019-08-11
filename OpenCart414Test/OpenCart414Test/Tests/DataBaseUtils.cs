using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart414Test
{
    public  sealed class DataBaseUtils
    {
 /*   private static readonly string DataBase_Partial_Url = "172.20.10.2";
        private readonly string Db_Url;
    private readonly string HOST = "172.20.10.2";  // IP-adress of remote server.
    private readonly int PORT = 22;                    // Remote server port.
    private readonly string NAME = "root";             // Linux profile name.
    private readonly string PASSWORD = "root";         // Linux password.

        private SqlConnection connection = new SqlConnection();


        public DataBaseUtils()
        {
            
        }
        public void openConnection()
        {
            try
            {
              //  connection.ConnectionString();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /*  private void Connetion()
          {
              string ConnetionString;
              SqlConnection cnn;
              ConnetionString = @"Data Source=172.20.10.2;Initial Catalog=opencard;User ID=lv414;Password=lv414_TAQC";
              cnn = new SqlConnection(ConnetionString);
              cnn.Open();
              cnn.Close();
          }*/
    }
}
