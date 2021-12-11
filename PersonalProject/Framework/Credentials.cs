using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmailReader
{
    public class Credentials
    {
        Credentials()
        {

        }

        public static String GetCredentials()
        {
            String str = File.ReadAllText(Credentials.DocumentsFolder + @"HalBookApp\Credentials.txt").Replace("\n", "").Replace(" ", "");
            return str;
        }

        public static String emailFrom => GetCredentials().Split(',')[0];

        public static String SMTPEmail => GetCredentials().Split(',')[0];

        public static String SMTPPassword => GetCredentials().Split(',')[1];

        public static String homePath => Environment.GetEnvironmentVariable("HOMEPATH");

        public static String DocumentsFolder => @"C:\" + homePath + @"\Documents\";

    }
}
