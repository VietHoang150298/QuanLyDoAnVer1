using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("GiangVienHdSinhViens")]
    public class GiangVienHdSinhVien
    {
        [Key]
        public int IdGiangVienHdSinhVien { get; set; }
        [DisplayName("Mã Giảng Viên")]
        [StringLength(50)]
        public string MaGiangVien { get; set; }
        [DisplayName("Tên Giảng Viên")]
        [StringLength(50)]
        public string TenGiangVien { get; set; }
        [DisplayName("Mã Sinh Viên")]
        [StringLength(50)]
        public string MaSinhVien { get; set; }
        [DisplayName("Tên Sinh Viên")]
        [StringLength(50)]
        public string TenSinhVien { get; set; }
        [DisplayName("Mã Học Kỳ")]
        [StringLength(50)]
        public string MaHocKy { get; set; }
    }
}