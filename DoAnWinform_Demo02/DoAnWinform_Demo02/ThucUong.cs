//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnWinform_Demo02
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThucUong
    {
        public ThucUong()
        {
            this.ChiTietHoaDonThanhToans = new HashSet<ChiTietHoaDonThanhToan>();
            this.NguyenLieux = new HashSet<NguyenLieu>();
        }
    
        public string MaThucUong { get; set; }
        public string TenThucUong { get; set; }
        public string MaNhom { get; set; }
        public Nullable<double> DonGia { get; set; }
    
        public virtual ICollection<ChiTietHoaDonThanhToan> ChiTietHoaDonThanhToans { get; set; }
        public virtual NhomThucUong NhomThucUong { get; set; }
        public virtual ICollection<NguyenLieu> NguyenLieux { get; set; }
    }
}
