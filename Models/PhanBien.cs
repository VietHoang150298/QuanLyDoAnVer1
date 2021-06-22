using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("PhanBiens")]
    public partial class PhanBien
    {
        [Key]
        public int IdPhanBien { get; set; }

        [DisplayName("Mã Giảng Viên")]
        public string MaGiangVien { get; set; }
        [DisplayName("Mã Môn Học")]
        public string MaMonHoc { get; set; }
    }
}