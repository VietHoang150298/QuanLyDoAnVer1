using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("KetQuas")]
    public class KetQua
    {
        [Key]
        public int IdKetQua { get; set; }
        public string MaHoiDong { get; set; }
        public string MaGiangVien { get; set; }
        public string MaDeTai { get; set; }
        public float DiemSo { get; set; }
        public string NhanXet { get; set; }
        public bool? IsPhanBien { get; set; }
    }
}