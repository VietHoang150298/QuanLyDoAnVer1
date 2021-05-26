namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocKys")]
    public partial class HocKy
    {
        [Key]
        public int IdHocKy { get; set; }
        [DisplayName("Mã Học Kỳ")]
        public string MaHocKy { get; set; }

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