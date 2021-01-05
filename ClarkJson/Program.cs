using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarkJson
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Environment.ExitCode = 0;
            //logger.Info("Starting STAR file generator...");


            //parse token string, singleSignonToken
            //{"singleSignonToken": "1bff67f8f1568004cc77810b",
            //"userId": "test/user"}
            string sst = "{\"singleSignonToken\":\"1bff67f8f1568004cc77810b\",\"userId\": \"test/user\"}";
            sst = sst.Substring(sst.IndexOf("singleSignonToken") + ("\"singleSignonToken\":").Length);
            sst = sst.Substring(0, sst.IndexOf("\",")).Replace("\"", "");
            Console.WriteLine(string.Format("singleSignonToken: {0}", sst));
        }
    }
}
