//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnWinform_Demo02
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhomThucUong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomThucUong()
        {
            this.ThucUongs = new HashSet<ThucUong>();
        }
    
        public string MaNhom { get; set; }
        public string TenNhom { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThucUong> ThucUongs { get; set; }
    }
}
