using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Nhom02
{
    class ThucDonDAO: DataProvider
    {
        public DataTable LoadThucDon(DateTime date)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "SELECT idMonAn,TenMon,SoLuong FROM MonAn,CT_ThucDon WHERE([Ngay] = @NGAY) and idMonAn=id";
            cm.Parameters.Add(new SqlParameter("@NGAY", date));
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }
        public bool traCuuTD(DateTime date)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "SELECT * FROM ThucDon WHERE([Ngay] = @NGAY)";
            cm.Parameters.Add(new SqlParameter("@NGAY", date));
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable.Rows.Count == 0 ? false : true;
            }
            catch (Exception ex) { return false; }
        }

        public bool themTD(DateTime ngayTD)
        {
            this.connect();
            bool bCheck = true;

            string query = "INSERT INTO ThucDon([Ngay]) VALUES(@NGAY)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@NGAY", ngayTD.ToShortDateString().ToString()));

            try
            {
                this.cm.ExecuteNonQuery();
                this.disconnect();
            }
            catch (Exception ex)
            {
                this.disconnect();
                bCheck = false;
                throw ex;
            }
            return bCheck;
        }
    }
}
