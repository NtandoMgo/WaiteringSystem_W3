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
        private string strConn = Settings.Default.EmpDbConStr;
        private SqlConnection cnMain;
        private DataSet dsMain;
        private SqlDataAdapter daMain;

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
                Console.WriteLine("an error occured in DB: "+ex);
            }
        }

    }
}
