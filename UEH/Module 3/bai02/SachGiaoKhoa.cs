using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai02
{
    public class SachGiaoKhoa : Sach
    {
        public string TinhTrang { get; set; } 

        public SachGiaoKhoa() : base() { }

        public SachGiaoKhoa(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan, string tinhTrang)
            : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
        {
            TinhTrang = tinhTrang;
        }

        public override double TinhThanhTien()
        {
            if (string.Equals(TinhTrang, "mới", StringComparison.OrdinalIgnoreCase))
                return SoLuong * DonGia;
            else if (string.Equals(TinhTrang, "cũ", StringComparison.OrdinalIgnoreCase))
                return SoLuong * DonGia * 0.5;
            return 0;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Tình trạng: {TinhTrang,-5} | Thành tiền: {TinhThanhTien(),10:N0} VNĐ";
        }
    }
}
