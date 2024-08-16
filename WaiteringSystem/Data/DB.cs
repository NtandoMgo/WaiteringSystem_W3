using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaiteringSystem.Properties;

namespace WaiteringSystem.Data
{
    internal class DB
    {
        #region Data fields
        private string strConn = Settings.Default.EmpDbConStr;
        private SqlConnection cnMain;
        private DataSet dsMain;
        private SqlDataAdapter daMain;
        #endregion

        #region Constructor
        public DB()
        {
            try
            {
                cnMain = new SqlConnection(strConn);    // Initialize the SqlConn object
                cnMain.Open(); // opening the connection... must close!!

                dsMain = new DataSet(); // initializing/create new dataset obj
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured in DB: " + ex);
            }
            finally { 
                cnMain.Close(); // since the FillDataSet opens the con and close it itself
            }
        }
        #endregion

        #region Methods
        public void FillDataSet(string aSQLstring, string aTable)
        {
            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);

                cnMain.Open();

                dsMain.Clear();
                daMain.Fill(dsMain, aTable);
            }
            catch (Exception errObj)
            {
                Console.WriteLine(errObj.Message + " " + errObj.StackTrace);
            }
        }

        public bool UpdateDataSource(string sqlLocal, string table)
        {
            bool successful = false;

            try
            {
                cnMain.Open();
                daMain.Update(dsMain, table);
                cnMain.Close();

                daMain.Fill(dsMain, table); // ?? Fill with SQl statement ??

                successful = true;
            }catch (Exception errObj)
            {
                Console.WriteLine(errObj.Message + " " + errObj.StackTrace);
                successful=false;
            }

            return successful;

        }
        #endregion
    }
}
