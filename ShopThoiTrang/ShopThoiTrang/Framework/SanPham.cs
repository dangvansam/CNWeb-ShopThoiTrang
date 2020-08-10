namespace ShopThoiTrang.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        public int MaSanPham { get; set; }

        [Required]
        [DisplayName("Category ID")]
        public int MaLoai { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Product")]
        public string TenSanPham { get; set; }

        [Required]
        [DisplayName("Price")]
        public double? Gia { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int? SoLuong { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Info")]
        public string ThongTin { get; set; }


        [StringLength(100)]
        [DisplayName("Image")]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual Loai Loai { get; set; }
    }
}
