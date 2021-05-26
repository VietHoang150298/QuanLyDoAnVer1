namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GiangVien
    {
        [Key]
        public int IdGiangVien { get; set; }
        [DisplayName("Mã Giảng Viên")]

        public string MaGiangVien { get; set; }
        [DisplayName("Họ Đệm")]
        public string HoDem { get; set; }
        [DisplayName("Tên")]
        public string Ten { get; set; }
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }
        [DisplayName("Hòm Thư")]
        public string HomThu { get; set; }
        [DisplayName("Đơn Vị Công Tác")]
        public string DonViCongTac { get; set; }
        [DisplayName("Điện Thoại")]
        public string DienThoai { get; set; }
        [DisplayName("Mã Bộ Môn")]
        public string MaBoMon { get; set; }
        [DisplayName("Mã Học Kỳ")]
        public string MaHocKy { get; set; }
    }
}