using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Nhom02
{
    class CTThucDonDAO : DataProvider
    {
        //public DataTable LoadThucDon()
        //{
        //    SqlCommand cm = new SqlCommand();
        //    cm.CommandText = "SELECT * FROM MonAn,CT_ThucDon";
        //    try
        //    {
        //        this.connect();
        //        DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
        //        this.disconnect();
        //        return sqlDataTable;
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        public bool themMonTD(ArrayList dsCTThucDon)
        {
            this.connect();
            bool bCheck = true;
            

            try
            {
                foreach (CTThucDonDTO ctThucDon in dsCTThucDon) {
                    string query = "INSERT INTO CT_ThucDon([Ngay],[IdMonAn],[SoLuong]) VALUES (@NGAY,@IDMONAN,@SOLUONG)";
                    this.cm = new SqlCommand(query, cnn);
                    this.cm.Parameters.Add(new SqlParameter("@NGAY", ctThucDon.Ngay));
                    this.cm.Parameters.Add(new SqlParameter("@IDMONAN", ctThucDon.IdMonAn));
                    this.cm.Parameters.Add(new SqlParameter("@SOLUONG", ctThucDon.SoLuong));
                    this.cm.ExecuteNonQuery();
                }
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
