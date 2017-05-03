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
    public partial class ThemTheKhachHangForm : Form
    {
        private TheKhachHangCTL theCtl = new TheKhachHangCTL();
        public ThemTheKhachHangForm()
        {
            InitializeComponent();
            textDiem.Text = "20";
            textId.Text = String.Concat("KH", theCtl.LaySoMaThe());
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            if (theCtl.Them(textHoTen.Text, textSDT.Text, dtpNgaySinh.Value, textCMND.Text, 20))
            {
                MessageBox.Show("Thêm thẻ thành công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else MessageBox.Show("Thêm thẻ thất bại", "Lỗi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
