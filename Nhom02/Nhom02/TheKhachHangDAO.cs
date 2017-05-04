using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Nhom02
{
    class TheKhachHangDAO : DataProvider
    {
        static string sMaThe;
        #region Constructor
        public TheKhachHangDAO()
        {
        }
        #endregion

        #region Methods
        public string LaySoMaThe()
        {
            sMaThe = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
            return sMaThe;
        }
        public bool Them(TheKhachHangDTO the)
        {
            this.connect();
            bool bCheck = true;
            string query = "INSERT INTO TheKhachHang([id],[HoTen],[SDT],[NgaySinh],[CMND],[DiemTichLuy])"
                + " VALUES(@ID,@HOTEN,@SDT,@NGAYSINH,@CMND,@DIEMTICHLUY)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", String.Concat("KH", sMaThe)));
            this.cm.Parameters.Add(new SqlParameter("@HOTEN", the.HoTen.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@SDT", the.SDT.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@NGAYSINH", the.NgaySinh.Date));
            this.cm.Parameters.Add(new SqlParameter("@CMND", the.CMND.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@DIEMTICHLUY", 20));
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

        //public bool CapNhat(TheKhachHangDTO the)
        //{
        //    this.connect();
        //    bool bCheck = true;
        //    string query = "UPDATE TheKhachHang SET [HoTen]=@HOTEN, [SDT]=@SDT, [NgaySinh]=@NGAYSINH, [CMND]=@CMND," +
        //        "[DiemTichLuy]=@DIEMTICHLUY where [id] = @ID";
        //    this.cm = new SqlCommand(query, cnn);
        //    this.cm.Parameters.Add(new SqlParameter("@HOTEN", the.HoTen.Trim()));
        //    this.cm.Parameters.Add(new SqlParameter("@SDT", the.SDT.Trim()));
        //    this.cm.Parameters.Add(new SqlParameter("@NGAYSINH", the.NgaySinh.Date));
        //    this.cm.Parameters.Add(new SqlParameter("@CMND", the.CMND.Trim()));
        //    this.cm.Parameters.Add(new SqlParameter("@DIEMTICHLUY", the.DiemTichLuy));
        //    this.cm.Parameters.Add(new SqlParameter("@ID", the.Id));
            
        //    try
        //    { this.cm.ExecuteNonQuery(); this.disconnect(); }
        //    catch (Exception ex) { this.disconnect(); bCheck = false; throw ex; }
        //    return bCheck;
        //}

        public DataTable LoadDuLieu()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "SELECT * FROM TheKhachHang";
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        //public DataTable TimKiemTuKhoa(string keyword, string category)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    string query = "";

        //    if (category == "Mã khách hàng")
        //    {
        //        query = "SELECT * FROM TheKhachHang WHERE id = @ID";
        //        cmd.CommandText = query;
        //        cmd.Parameters.AddWithValue("@ID", keyword);
        //    }
        //    else if (category == "Họ Tên")
        //    {
        //        query = "SELECT * FROM TheKhachHang WHERE HoTen like '%' + @HOTEN + '%'";
        //        cmd.CommandText = query;
        //        cmd.Parameters.AddWithValue("@HOTEN", keyword);
        //    }
        //    else if (category == "Số CMND")
        //    {
        //        query = "SELECT * FROM TheKhachHang WHERE CMND = @CMND";
        //        cmd.CommandText = query;
        //        cmd.Parameters.AddWithValue("@CMND", keyword);
        //    }
        //    else if (category == "Số điện thoại")
        //    {
        //        query = "SELECT * FROM TheKhachHang WHERE SDT = @SDT";
        //        cmd.CommandText = query;
        //        cmd.Parameters.AddWithValue("@SDT", keyword);
        //    }

        //    try
        //    {
        //        this.connect();
        //        DataTable sqlDataTable = this.ExecuteQuery_DataTable(cmd);
        //        this.disconnect();
        //        return sqlDataTable;
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        public bool Xoa(string idThe)
        {
            this.connect();
            bool bCheck = true;
            string query = "DELETE FROM TheKhachHang WHERE([id] = @ID)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", idThe));
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
        #endregion
    }
}
