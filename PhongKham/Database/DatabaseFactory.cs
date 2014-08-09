using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Clinic.Database
{
    public class DatabaseFactory
    {
        private static IDatabase instance;

        public static IDatabase Instance
        {
            get {
                if (instance == null)
                {
                    throw new Exception("Object not created");
                }
                return DatabaseFactory.instance; 
            }
        }
        
        public static void CreateNewDatabase(string kindOfDatabase,DbConStringBuilder strBuilder)
        {
            //if else here
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            StringBuilderCopy(strBuilder, stringBuilder);
            instance = new MySqlDatabase(stringBuilder.ConnectionString);
        }

        private static void StringBuilderCopy(DbConStringBuilder strBuilder, MySqlConnectionStringBuilder stringBuilder)
        {
            stringBuilder.Server = strBuilder.Server;
            stringBuilder.UserID = strBuilder.UserID;
            stringBuilder.Password = strBuilder.Password;
        }

        private DatabaseFactory()
        {
            
        }



    }
}
