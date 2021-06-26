using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("DeTais")]
    public partial class DeTai
    {
        [Key]
        public int IdDeTai { get; set; }
        [DisplayName("Mã Đề Tài")]
        [StringLength(50)]
        public string MaDeTai { get; set; }
        [DisplayName("Tên Đề Tài")]
        [StringLength(50)]
        public string TenDeTai { get; set; }
        [DisplayName("File Báo Cáo")]
        public string LinkFileBaoCaoCuoiCung { get; set; }
        [DisplayName("Mã Môn Học")]
        [StringLength(50)]
        public string MaMonHoc { get; set; }
        [DisplayName("Mã Sinh Viên")]
        [StringLength(50)]
        public string MaSinhVien { get; set; }
        [DisplayName("Mã Giảng Viên")]
        [StringLength(50)]
        public string MaGiangVien { get; set; }

        [DisplayName("Mã Hội Đồng")]
        [StringLength(50)]
        public string MaHoiDong { get; set; }
        [DisplayName("Số Lượng Phản Biện")]
        public int? SoLuongPhanBien { get; set; }
    }
}