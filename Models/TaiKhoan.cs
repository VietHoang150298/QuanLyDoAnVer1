using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("TaiKhoans")]
    public class TaiKhoan
    {
        [Key]
        public int IdTaiKhoan { get; set; }
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string MatKhau { get; set; }
        [Required]
        [NotMapped]
        [Compare("MatKhau", ErrorMessage = "Mật Khẩu Xác Nhận Không Đúng.")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string MatKhauXacNhan { get; set; }
        [StringLength(20)]
        public string IdVaiTro { get; set; }
    }
}