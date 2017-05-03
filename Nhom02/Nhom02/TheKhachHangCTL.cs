using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nhom02
{
    class TheKhachHangCTL
    {
        TheKhachHangDAO dataThe = new TheKhachHangDAO();

        public bool Them(string hoten, string sdt, DateTime ngaysinh, string cmnd, int diemtichluy)
        {
            TheKhachHangDTO the = new TheKhachHangDTO(hoten, sdt, ngaysinh, cmnd, diemtichluy);
            if (dataThe.Them(the))
            {
                return true;
            }
            return false;
        }

      
        //public bool CapNhat(string hoten, string sdt, DateTime ngaysinh, string cmnd, int diemtichluy)
        //{
        //    TheKhachHangDTO the = new TheKhachHangDTO(hoten, sdt, ngaysinh, cmnd, diemtichluy);
        //    if (dataThe.CapNhat(the))
        //    {
        //        return true;
        //    }
        //    return false;
            
        //}

        public bool Xoa(string ID)
        {
            return dataThe.Xoa(ID);
        }

        public DataTable LoadDuLieu()
        {
            return dataThe.LoadDuLieu();
        }

        public string LaySoMaThe()
        {
            return dataThe.LaySoMaThe();
        }

        //public DataTable searchKeyword(string keyword, string category)
        //{
        //    return dataThe.TimKiemTuKhoa(keyword, category);
        //}

    }
}
