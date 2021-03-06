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
        [StringLength(50)]
        public string MaMonHoc { get; set; }
        [DisplayName("Tên Môn Học")]
        [StringLength(50)]
        public string TenMonHoc { get; set; }
        [DisplayName("Điều Kiện Tiên Quyết")]
        [StringLength(50)]
        public string DieuKienTienQuyet { get; set; }
        [DisplayName("Mã Học Kỳ")]
        [StringLength(50)]
        public string MaHocKy { get; set; }
        [DisplayName("Loại Môn Học")]
        public int IdLoaiMonHoc { get; set; }
        [DisplayName("Số Lượng Phản Biện Tối Đa Cho Một Đề Tài")]
        public int? SoLuongPhanBienToiDa { get; set; }
        [DisplayName("Thành Lập Hội Đồng")]
        public bool? ThanhLapHoiDong { get; set; }
    }
}