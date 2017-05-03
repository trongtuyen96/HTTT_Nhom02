using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhom02
{
    class NhanVienDTO
    {
        private string _id;
        private string _hoTen;
        private string _chucVu;
        private string _boPhan;

        #region Contructor
        public NhanVienDTO(string id, string ten, string chucVu, string boPhan)
        {
            _id = id;
            _hoTen = ten;
            _chucVu = chucVu;
            _boPhan = boPhan;
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public string Hoten { set { this._hoTen = value; } get { return this._hoTen; } }
        public string ChucVu { set { this._chucVu = value; } get { return this._chucVu; } }
        public string BoPhan { set { this._boPhan = value; } get { return this._boPhan; } }
        #endregion
    }
}
