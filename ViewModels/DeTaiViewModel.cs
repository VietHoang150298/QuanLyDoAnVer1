using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.ViewModels
{
    public class DeTaiViewModel
    {
        public int Id { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public float? KetQua { get; set; }
        public string NhanXet { get; set; }
        public string TenMonHoc { get; set; }
        public string HoTenSinhVien { get; set; }
        public string HoTenGvhd { get; set; }
        public string TenHoiDong { get; set; }
    }
}