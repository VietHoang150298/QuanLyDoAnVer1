using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("KetQuas")]
    public class KetQua
    {
        [Key]
        public int IdKetQua { get; set; }
        [StringLength(50)]
        [DisplayName("Mã Hội Đồng")]
        public string MaHoiDong { get; set; }
        [StringLength(50)]
        [DisplayName("Mã Giảng Viên")]
        public string MaGiangVien { get; set; }
        [StringLength(50)]
        [DisplayName("Mã Đề Tài")]
        public string MaDeTai { get; set; }
        [StringLength(50)]
        [DisplayName("Mã Môn Học")]
        public string MaMonHoc { get; set; }
        [DisplayName("Điểm Số")]
        public float DiemSo { get; set; }
        [DisplayName("Nhận Xét")]
        public string NhanXet { get; set; }
        public bool? IsPhanBien { get; set; }
    }
}