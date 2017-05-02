using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Nhom02
{
    class DataProvider
    {
        public string strcnnString = "Data Source=(Localdb)\\MSSQLLocalDB;" +
            "AttachDbFilename=|DataDirectory|\\App_Data\\quanlynhahang.mdf;" +
            "Integrated Security = True";
        protected SqlConnection cnn;
        protected SqlDataAdapter dt;
        protected SqlCommand cm;
        protected void connect()
        {
            cnn = new SqlConnection(strcnnString);
            cnn.Open();
        }
        protected void disconnect()
        {
            cnn.Close();
        }
        protected void ExecuteNonQuery(string sql)
        {
            cm = new SqlCommand(sql);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
        }
        protected void ExecuteUpdateQuery(string sql) //thêm, xóa, sửa
        {
            connect();
            ExecuteNonQuery(sql);
            disconnect();
        }
        public DataSet ExecuteQuery(SqlCommand command)
        {
            DataSet dataset = new DataSet();
            cm = command;
            cm.Connection = this.cnn;
            dt = new SqlDataAdapter(cm);
            try { dt.Fill(dataset); }
            catch (SqlException ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dataset;
        }

        public DataTable ExecuteQuery_DataTable(SqlCommand command)
        { return ExecuteQuery(command).Tables[0]; }

        protected virtual object GetInfoFrom1Row(DataTable ddt, int i)
        {
            return null;
        }
        protected ArrayList ConvertDataTable2ArrayList(DataTable ddt)
        {
            ArrayList ar = new ArrayList();
            int i, n = ddt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object dto = GetInfoFrom1Row(ddt, i);
                ar.Add(dto);
            }
            return ar;
        }
    }
}
