using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("GiangViens")]
    public partial class GiangVien
    {
        [Key]
        public int IdGiangVien { get; set; }
        [StringLength(50)]
        [DisplayName("Mã Giảng Viên")]

        public string MaGiangVien { get; set; }
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
        [DisplayName("Đơn Vị Công Tác")]
        [StringLength(50)]
        public string DonViCongTac { get; set; }
        [DisplayName("Điện Thoại")]
        [StringLength(50)]
        public string DienThoai { get; set; }
        [DisplayName("Mã Bộ Môn")]
        [StringLength(50)]
        public string MaBoMon { get; set; }
        [DisplayName("Mã Học Kỳ")]
        [StringLength(50)]
        public string MaHocKy { get; set; }
    }
}