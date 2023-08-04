using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FYPfinalWEBAPP.Models
{
    public class Helpers
    {
        public static string? GetRDSConnectionString()
        {
            var appConfig = System.Configuration.ConfigurationManager.AppSettings;

            string dbname = appConfig["ebdb"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["admin"];
            string password = appConfig["admin1234"];
            string hostname = appConfig["awseb-e-m3jq2k9gac-stack-awsebrdsdatabase-xdmq7oxx8w0j.c3lcvebmhspk.ap-southeast-1.rds.amazonaws.com"];
            string port = appConfig["1433"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}