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
    
    public partial class HoaDonThanhToan
    {
        public HoaDonThanhToan()
        {
            this.ChiTietHoaDonThanhToans = new HashSet<ChiTietHoaDonThanhToan>();
        }
    
        public string MaHD { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
    
        public virtual ICollection<ChiTietHoaDonThanhToan> ChiTietHoaDonThanhToans { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
