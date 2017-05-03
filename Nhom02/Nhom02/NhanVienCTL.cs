using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Nhom02
{
    class NhanVienCTL
    {
        private NhanVienDAO dataNhanVien = new NhanVienDAO();

        public DataTable search()
        {
            return dataNhanVien.Search();
        }

    }
}
