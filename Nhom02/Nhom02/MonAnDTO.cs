using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhom02
{
    class MonAnDTO
    {
        private string id;
        private string tenMon;
        private double gia;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string TenMon
        {
            get
            {
                return tenMon;
            }

            set
            {
                tenMon = value;
            }
        }

        public double Gia
        {
            get
            {
                return gia;
            }

            set
            {
                gia = value;
            }
        }
    }
}
