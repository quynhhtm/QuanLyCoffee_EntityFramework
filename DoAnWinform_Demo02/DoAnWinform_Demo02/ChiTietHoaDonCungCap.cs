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
    
    public partial class ChiTietHoaDonCungCap
    {
        public string MaNL { get; set; }
        public string MaHD { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> DonGia { get; set; }
    
        public virtual HoaDonCungCap HoaDonCungCap { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
