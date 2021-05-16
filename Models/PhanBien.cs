﻿namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhanBien
    {
        [Key]
        public int IdPhanBien { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ThoiKhoaBieu { get; set; }

        [DisplayName("Mã Giảng Viên")]
        public string MaGiangVien { get; set; }
    }
}
