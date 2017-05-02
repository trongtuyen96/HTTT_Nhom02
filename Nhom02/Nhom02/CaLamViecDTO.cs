using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhom02
{
    class CaLamViecDTO
    {
        private string _id;
        private DateTime _ngay;
        private string _loai;

        #region Contructor
        public CaLamViecDTO(string id, DateTime ngay, string loai)
        {
            _id = id;
            _ngay = ngay;
            _loai = loai;
        }
        #endregion

        #region Properties
        public string ID { set { this._id = value; } get { return this._id; } }
        public DateTime Ngay { set { this._ngay = value; } get { return this._ngay; } }
        public string Loai { set { this._loai = value; } get { return this._loai; } }
        #endregion
    }
}
