using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClarkLibrary
{
    public class SQL_SP_HelpText
    {
        public void SP_HelpText(bool noLimitations1, string outputFilePath, string connectionString)
        {
            string pattern = "\r\n[ \t]{0,}\r\n[ \t]{0,}\r\n[ \t]{0,}";

            StringBuilder trxGetViewSource = new StringBuilder();
            string sql;

            SqlConnection con = new SqlConnection(connectionString);
            SqlConnection con1 = new SqlConnection(connectionString);
            SqlConnection con3 = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            SqlCommand cmdproc = con1.CreateCommand();
            SqlCommand cmdClean = con3.CreateCommand();

            try
            {
                //string sqlRunBefore = File.ReadAllText("c:\\APICustomField_script0.sql");
                //cmdClean.CommandText = sqlRunBefore;
                //con3.Open();
                //cmdClean.ExecuteNonQuery();

                string sqlRunBefore = File.ReadAllText(@"C:\Tao\Others\Test\WenTaoTestSolution\ClarkLibrary\SQL\Script1.sql");
                //int effectedRows = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //conn.Open();
                    SqlCommand cmdd = new SqlCommand();
                    cmdd.Connection = conn;
                    try
                    {
                        String[] sqlArr = Regex.Split(sqlRunBefore.Trim(), "\r\n\\s*go", RegexOptions.IgnoreCase);
                        foreach (string strsql in sqlArr)
                        {
                            if (strsql.Trim().Length > 1 && strsql.Trim() != "\r\n")
                            {
                                cmdd.CommandText = strsql;
                                //effectedRows = cmdd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

                SqlParameter objname = new SqlParameter();
                SqlDataReader rst;
                SqlDataReader rstproc;

                cmd.CommandTimeout = (60 * 10) * 2;
                cmdproc.CommandTimeout = (60 * 10) * 2;

                cmdproc.CommandType = System.Data.CommandType.StoredProcedure;
                cmdproc.CommandText = "sp_helptext";
                objname.ParameterName = "@objname";
                objname.SqlDbType = System.Data.SqlDbType.VarChar;
                cmdproc.Parameters.Add(objname);

                sql = "";
                sql += "select sys.schemas.name+'.'+sys.objects.name as name, ";
                sql += "    Case Type";
                sql += " WHEN 'P' THEN 'Drop procedure '";
                sql += " WHEN 'V' THEN 'Drop View '";
                sql += " WHEN 'FN' THEN 'Drop function '";
                sql += " WHEN 'TR' THEN 'Drop trigger '";
                sql += " WHEN 'TF' THEN 'Drop function '"; // Table value function, added for [TRX-1304] Extended TrxGetViewSource to include table-value functions in 15.1 release
                sql += " WHEN 'IF' THEN 'Drop function '"; // Inline table value function, added for [TRX-1304] Extended TrxGetViewSource to include table-value functions in 15.1 release
                sql += " END AS DropText";
                sql += " from sys.objects";
                sql += " INNER JOIN sys.schemas ";
                sql += "  ON sys.objects.schema_id = sys.schemas.schema_id";

                sql += " where type in ('V','P','FN','TR', 'TF', 'IF')";
                sql += " and (sys.objects.name not like 'sys%' OR sys.objects.name like '%ystem_SpellTheNumber%' OR sys.objects.name like '%ystem_GetDefaultDepartmentID%' OR sys.objects.name like '%ystem_FriendlyAmount' or sys.objects.name like '%ystem_GetDefaultCountryID%' ) ";
                sql += " and sys.objects.name not like 'dt_%'";
                sql += " and sys.objects.name not like 'x_x_%'";
                sql += " and sys.objects.name not like 'fn_%'";
                sql += " and sys.objects.name not like 'cfv%'";
                sql += " AND sys.objects.name not like 'sp_dropdiagram%'";
                sql += " AND sys.objects.name not like 'sp_renamediagram%'";
                sql += " AND sys.objects.name not like 'sp_creatediagram%'";
                sql += " AND sys.objects.name not like 'sp_helpdiagram%'";
                sql += " AND sys.objects.name not like 'sp_upgraddiagrams%'";
                sql += " AND sys.objects.name not like 'Order_GetOrderInfoActionRule_archive%'";
                sql += " AND sys.objects.name not like 'Order_GetOrderInfoAxysTransactions_archive%'";
                sql += " AND sys.objects.name not like 'x_v_cashtransactions_archive%'";
                sql += " AND sys.objects.name not like 'Order_GetOrderInfoCashTransactions_archive%'";
                sql += " AND sys.objects.name not like 'Finance_Transactions_List_archive%'";
                sql += " AND sys.objects.name not like 'Order_GetOrderInfoFinanceTransactions_archive%'";
                sql += " AND sys.objects.name not like 'Order_GetOrderInfoOrderDetails_archive%'";
                sql += " AND sys.objects.name not like 'Order_GetOrderInfoOrderStatusHist_archive%'";
                sql += " AND sys.objects.name not like 'x_v_Payments_archive%'";
                sql += " AND sys.objects.name not like 'Order_GetOrderInfoPaymentTransactions_archive%'";
                sql += " AND sys.objects.name not like 'Portfolio_GetOneExportTransaction_archive%'";
                sql += " AND sys.objects.name not like 'x_v_OrderExternal_A%'";
                sql += " AND sys.objects.name not like 'x_v_Payment_archive%'";
                sql += " AND sys.objects.name not like 'x_t_OrderTrail_archive%'";
                sql += " AND sys.objects.name not like 'x_v_orderstatusdata_archive%'";
                sql += " AND sys.objects.name not like 'x_T_UserSharingTrail_archive%'";

                sql += " AND NOT (sys.objects.name like '%CustomField' and sys.schemas.name = 'TRXApi')";

                if (!noLimitations1)
                {
                    sql += " AND sys.objects.name not like 'NPO_%'";
                    sql += " AND sys.objects.name not like 'AMALTA_%'";
                    sql += " AND sys.objects.name not like 'GPS_%'";
                    sql += " AND sys.objects.name not like 'ACTA_%'";
                    sql += " AND sys.objects.name not like 'TEST_%'";
                    sql += " AND sys.objects.name not like 'SSB_%'";
                    sql += " AND sys.objects.name not like 'Formue_%'";
                    sql += " AND sys.objects.name not like 'spx_acta_%'";
                    sql += " AND sys.objects.name not like 'sp_alterdiagram%'";
                    sql += " AND sys.objects.name not like '%tradestore%'";
                    sql += " AND sys.objects.name not like 'Orkla_%'";
                    sql += " AND sys.objects.name not like 'Dimension_%'";
                    sql += " AND sys.objects.name not like 'SNS_%'";
                    // sql += " AND  (sys.objects.name not like 'GenericScreen_%' OR sys.objects.name like '%enericScreen_products' OR sys.objects.name like '%enericScreen_Transaction%') ";
                    sql += " AND sys.objects.name not like 'OF_%'";
                    sql += " AND sys.objects.name not like 'FPB_%'";
                    sql += " AND sys.objects.name not like 'First[_]%'";
                    sql += " AND sys.objects.name not like 'Catella_%'";
                    sql += " AND sys.objects.name not like '%abasec_%'";
                    sql += " AND sys.objects.name not like 'Cat[_]%'";
                    sql += " AND sys.objects.name not like 'PAR[_]%'";
                    sql += " AND sys.objects.name not like 'SB1[_]%'";

                    sql += " AND sys.objects.name not like 'X_V_STandardCrmT;oTradex'";
                    sql += " AND sys.objects.name not like 'sp_StandardCrmToTradex'";
                    sql += " AND sys.objects.name not like 'Custom[_]%'";
                    sql += " AND sys.objects.name not like 'OPT[_]%'";
                }

                sql += " order by type desc";
                cmd.CommandText = sql;

                //con.Open();
                //con1.Open();

                rst = cmd.ExecuteReader();
                while (rst.Read())
                {
                    objname.Value = rst["name"].ToString();
                    if (rst["name"].ToString().Contains("GetFinanceDate"))
                    {
                        trxGetViewSource.Append(" ");
                    }
                    trxGetViewSource.Append("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'" + rst["name"] + "') )  " + rst["DropText"] + " " + rst["name"].ToString().Insert(rst["name"].ToString().LastIndexOf(".") + 1, "[") + "]" + "" + "\r\n\r\nGO\r\n\r\n\r\n\r\n" + "" + "");
                    rstproc = cmdproc.ExecuteReader();
                    while (rstproc.Read())
                    {
                        trxGetViewSource.Append(rstproc[0].ToString());
                    }
                    rstproc.Close();
                    trxGetViewSource.Append("" + "\r\n\r\nGO\r\n\r\n\r\n\r\n" + "");
                }
                rst.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
                cmd = null;
                cmdproc.Connection.Close();
                cmdproc.Dispose();
                cmdproc = null;
                cmdClean.Connection.Close();
                cmdClean.Dispose();
                cmdClean = null;
            }

            string readyToFile = trxGetViewSource.ToString();

            // remove empty lines
            while (Regex.IsMatch(readyToFile, pattern))
                readyToFile = Regex.Replace(readyToFile, pattern, "\r\n\r\n");

            File.WriteAllText(outputFilePath, readyToFile);
        }

        public void SP_HelpText(string inputFilePath, string outputFileDir, bool subfolder = true)
        {
            if (string.IsNullOrEmpty(outputFileDir))
                outputFileDir = @"C:\Users\twen\source\repos\ClarkApp\ClarkLibrary\SQL\Output\";
            if (string.IsNullOrEmpty(inputFilePath))
                inputFilePath = @"C:\Users\twen\source\repos\ClarkApp\ClarkLibrary\SQL\Script1.sql";

            string fileList = "";
            string sqlRunBefore = File.ReadAllText(inputFilePath);

            try
            {
                String[] sqlArr = Regex.Split(sqlRunBefore.Trim(), "\r\n\\s*go\r\n", RegexOptions.IgnoreCase);
                string readyToFile = "";
                string path = outputFileDir;

                foreach (string strsql in sqlArr)
                {
                    if (strsql.Trim().Length > 1 && strsql.Trim() != "\r\n")
                    {
                        readyToFile += strsql.Trim();
                        if (readyToFile.ToUpper().Contains("DROP "))
                        {
                            readyToFile += "\r\nGO\r\n";
                            if (readyToFile.ToUpper().Contains("CREATE "))
                            {
                                path = getFileName(readyToFile, subfolder);
                                fileList += path + "\r\n";

                                path = outputFileDir + path;
                                if (!File.Exists(path))
                                {
                                    File.WriteAllText(path, readyToFile);
                                    //System.Threading.Thread.Sleep(500);
                                }
                                readyToFile = "";
                            }
                        }
                    }
                }
                File.WriteAllText(outputFileDir + "_AList.lst", fileList);
            }
            catch (Exception ex)
            {
                File.WriteAllText(outputFileDir + "_AList.lst", ex.Message + "\r\n" + fileList);
                throw;
            }
        }

        private string getFileName(string script, bool subfolder = true)
        {
            string keyWords = "CREATE VIEW";
            string theName = "";
            string exception1 = "'CREATE VIEW '";

            if (script.ToUpper().IndexOf("CREATE PROCEDURE") > 0 || script.ToUpper().IndexOf("CREATE  PROCEDURE") > 0)
            {
                if (script.ToUpper().IndexOf("CREATE PROCEDURE") > 0)
                    keyWords = "CREATE PROCEDURE";
                else if (script.ToUpper().IndexOf("CREATE  PROCEDURE") > 0)
                    keyWords = "CREATE  PROCEDURE";
                //CREATE PROCEDURE [dbo].[TRXRecompileSPs] AS
                //CREATE PROCEDURE Availability_GetUserAvailableCountries (@UserID INT)
                //CREATE PROCEDURE Availability_GetUserAvailableCountries @UserID INT
                //CREATE PROCEDURE FinanceCalendar_GetDays(@FromDate smalldatetime, @ToDate smalldatetime)   
                theName = script.Substring(script.ToUpper().IndexOf(keyWords) + keyWords.Length).Trim();
                if (script.ToUpper().IndexOf("AS") > 0)
                {
                    theName = theName.Substring(0, theName.ToUpper().IndexOf("AS")).Trim();
                }
                if (theName.ToUpper().IndexOf("(") > 0)
                {
                    theName = theName.Substring(0, theName.IndexOf("("));
                }
                if (theName.ToUpper().IndexOf("@") > 0)
                {
                    theName = theName.Substring(0, theName.IndexOf("@"));
                }
                if (!theName.Contains("."))
                    theName = "dbo." + theName;
                if (subfolder)
                    theName = "Procedure\\" + theName; ;
            }
            else if (script.ToUpper().IndexOf("CREATE PROC") > 0 || script.ToUpper().IndexOf("CREATE  PROC") > 0)
            {
                if (script.ToUpper().IndexOf("CREATE PROC") > 0)
                    keyWords = "CREATE PROC";
                else if (script.ToUpper().IndexOf("CREATE  PROC") > 0)
                    keyWords = "CREATE  PROC";
                //CREATE PROC Connectivity_GetPurchaseOrders
                //AS
                theName = script.Substring(script.ToUpper().IndexOf(keyWords) + keyWords.Length).Trim();
                if (script.ToUpper().IndexOf("AS") > 0)
                {
                    theName = theName.Substring(0, theName.ToUpper().IndexOf("AS")).Trim();
                }
                if (theName.ToUpper().IndexOf("(") > 0)
                {
                    theName = theName.Substring(0, theName.IndexOf("("));
                }
                if (theName.ToUpper().IndexOf("@") > 0)
                {
                    theName = theName.Substring(0, theName.IndexOf("@"));
                }
                if (!theName.Contains("."))
                    theName = "dbo." + theName;
                if (subfolder)
                    theName = "Procedure\\" + theName; ;
            }
            else if ((script.ToUpper().IndexOf("CREATE VIEW") > 0 || script.ToUpper().IndexOf("CREATE  VIEW") > 0) && script.ToUpper().IndexOf(exception1) < 0)
            {
                //CREATE VIEW [dbo].[v_Orders]
                if (script.ToUpper().IndexOf("CREATE VIEW") > 0)
                    keyWords = "CREATE VIEW";
                else if (script.ToUpper().IndexOf("CREATE  VIEW") > 0)
                    keyWords = "CREATE  VIEW";
                theName = script.Substring(script.ToUpper().IndexOf(keyWords) + keyWords.Length).Trim();
                if (theName.ToUpper().IndexOf(" AS") > 0 && theName.ToUpper().IndexOf(" AS") < theName.IndexOf("\r\n"))
                    theName = theName.Substring(0, theName.ToUpper().IndexOf(" AS"));
                else
                    theName = theName.Substring(0, theName.IndexOf("\r\n"));
                if (!theName.Contains("."))
                    theName = "dbo." + theName;
                if (subfolder)
                    theName = "View\\" + theName;
            }
            else if (script.ToUpper().IndexOf("CREATE TRIGGER") > 0 || script.ToUpper().IndexOf("CREATE  TRIGGER") > 0)
            {
                if (script.ToUpper().IndexOf("CREATE TRIGGER") > 0)
                    keyWords = "CREATE TRIGGER";
                else if (script.ToUpper().IndexOf("CREATE  TRIGGER") > 0)
                    keyWords = "CREATE  TRIGGER";
                //CREATE Trigger [dbo].[TRG_SYSTEM_SET_COUNTRY_CODE] ON [dbo].[TRX_SYSTEM]
                theName = script.Substring(script.ToUpper().IndexOf(keyWords) + keyWords.Length).Trim();
                theName = theName.Substring(0, theName.IndexOf("ON"));
                if (!theName.Contains("."))
                    theName = "dbo." + theName;
                if (subfolder)
                    theName = "Trigger\\" + theName; ;
            }
            else if (script.ToUpper().IndexOf("CREATE FUNCTION") > 0 || script.ToUpper().IndexOf("CREATE  FUNCTION") > 0)
            {
                if (script.ToUpper().IndexOf("CREATE FUNCTION") > 0)
                    keyWords = "CREATE FUNCTION";
                else if (script.ToUpper().IndexOf("CREATE  FUNCTION") > 0)
                    keyWords = "CREATE  FUNCTION";
                //CREATE FUNCTION [dbo].[GoSystem_SplitString](@RowData nvarchar(Max),@SplitOn nvarchar(5)) 
                theName = script.Substring(script.ToUpper().IndexOf(keyWords) + keyWords.Length).Trim();
                theName = theName.Substring(0, theName.IndexOf("("));
                if (!theName.Contains("."))
                    theName = "dbo." + theName;
                if (subfolder)
                    theName = "Function\\" + theName; ;
            }

            return theName.Replace("[", "").Replace("]", "").Trim() + ".sql";
        }
    }
}
