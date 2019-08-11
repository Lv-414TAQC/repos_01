using Cassandra;
using Microsoft.TeamFoundation.Build.WebApi;
using MySql.Data.MySqlClient;
using OpenCart414Test.Data;
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
        private const string SErver = "172.20.10.2";
        private const string DataBase = "opencart";
        private const string UID = "lv414";  
        private const string Password = "lv414_TAQC";                    

        private static MySqlConnection connection = new MySqlConnection();


        public DataBaseUtils()
        {
            OpenConnection();
        }
        public void OpenConnection()
        {
              MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = SErver;
                builder.UserID = UID;
                builder.Database = DataBase;
                builder.Password = Password;
                String connString = builder.ToString();
                builder = null;
            Console.WriteLine(connString);
            connection = new MySqlConnection(connString);
          
        }
         
        public bool IsEmailInDb(IUser user)
        {
            ResultSet rs = 0;
            bool InDb = false;
            try (PreparedStatement ps = connection.prepareStatement(SELECT_FIRST_USER)) {
                ps.setString(1, user.getEmail());
                rs = ps.executeQuery();
                while (rs.next())
                    if (rs.getString(7).equals(user.getEmail()))
                    {
                        inDb = true;
                    }
            } catch (SQLException e)
            {
                e.printStackTrace();
                return InDb;
        }

    }
}
