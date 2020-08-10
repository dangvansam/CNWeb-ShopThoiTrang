namespace ShopThoiTrang.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Username")]
        public string username { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Password")]
        public string password { get; set; }

        [StringLength(20)]
        [DisplayName("Full Name")]
        public string TenNguoiDung { get; set; }

        [StringLength(20)]
        [DisplayName("Sex")]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        [DisplayName("Phone Number")]
        public string SDT { get; set; }

        [StringLength(50)]
        [DisplayName("Address")]
        public string DiaChi { get; set; }

        [DisplayName("User Type")]
        public int LoaiNguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
