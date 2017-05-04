using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Nhom02
{
    class CTThucDonCTL
    {
        private CTThucDonDAO dataAccess = new CTThucDonDAO();
        public bool themMonTD(ArrayList dsCTThucDon)
        {
            return dataAccess.themMonTD(dsCTThucDon);
        }
    }
}
