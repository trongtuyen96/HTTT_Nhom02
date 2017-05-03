using System;
using System.Data;
using System.Data.SqlClient;

namespace Nhom02
{
    class NhanVienDAO : DataProvider
    {
        #region Constructor
        public NhanVienDAO()
        {
        }
        #endregion

        #region Methods
        public DataTable Search()
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from NhanVien";
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
