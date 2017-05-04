using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nhom02
{
    class ThucDonCTL
    {
        private ThucDonDAO dataAccess = new ThucDonDAO();
        public DataTable LoadThucDon(DateTime date)
        {
            return dataAccess.LoadThucDon(date);
        }
        public bool traCuuTD(DateTime date)
        {
            return dataAccess.traCuuTD(date);
        }
        public bool themTD(DateTime ngayTD)
        {
            return dataAccess.themTD(ngayTD);
        }
    }
}
