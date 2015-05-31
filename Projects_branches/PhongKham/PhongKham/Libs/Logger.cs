using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Clinic.Helpers
{
    public class Logger
    {

        public static void Log(string function, string message)
        {

            using (StreamWriter sw = new StreamWriter("logs.txt", true))
            {
                sw.WriteLine(function + " : " + message);
            }


        }
    }
}
