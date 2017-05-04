using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Nhom02
{
    class CT_CaLamViecCTL
    {
        private CT_CaLamViecDAO dataCTCaLamViec = new CT_CaLamViecDAO();

        public DataTable search(string id)
        {
            return dataCTCaLamViec.Search(id);
        }

        public bool save(DataTable table)
        {
            return dataCTCaLamViec.Save(table);
        }

    }
}
