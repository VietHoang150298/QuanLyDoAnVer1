namespace QuanLyDoAn.Models
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

        [DisplayName("Mã Giảng Viên")]
        public string MaGiangVien { get; set; }
    }
}