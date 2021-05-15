namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KetQua
    {
        [Key]
        public int IdKetQua { get; set; }
        [DisplayName("Điểm Số")]
        public int? DiemSo { get; set; }
        [StringLength(50)]
        [DisplayName("Nhận Xét")]
        public string NhanXet { get; set; }

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
        [DisplayName("Mã Phản Biện")]
        public string MaPhanBien { get; set; }
    }
}
