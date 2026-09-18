using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai04
{
    public abstract class Sach
    {
        private string maSach;
        private DateTime ngayNhap;
        private double donGia;
        private int soLuong;
        private string nhaXuatBan;

        public string getMaSach() => maSach;
        public void setMaSach(string value) => maSach = value;

        public DateTime getNgayNhap() => ngayNhap;
        public void setNgayNhap(DateTime value) => ngayNhap = value;

        public double getDonGia() => donGia;
        public void setDonGia(double value) => donGia = value;

        public int getSoLuong() => soLuong;
        public void setSoLuong(int value) => soLuong = value;

        public string getNhaXuatBan() => nhaXuatBan;
        public void setNhaXuatBan(string value) => nhaXuatBan = value;

        public Sach() { }

        public Sach(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan)
        {
            this.maSach = maSach;
            this.ngayNhap = ngayNhap;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.nhaXuatBan = nhaXuatBan;
        }

        public abstract double getThanhTien();

        public override string ToString()
        {
            return $"Mã sách: {maSach,-7} | Ngày: {ngayNhap:dd/MM/yyyy} | Đơn giá: {donGia,8:N0} | SL: {soLuong,3} | NXB: {nhaXuatBan,-12}";
        }
    }
}
