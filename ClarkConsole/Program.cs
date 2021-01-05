using ClarkLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Tao_Folder\About_Work\CES\test\input\";
            string filename = @"C:\Tao_Folder\About_Work\CES\test\output\ConcatenatedDocument333.pdf";
            if (File.Exists(filename))
                File.Delete(filename);

            PdfProcessor.MergeMultiplePDFIntoSinglePDF(filename, inputPath);
            // ...and start a viewer.
            Process.Start(filename);


            //SQL_SP_HelpText helpText = new SQL_SP_HelpText();
            ////string connectionString = "Data Source=COSAPXDEV10;SERVER=COSAPXDEV10;User ID=sa;Initial Catalog=$(Catalog);Password=Advent.sa;pooling=yes;Max Pool Size=1110;Connection Lifetime=680;Connect Timeout=660";
            //helpText.SP_HelpText("", "", true);



            //DateMatters();

            //TestDoubleFormat();

            //Test("(if (any? x) sum (/1 x))");
            //Test(":-)");
            //Test(@"I said(it's not (yet) complete). (she didn't listen)");
            //Test("())(");
            //Test(null);
            //Test("");
            //Test("(())()");
            //Test(@"I said(it's not (yet) complete). (she didn't (listen)");
            //Console.ReadLine();
        }

        private static void TestDoubleFormat()
        {
            double d = 99.9999;
            FriendlyAmount(d, 10, 2);
            d = 10;
            FriendlyAmount(d, 10, 2);
            d = 10.00999000;
            FriendlyAmount(d, 10, 2);
            d = 1998859560.00999000;
            FriendlyAmount(d, 10, 2);
            d = 1234567890123456.00999000;
            FriendlyAmount(d, 10, 2);
        }

        private static void DateMatters()
        {
            DateTime dateTimeNow = DateTime.Now;
            DateTime theDay = new DateTime(2016, 5, 22);
            //DateTime theDay2 = new DateTime(2019, 1, 9);
            TimeSpan ts = dateTimeNow.Subtract(theDay);

            Console.WriteLine("Days: {0}", ts.Days);
        }

        private static string FriendlyAmount(double amount, int precision, int zeroCount)
        {
            Console.WriteLine(amount);
            string formatedAmount = amount.ToString("N" + precision);
            if (precision <= zeroCount)
                return formatedAmount;

            for (int i = 0; i < precision - zeroCount; i++)
            {
                if (formatedAmount[formatedAmount.Length - 1] == '0')
                {
                    formatedAmount = formatedAmount.Remove(formatedAmount.Length - 1);
                    Console.WriteLine("{0}: {1}", i, formatedAmount);
                }
                else
                    break;
            }

            return formatedAmount;
        }

        static void Test(string str)
        {
            if (DELL.VerifyParenthesesBalancing(str))
                Console.WriteLine("True: " + str);
            else
                Console.WriteLine("False: " + str);
        }
    }
}
