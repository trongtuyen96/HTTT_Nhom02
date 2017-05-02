using System;
using System.Data;

namespace Nhom02
{
    class CaLamViecCTL
    {
        CaLamViecDAO dataCaLamViec = new CaLamViecDAO();

        public bool save(DateTime ngay, string loai)
        {
            CaLamViecDTO ca = new CaLamViecDTO(ngay.ToString("ddmmyyyy") + loai, ngay, loai);
            if (dataCaLamViec.Save(ca))
            {
                return true;
            }
            return false;
        }

        public DataTable search()
        {
            return dataCaLamViec.Search();
        }
    }
}
