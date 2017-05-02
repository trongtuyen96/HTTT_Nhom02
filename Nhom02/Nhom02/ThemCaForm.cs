﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nhom02
{
    public partial class ThemCaForm : Form
    {
        private CaLamViecCTL _ctlCaLamViec = new CaLamViecCTL();

        public ThemCaForm()
        {
            InitializeComponent();
            cmbLoaiCa.SelectedItem = "Trưa";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_ctlCaLamViec.save(dateTimePicker.Value, cmbLoaiCa.SelectedItem.ToString()))
            {
                MessageBox.Show("Thêm ca thành công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else MessageBox.Show("Thêm ca thất bại", "Lỗi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}