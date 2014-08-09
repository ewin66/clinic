using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        
        public IDatabase CreateNewDatabase(string kindOfDatabase,string strCon)
        {
            //if else here
            instance = new MySqlDatabase(strCon);
            return instance;
        }

        private DatabaseFactory()
        {
            
        }



    }
}
