using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai03
{
    public abstract class GiaoDich
    {
        public string MaGiaoDich { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }

        public GiaoDich() { }

        public GiaoDich(string maGiaoDich, DateTime ngayGiaoDich, double donGia, int soLuong)
        {
            MaGiaoDich = maGiaoDich;
            NgayGiaoDich = ngayGiaoDich;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public abstract double TinhThanhTien();

        public override string ToString()
        {
            return $"Mã GD: {MaGiaoDich,-7} | Ngày: {NgayGiaoDich:dd/MM/yyyy} | Đơn giá: {DonGia,13:N0} | SL: {SoLuong,3}";
        }
    }
}
