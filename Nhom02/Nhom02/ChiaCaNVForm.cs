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
    public partial class ChiaCaNVForm : Form
    {
        private NhanVienCTL _ctlNhanVien = new NhanVienCTL();
        private CT_CaLamViecCTL _ctlCTCa = new CT_CaLamViecCTL();
        private string idCa;
        public ChiaCaNVForm(DateTime ngay, string loai)
        {
            InitializeComponent();
            lbNgay.Text = ngay.ToString("dd/MM/yyyy");
            lbLoaiCa.Text = loai;

            if (loai == "Trưa")
                idCa = ngay.ToString("ddmmyyyy") + "Tr";
            else idCa = ngay.ToString("ddmmyyyy") + "To";

            // load danh sách nhân viên vào dataGridViewNV
            loadDataGridViewNV();

            cmbKhuVuc.SelectedItem = "Quầy bar";
        }

        private void loadDataGridViewNV()
        {
            DataTable spData = _ctlNhanVien.search();
            dataGridViewNV.DataSource = spData;

            dataGridViewNV.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewNV.CurrentCell.RowIndex;
            // lấy id
            string id = dataGridViewNV.Rows[rowindex].Cells[0].Value.ToString();
            string name = dataGridViewNV.Rows[rowindex].Cells[1].Value.ToString();
            string chucVu = dataGridViewNV.Rows[rowindex].Cells[2].Value.ToString();

            // kiểm tra xem item này đã có bên gridview bên phải chưa
            int rowFound = -1;
            foreach (DataGridViewRow gridrow in dataGridViewMain.Rows)
            {
                if (gridrow.Cells[0].Value != null && gridrow.Cells[0].Value.ToString().Equals(id))
                {
                    rowFound = gridrow.Index;
                    dataGridViewMain.Rows[dataGridViewMain.SelectedRows[0].Index].Selected = false;
                    dataGridViewMain.Rows[rowFound].Selected = true;
                    break;
                }
            }
            if (rowFound == -1)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewMain.RowTemplate.Clone();
                if(chucVu == "Bếp trưởng")
                    row.CreateCells(dataGridViewMain, id, name, chucVu, "", "Chính");
                else
                    row.CreateCells(dataGridViewMain, id, name, chucVu, cmbKhuVuc.SelectedItem.ToString(), "Chính");

                dataGridViewMain.Rows.Add(row);
                dataGridViewMain.Sort(dataGridViewMain.Columns[3], ListSortDirection.Ascending);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // save bảng chia việc
            // tạo DataTable để lấy data trong grid view
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("idCa", typeof(string)));
            table.Columns.Add(new DataColumn("idNhanVien", typeof(string)));
            table.Columns.Add(new DataColumn("KhuVucLamViec", typeof(string)));
            table.Columns.Add(new DataColumn("LoaiCa", typeof(string)));

            object[] cellValues = new object[4];
            foreach (DataGridViewRow row in dataGridViewMain.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    cellValues[0] = idCa;
                    cellValues[1] = row.Cells[0].Value;
                    cellValues[2] = row.Cells[3].Value;
                    cellValues[3] = row.Cells[4].Value;
                    table.Rows.Add(cellValues);
                }
            }
            if (_ctlCTCa.save(table))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
