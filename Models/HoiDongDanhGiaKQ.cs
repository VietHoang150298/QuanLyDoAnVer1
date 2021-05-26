namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoiDongDanhGiaKQ
    {
        [Key]
        public int IdHoiDongDGKQ { get; set; }
        [DisplayName("Mã Hội Đồng")]
        public string MaHoiDong { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Thời Khóa Biểu")]
        public DateTime? ThoiKhoaBieu { get; set; }
        [DisplayName("Số Lượng Thành Viên")]
        public int SoLuongThanhVien { get; set; }

        public int DemSoLuongThanhVien { get; set; }

        [DisplayName("Mã Học Kỳ")]
        public string MaHocKy { get; set; }
    }
}