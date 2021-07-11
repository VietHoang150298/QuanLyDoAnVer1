using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.ViewModels
{
    public class PhanBienViewModel
    {
        public int IdPhanBien { get; set; }
        public string MaGiangVien { get; set; }
        public string TenGiangVien { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public string MaMonHoc { get; set; }
        public string HoTen { get; set; }
        public string HomThu { get; set; }
        public string DonViCongTac { get; set; }
        public string DienThoai { get; set; }
    }
}