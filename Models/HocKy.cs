using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("HocKys")]
    public partial class HocKy
    {
        [Key]
        public int IdHocKy { get; set; }
        [DisplayName("Mã Học Kỳ")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Không được nhập ký tự đặc biệt!")]
        [Required(ErrorMessage = "Hãy nhập mã học kỳ!")]
        public string MaHocKy { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên học kỳ!")]
        [StringLength(50)]
        [DisplayName("Tên Học Kỳ")]
        public string TenHocKy { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Năm Bắt Đầu")]
        public DateTime? NamBatDau { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Năm Kết Thúc")]
        public DateTime? NamKetThuc { get; set; }
    }
}