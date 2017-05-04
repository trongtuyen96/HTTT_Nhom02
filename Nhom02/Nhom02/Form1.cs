using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Nhom02
{
    public partial class Form1 : Form
    {
        CaLamViecCTL _caData = new CaLamViecCTL();
        CT_CaLamViecCTL _ctCaData = new CT_CaLamViecCTL();
        TheKhachHangCTL _theData = new TheKhachHangCTL();
        public Form1()
        {
            InitializeComponent();  
            loadDataGridViewTheKhachHang();
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
            dataGridViewCa.Sort(dataGridViewCa.Columns[1], ListSortDirection.Ascending);
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
            dataGridViewCa.Sort(dataGridViewCa.Columns[1], ListSortDirection.Ascending);
        }
        private void loadDataGridViewTheKhachHang()
        {
            DataTable theData = _theData.LoadDuLieu();
            dataGridViewThe.DataSource = theData;

            dataGridViewThe.DataBindingComplete += (o, _) =>
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
            if (dataGridViewCa.CurrentCell != null)
            {
                int rowindex = dataGridViewCa.CurrentCell.RowIndex;
                loadDataGridViewCTCa(dataGridViewCa.Rows[rowindex].Cells[0].Value.ToString());
            }
        }

        private void btnThemThe_Click(object sender, EventArgs e)
        {
            ThemTheKhachHangForm themTheKhachHangForm = new ThemTheKhachHangForm();
            if (themTheKhachHangForm.ShowDialog() == DialogResult.OK)
            {
                //refresh datagridview thẻ khách hàng
                loadDataGridViewTheKhachHang();
            }
        }

        private void btnXoaThe_Click(object sender, EventArgs e)
        {
            // index row đang được chọn
            int rowindex = dataGridViewThe.CurrentCell.RowIndex;
            // delete theo id 
            _theData.Xoa(dataGridViewThe.Rows[rowindex].Cells[0].Value.ToString());

            // load lại danh sách thẻ
            loadDataGridViewTheKhachHang();
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

        ThucDonCTL tdControl = new ThucDonCTL();
        MonAnCTL monAnControl = new MonAnCTL();
        CTThucDonCTL CTThucDonControl = new CTThucDonCTL();
        ThucDonDTO thucDon = new ThucDonDTO();
        ArrayList dsMonAn;
        ArrayList dsMonAnDaChon;
        DateTime dateThem;
        ArrayList arrCTThucDon;
        private void btnThemTD_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerTD.Value.Date;
            if (tdControl.traCuuTD(date) == true)
            {
                MessageBox.Show("Thực đơn cho ngày này đã tồn tại", "Thông báo");
                dataGridViewXemTD.DataSource = tdControl.LoadThucDon(date);
                return;
            }
            dateThem = date;
            dsMonAnDaChon = new ArrayList();
            arrCTThucDon = new ArrayList();

            btnThemTD.Enabled = false;
            panelMonAn.Enabled = true;
            txtDate.Text = date.ToLongDateString().ToString();
            dataGridViewXemTD.DataSource = tdControl.LoadThucDon(date);
            dataGridViewTD.DataSource = tdControl.LoadThucDon(date);

            dsMonAn = monAnControl.getDsMonAn();

            ////hien danh sach cac mon an hien dang co trong thuc don
            //dataGridViewTD.DataSource = arrCTThucDon;
            if (dataGridViewTD.Columns.Count == 0)
            {
                dataGridViewTD.Columns.Add("Column", "idMonAn");
                dataGridViewTD.Columns.Add("Column", "TenMon");
                dataGridViewTD.Columns.Add("Column", "SoLuong");
            }
            foreach (DataGridViewColumn column in dataGridViewTD.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            cmbMonAn.DataSource = dsMonAn;
            cmbMonAn.DisplayMember = "tenMon";
        }

        private void btnTimKiemTD_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerTD.Value.Date;
            if (tdControl.traCuuTD(date) == false)
            {
                MessageBox.Show("Chưa tạo thực đơn cho ngày này", "Thông báo");
            }

            dataGridViewXemTD.DataSource = tdControl.LoadThucDon(date);

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            DateTime date = dateThem;
            if (cmbMonAn.SelectedValue == null || txtSoLuong.Text == "")
            {
                return;
            }
            int soLuong = int.Parse(txtSoLuong.Text);
            if (soLuong == 0) { MessageBox.Show("Số lượng lớn hơn 0", "Thông báo"); return; }
            MonAnDTO monAn = cmbMonAn.SelectedValue as MonAnDTO;
            dsMonAnDaChon.Add(monAn);
            dsMonAn.Remove(monAn);



            //refresh lại combobox
            cmbMonAn.DataSource = null;
            cmbMonAn.DataSource = dsMonAn;
            cmbMonAn.DisplayMember = "tenMon";

            //them mon an vao danh sach
            arrCTThucDon.Add(new CTThucDonDTO(date, monAn.Id, soLuong));

            //hien len gridview
            DataTable dataTable = (DataTable)dataGridViewTD.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            drToAdd["idMonAn"] = monAn.Id;
            drToAdd["TenMon"] = monAn.TenMon;
            drToAdd["SoLuong"] = soLuong;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();

            //reset lại ô số lượng
            txtSoLuong.Text = "";
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            bool delete = false;
            foreach (DataGridViewRow item in this.dataGridViewTD.SelectedRows)
            {
                delete = true;
                int rowindex = item.Index;
                arrCTThucDon.RemoveAt(rowindex);
                dsMonAn.Add((MonAnDTO)dsMonAnDaChon[rowindex]);
                dsMonAnDaChon.RemoveAt(rowindex);
                dataGridViewTD.Rows.RemoveAt(item.Index);
            }
            if (delete == true) // neu da co dong xoa
            {
                cmbMonAn.DataSource = null;
                cmbMonAn.DataSource = dsMonAn;
                cmbMonAn.DisplayMember = "tenMon";
            }
            else
            {
                MessageBox.Show("Xin chọn toàn bộ dòng để xóa (có thể chọn 1 hay nhiều dòng)");
            }
        }

        private void btnHoanThanhTD_Click(object sender, EventArgs e)
        {
            if (arrCTThucDon.Count == 0)
            {
                MessageBox.Show("Xin hãy thêm món vào thực đơn", "Thông báo");
                return;
            }
            DateTime date = dateThem;
            tdControl.themTD(date);
            CTThucDonControl.themMonTD(arrCTThucDon);
            btnThemTD.Enabled = true;
            //panelThucDon.Visible = true;
            panelMonAn.Enabled = false;
            dataGridViewTD.DataSource = null;
            MessageBox.Show("Thực đơn đã được lưu", "Thông báo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Xóa thực đơn?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dsMonAn.Clear();
                dsMonAnDaChon.Clear();
                arrCTThucDon.Clear();
                //panelThucDon.Visible = true;
                //panelMonAn.Visible = false;
                btnThemTD.Enabled = true;
                panelMonAn.Enabled = false;
                dataGridViewTD.DataSource = null;
            }

        }

    }
}
