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
        private static IDatabase instance2;
        private static IDatabase instance4ThreadGetMaxId;

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
        public static IDatabase Instance2
        {
            get
            {
                if (instance2 == null)
                {
                    throw new Exception("Object not created");
                }
                return DatabaseFactory.instance2;
            }
        }

        public static IDatabase Instance4ThreadGetMaxId
        {
            get
            {
                if (instance4ThreadGetMaxId == null)
                {
                    throw new Exception("Object not created");
                }
                return DatabaseFactory.instance4ThreadGetMaxId;
            }
        }
        
        
        public static void CreateNewDatabase(string kindOfDatabase,DbConStringBuilder strBuilder)
        {
            //if else here
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            StringBuilderCopy(strBuilder, stringBuilder);
            instance = new MySqlDatabase(stringBuilder.ConnectionString + ';' + "charset = utf8;");
            instance2 = new MySqlDatabase(stringBuilder.ConnectionString + ';' + "charset = utf8;");
            instance4ThreadGetMaxId = new MySqlDatabase(stringBuilder.ConnectionString + ';' + "charset = utf8;");
        }

        private static void StringBuilderCopy(DbConStringBuilder strBuilder, MySqlConnectionStringBuilder stringBuilder)
        {
            stringBuilder.Server = strBuilder.Server;
            stringBuilder.UserID = strBuilder.UserID;
            stringBuilder.Password = strBuilder.Password;
            stringBuilder.Database = strBuilder.Database;
        }

        private DatabaseFactory()
        {
            
        }



    }
}
