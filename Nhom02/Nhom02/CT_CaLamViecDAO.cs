using System;
using System.Data;
using System.Data.SqlClient;

namespace Nhom02
{
    class CT_CaLamViecDAO : DataProvider
    {
        #region Constructor
        public CT_CaLamViecDAO()
        {
        }
        #endregion

        #region Methods
        public DataTable Search(string id)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from CT_CaLamViec where idCa=@ID";
            cm.Parameters.AddWithValue("@ID", id);
            try
            {
                this.connect();
                DataTable sqlDataTable = null;
                DataSet sqlDataSet = this.ExecuteQuery(cm);
                if (sqlDataSet.Tables != null)
                    sqlDataTable = sqlDataSet.Tables[0];
                this.disconnect();
                return sqlDataTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Save(DataTable ct)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(strcnnString))
            {
                bulkCopy.BulkCopyTimeout = 600; // in seconds
                bulkCopy.DestinationTableName = "CT_CaLamViec";
                try
                {
                    bulkCopy.WriteToServer(ct);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion
    }
}
