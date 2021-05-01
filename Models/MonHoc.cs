namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MonHoc
    {
        public int Id { get; set; }

        public string MaMonHoc { get; set; }

        public string TenMonHoc { get; set; }

        public int DieuKienTienQuyet { get; set; }

        public int? IdHocKy { get; set; }
    }
}
