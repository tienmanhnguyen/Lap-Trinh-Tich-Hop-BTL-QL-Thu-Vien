using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebService.Class
{
    public class MuonSach
    {
        public int IDBanDoc { get; set; }

        public string TenBanDoc { get; set; }

        public int IDPhieuMuon { get; set; }

        public int IDCuonSach { get; set; }

        public string TenSach { get; set; }

        public DateTime? NgayMuon { get; set; }

        public DateTime? NgayHenTra { get; set; }
    }
}