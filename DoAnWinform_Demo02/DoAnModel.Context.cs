﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DOAN02Entities : DbContext
    {
        public DOAN02Entities()
            : base("name=DOAN02Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietHoaDonCungCap> ChiTietHoaDonCungCaps { get; set; }
        public virtual DbSet<ChiTietHoaDonThanhToan> ChiTietHoaDonThanhToans { get; set; }
        public virtual DbSet<HoaDonCungCap> HoaDonCungCaps { get; set; }
        public virtual DbSet<HoaDonThanhToan> HoaDonThanhToans { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichLamViec> LichLamViecs { get; set; }
        public virtual DbSet<LoaiNguyenLieu> LoaiNguyenLieux { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieux { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomThucUong> NhomThucUongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThucUong> ThucUongs { get; set; }
    }
}