using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhom02
{
    public class TheKhachHangDTO
    {
        private string _id;
        private string _HoTen;
        private string _SDT;
        private DateTime _NgaySinh;
        private string _CMND;
        private int _DiemTichLuy;

        #region Properties
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception(" ID khong duoc trong");
                }
                _id = value;
            }
        }

        public string HoTen
        {
            get
            {
                return _HoTen;
            }

            set
            {
                _HoTen = value;
            }
        }

        public string SDT
        {
            get
            {
                return _SDT;
            }

            set
            {
                _SDT = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return _NgaySinh;
            }

            set
            {
                _NgaySinh = value;
            }
        }

        public string CMND
        {
            get
            {
                return _CMND;
            }

            set
            {
                _CMND = value;
            }
        }

        public int DiemTichLuy
        {
            get
            {
                return _DiemTichLuy;
            }

            set
            {
                _DiemTichLuy = value;
            }
        }
        #endregion

        #region Contructor
        public TheKhachHangDTO(string id, string hoTen, string SDT, DateTime ngaySinh, string CMND, int diemTichLuy)
        {
            Id = id;
            HoTen = hoTen;
            this.SDT = SDT;
            NgaySinh = ngaySinh;
            this.CMND = CMND;
            DiemTichLuy = diemTichLuy;
        }
        #endregion

       

    }
}
