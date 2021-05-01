using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.ViewModels
{
    public class SinhVienViewModel
    {
        public int Id { get; set; }
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public string HomThu { get; set; }
        public string DienThoai { get; set; }
        public int? TinChiTichLuy { get; set; }
        public float? DiemTichLuy { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
    }
}