using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai02
{
    public class SachThamKhao : Sach
    {
        public double Thue { get; set; }

        public SachThamKhao() : base() { }

        public SachThamKhao(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan, double thue)
            : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
        {
            Thue = thue;
        }

        public override double TinhThanhTien()
        {
            return (SoLuong * DonGia) + Thue;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Thuế: {Thue,8:N0}       | Thành tiền: {TinhThanhTien(),10:N0} VNĐ";
        }
    }
}
