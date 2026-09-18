using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai02
{
    public abstract class Sach
    {
        public string MaSach { get; set; }
        public DateTime NgayNhap { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public string NhaXuatBan { get; set; }

        public Sach() { }

        public Sach(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan)
        {
            MaSach = maSach;
            NgayNhap = ngayNhap;
            DonGia = donGia;
            SoLuong = soLuong;
            NhaXuatBan = nhaXuatBan;
        }

        public abstract double TinhThanhTien();

        public override string ToString()
        {
            return $"Mã: {MaSach,-7} | Ngày: {NgayNhap:dd/MM/yyyy} | Đơn giá: {DonGia,8:N0} | SL: {SoLuong,3} | NXB: {NhaXuatBan,-12}";
        }
    }
}
