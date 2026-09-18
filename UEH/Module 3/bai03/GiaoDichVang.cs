using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai03
{
    public class GiaoDichVang : GiaoDich
    {
        public string LoaiVang { get; set; }

        public GiaoDichVang() : base() { }

        public GiaoDichVang(string maGiaoDich, DateTime ngayGiaoDich, double donGia, int soLuong, string loaiVang)
            : base(maGiaoDich, ngayGiaoDich, donGia, soLuong)
        {
            LoaiVang = loaiVang;
        }

        public override double TinhThanhTien()
        {
            return SoLuong * DonGia;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Loại vàng: {LoaiVang,-6} | Thành tiền: {TinhThanhTien(),14:N0}";
        }
    }
}
