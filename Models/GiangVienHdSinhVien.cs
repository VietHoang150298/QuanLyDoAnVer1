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
        public string MaGiangVien { get; set; }
        [DisplayName("Tên Giảng Viên")]
        public string TenGiangVien { get; set; }
        [DisplayName("Mã Sinh Viên")]
        public string MaSinhVien { get; set; }
        [DisplayName("Tên Sinh Viên")]
        public string TenSinhVien { get; set; }
        [DisplayName("Mã Học Kỳ")]
        public string MaHocKy { get; set; }
    }
}