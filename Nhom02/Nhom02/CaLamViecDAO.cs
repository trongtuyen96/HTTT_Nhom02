using System;
using System.Data;
using System.Data.SqlClient;

namespace Nhom02
{
    class CaLamViecDAO : DataProvider
    {
        #region Constructor
        public CaLamViecDAO()
        {
        }
        #endregion

        #region Methods
        public bool Save(CaLamViecDTO ca)
        {
            this.connect();
            bool bCheck = true;
            string query = "insert into CaLamViec([id],[Ngay],[Loai])"
                + " values(@ID,@NGAY,@LOAI)";
            this.cm = new SqlCommand(query, cnn);
            this.cm.Parameters.Add(new SqlParameter("@ID", ca.ID.Trim()));
            this.cm.Parameters.Add(new SqlParameter("@NGAY", ca.Ngay.Date));
            this.cm.Parameters.Add(new SqlParameter("@LOAI", ca.Loai.Trim()));
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

        public DataTable Search()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from CaLamViec";
            try
            {
                this.connect();
                DataTable sqlDataTable = this.ExecuteQuery_DataTable(cm);
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion
    }
}
