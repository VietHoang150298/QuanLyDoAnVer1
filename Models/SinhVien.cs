using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("SinhViens")]
    public partial class SinhVien
    {
        [Key]
        public int IdSinhVien { get; set; }
        [DisplayName("Mã Sinh Viên")]
        [StringLength(50)]
        public string MaSinhVien { get; set; }
        [DisplayName("Họ Đệm")]
        [StringLength(50)]
        public string HoDem { get; set; }
        [DisplayName("Tên")]
        [StringLength(50)]
        public string Ten { get; set; }
        [DisplayName("Họ Tên")]
        [StringLength(50)]
        public string HoTen { get; set; }
        [DisplayName("Hòm Thư")]
        [StringLength(50)]
        public string HomThu { get; set; }
        [DisplayName("Mã Lớp")]
        [StringLength(50)]
        public string MaLop { get; set; }
        [DisplayName("Điện Thoại")]
        [StringLength(50)]
        public string DienThoai { get; set; }
        [DisplayName("Tín Chỉ Tích Lũy")]
        public int? TinChiTichLuy { get; set; }
        [DisplayName("Điểm Tích Lũy")]
        public float? DiemTichLuy { get; set; }
        [DisplayName("Mã Học Kỳ")]
        [StringLength(50)]
        public string MaHocKy { get; set; }
    }
}