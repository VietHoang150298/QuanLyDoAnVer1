using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.ViewModels
{
    public class KetQuaViewModel
    {
        public int IdKetQua { get; set; }
        public string MaHoiDong { get; set; }
        public string MaGiangVien { get; set; }
        public string MaSinhVien { get; set; }
        public string TenGiangVien { get; set; }
        public string MaDeTai { get; set; }
        public string TenDeTai { get; set; }
        public float DiemSo { get; set; }
        public bool? IsPhanBien { get; set; }
        public string MaMonHoc { get; set; }
        public string MaHocKy { get; set; }
        public float DiemTrungBinh { get; set; }
    }
}