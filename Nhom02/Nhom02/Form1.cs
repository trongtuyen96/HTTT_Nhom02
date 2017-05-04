using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nhom02
{
    public partial class Form1 : Form
    {
        CaLamViecCTL _caData = new CaLamViecCTL();
        CT_CaLamViecCTL _ctCaData = new CT_CaLamViecCTL();
        public Form1()
        {
            InitializeComponent();
            loadDataGridViewCa();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCa_Click(object sender, EventArgs e)
        {
            ThemCaForm themCaForm = new ThemCaForm();
            themCaForm.ShowDialog();
            //refresh datagridview ca làm việc
            loadDataGridViewCa();
        }
        private void loadDataGridViewCa()
        {
            DataTable caData = _caData.search();
            dataGridViewCa.DataSource = caData;

            dataGridViewCa.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void loadDataGridViewCTCa(string id)
        {
            DataTable caData = _ctCaData.search(id);
            dataGridViewCTCa.DataSource = caData;

            dataGridViewCTCa.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void dataGridViewCa_SelectionChanged(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewCa.CurrentCell.RowIndex;
            loadDataGridViewCTCa(dataGridViewCa.Rows[rowindex].Cells[0].Value.ToString());
        }

        private void btnDeleteCa_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewCa.CurrentCell.RowIndex;
            // delete theo id 
            _caData.delete(dataGridViewCa.Rows[rowindex].Cells[0].Value.ToString());

            // load lại danh sách ca
            loadDataGridViewCa();
        }
    }
}
