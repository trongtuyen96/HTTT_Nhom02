using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Nhom02
{
    class MonAnCTL
    {
        MonAnDAO dataAccess = new MonAnDAO();
        public ArrayList getDsMonAn()
        {
            return dataAccess.getDsMonAn();
        }
    }
}
