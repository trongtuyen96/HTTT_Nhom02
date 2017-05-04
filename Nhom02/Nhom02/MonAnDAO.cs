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
                    monAn.Gia = int.Parse(row["Gia"].ToString());
                    ar.Add(monAn);
                }
                this.disconnect();
                return ar;
            }
            catch (Exception ex) { return null; }
        }

    }
}
