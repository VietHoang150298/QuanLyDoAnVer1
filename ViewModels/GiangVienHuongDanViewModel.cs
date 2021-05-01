using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.ViewModels
{
    public class GiangVienHuongDanViewModel
    {
        public int? Id { get; set; }
        public int? SoLuongSinhVienHuongDan { get; set; }
        public string MaGiangVien { get; set; }
        public string HoTen { get; set; }
        public string HomThu { get; set; }
        public string DonViCongTac { get; set; }
        public string TenHocKy { get; set; }
        public DateTime NamBatDau { get; set; }
        public DateTime NamKetThuc { get; set; }
    }
}