namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SinhVien
    {
        [Key]
        public int IdSinhVien { get; set; }
        [DisplayName("Mã Sinh Viên")]
        public string MaSinhVien { get; set; }
        [DisplayName("Họ Đệm")]
        public string HoDem { get; set; }
        [DisplayName("Tên")]
        public string Ten { get; set; }
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }
        [DisplayName("Hòm Thư")]
        public string HomThu { get; set; }
        [DisplayName("Mã Lớp")]
        public string MaLop { get; set; }
        [DisplayName("Điện Thoại")]
        public string DienThoai { get; set; }
        [DisplayName("Tín Chỉ Tích Lũy")]
        public int? TinChiTichLuy { get; set; }
        [DisplayName("Điểm Tích Lũy")]
        public float? DiemTichLuy { get; set; }
        [DisplayName("Mã Học Kỳ")]
        public string MaHocKy { get; set; }
    }
}
