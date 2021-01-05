using System;
using System.Data;
using System.Data.OleDb;

namespace ExcelHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileName = @"C:\AboutWork\CES_Doc\[TRX] Project 54525 Optimum_SettlementAutomation\Optimum_Settled_03072020_061431.xlsx";
                ReadExcelFile(fileName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void ReadExcelFile(string filePath)
        {
            try
            {
                string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
                OleDbConnection conn = new OleDbConnection(connString);

                OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [Sheet0$]", conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                DataTable table = dataSet.Tables[0];


            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
