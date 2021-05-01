namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhanBien
    {
        public int Id { get; set; }

        public string MaPhanBien { get; set; }

        public int? IdGiangVien { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public DateTime? ThoiKhoaBieu { get; set; }

        public int? KetQuaPhanBien { get; set; }

        public string NhanXet { get; set; }
    }
}
