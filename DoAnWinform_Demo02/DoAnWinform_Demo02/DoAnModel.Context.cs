﻿//------------------------------------------------------------------------------
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
    
        public DbSet<ChiTietHoaDonCungCap> ChiTietHoaDonCungCaps { get; set; }
        public DbSet<ChiTietHoaDonThanhToan> ChiTietHoaDonThanhToans { get; set; }
        public DbSet<HoaDonCungCap> HoaDonCungCaps { get; set; }
        public DbSet<HoaDonThanhToan> HoaDonThanhToans { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LichLamViec> LichLamViecs { get; set; }
        public DbSet<LoaiNguyenLieu> LoaiNguyenLieux { get; set; }
        public DbSet<NguyenLieu> NguyenLieux { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NhomThucUong> NhomThucUongs { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<ThucUong> ThucUongs { get; set; }
    }
}