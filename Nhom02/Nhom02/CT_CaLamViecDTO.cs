using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhom02
{
    class CT_CaLamViecDTO
    {
        private string _idCa;
        private string _idNV;
        private string _khuvuc;
        private string _loaiCa;

        #region Contructor
        public CT_CaLamViecDTO(string idCa, string idNV, string kv, string loai)
        {
            _idCa = idCa;
            _idNV = idNV;
            _khuvuc = kv;
            _loaiCa = loai;
        }
        #endregion

        #region Properties
        public string IDCa { set { this._idCa = value; } get { return this._idCa; } }
        public string IDNV { set { this._idNV = value; } get { return this._idNV; } }
        public string KhuVuc { set { this._khuvuc = value; } get { return this._khuvuc; } }
        public string LoaiCa { set { this._loaiCa = value; } get { return this._loaiCa; } }
        #endregion
    }
}
