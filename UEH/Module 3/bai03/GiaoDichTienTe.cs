using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai03
{
    public class GiaoDichTienTe : GiaoDich
    {
        public double TiGia { get; set; }
        public string LoaiTienTe { get; set; } 

        public GiaoDichTienTe() : base() { }

        public GiaoDichTienTe(string maGiaoDich, DateTime ngayGiaoDich, double donGia, int soLuong, double tiGia, string loaiTienTe)
            : base(maGiaoDich, ngayGiaoDich, donGia, soLuong)
        {
            TiGia = tiGia;
            LoaiTienTe = loaiTienTe;
        }

        public override double TinhThanhTien()
        {
            if (string.Equals(LoaiTienTe, "USD", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(LoaiTienTe, "Euro", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(LoaiTienTe, "EUR", StringComparison.OrdinalIgnoreCase))
            {
                return SoLuong * DonGia * TiGia;
            }
            return SoLuong * DonGia; 
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Loại TT: {LoaiTienTe,-5} (Tỉ giá: {TiGia,6:N0}) | Thành tiền: {TinhThanhTien(),14:N0}";
        }
    }
}
