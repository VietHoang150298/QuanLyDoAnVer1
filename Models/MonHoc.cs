using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("MonHocs")]
    public partial class MonHoc
    {
        [Key]
        public int IdMonHoc { get; set; }
        [DisplayName("Mã Môn Học")]
        public string MaMonHoc { get; set; }
        [DisplayName("Tên Môn Học")]
        public string TenMonHoc { get; set; }
        [DisplayName("Điều Kiện Tiên Quyết")]
        public string DieuKienTienQuyet { get; set; }
        [DisplayName("Mã Học Kỳ")]
        public string MaHocKy { get; set; }
        [DisplayName("Loại Môn Học")]
        public int IdLoaiMonHoc { get; set; }
    }
}