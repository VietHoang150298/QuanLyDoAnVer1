using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("LoaiMonHocs")]
    public class LoaiMonHoc
    {
        [Key]
        public int IdLoaiMonHoc { get; set; }
        [DisplayName("Tên Loại Môn Học")]
        [StringLength(50)]
        public string TenLoaiMonHoc { get; set; }
    }
}