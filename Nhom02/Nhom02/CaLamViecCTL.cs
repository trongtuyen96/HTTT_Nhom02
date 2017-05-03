using System;
using System.Data;

namespace Nhom02
{
    class CaLamViecCTL
    {
        CaLamViecDAO dataCaLamViec = new CaLamViecDAO();

        public bool save(DateTime ngay, string loai)
        {
            string id = "";
            if (loai == "Trưa")
                id = ngay.ToString("ddmmyyyy") + "Tr";
            else id = ngay.ToString("ddmmyyyy") + "To";
            CaLamViecDTO ca = new CaLamViecDTO(id, ngay, loai);
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

        public bool delete(string ID)
        {
            return dataCaLamViec.Delete(ID);
        }
    }
}
