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
            if(themCaForm.ShowDialog() == DialogResult.OK)
            {
                //refresh datagridview ca làm việc
                loadDataGridViewCa();
            }
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
    }
}
