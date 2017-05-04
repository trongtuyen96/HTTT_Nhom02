using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Nhom02
{
    class MonAnDAO : DataProvider
    {
        public ArrayList getDsMonAn()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from MonAn";
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                ArrayList ar = new ArrayList();


                foreach (DataRow row in sqlDataTable.Rows)
                {
                    MonAnDTO monAn = new MonAnDTO();
                    monAn.Id = row["id"].ToString();
                    monAn.TenMon = row["TenMon"].ToString();
                    monAn.Gia = double.Parse(row["Gia"].ToString());
                    ar.Add(monAn);
                }
                this.disconnect();
                return ar;
            }
            catch (Exception ex) { return null; }
        }
        //public bool themMonAn()
        //{
        //    this.connect();
        //    bool bCheck = true;

        //    string query = "INSERT INTO MonAn([id],[TenMon],[Gia]) VALUES(@ID,@TENMON,@GIA)";
        //    this.cm = new SqlCommand(query, cnn);
        //    this.cm.Parameters.Add(new SqlParameter("@ID", "5"));
        //    this.cm.Parameters.Add(new SqlParameter("@TENMON", "Salad"));
        //    this.cm.Parameters.Add(new SqlParameter("@GIA", 50000));
        //    try
        //    {
        //        this.cm.ExecuteNonQuery();
        //        this.disconnect();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.disconnect();
        //        bCheck = false;
        //        throw ex;
        //    }
        //    return bCheck;
        //}
    }
}
