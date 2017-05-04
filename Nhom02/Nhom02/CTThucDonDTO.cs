using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhom02
{
    class CTThucDonDTO
    {
        private DateTime ngay;
        private string idMonAn;
        private int soLuong;

        public CTThucDonDTO(DateTime ngay, string idMonAn, int soLuong)
        {
            this.ngay = ngay;
            this.idMonAn = idMonAn;
            this.soLuong = soLuong;
        }

        public DateTime Ngay
        {
            get
            {
                return ngay;
            }

            set
            {
                ngay = value;
            }
        }

        public string IdMonAn
        {
            get
            {
                return idMonAn;
            }

            set
            {
                idMonAn = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }
    }
}
