using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai04
{
    public class SachThamKhao : Sach
    {
        private double thue;

        public double getThue() => thue;
        public void setThue(double value) => thue = value;

        public SachThamKhao() : base() { }

        public SachThamKhao(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan, double thue)
            : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
        {
            this.thue = thue;
        }

        public override double getThanhTien()
        {
            return (getSoLuong() * getDonGia()) + thue;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Thuế: {thue,7:N0} | Thành tiền: {getThanhTien(),10:N0} VNĐ";
        }
    }
}
