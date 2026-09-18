using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai04
{
    public class SachGiaoKhoa : Sach
    {
        private bool tinhTrang; 

        public bool getTinhTrang() => tinhTrang;
        public void setTinhTrang(bool value) => tinhTrang = value;

        public SachGiaoKhoa() : base() { }

        public SachGiaoKhoa(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan, bool tinhTrang)
            : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
        {
            this.tinhTrang = tinhTrang;
        }

        public override double getThanhTien()
        {
            if (tinhTrang) 
            {
                return getSoLuong() * getDonGia();
            }
            // Cũ giảm 50%
            return getSoLuong() * getDonGia() * 0.5;
        }

        public override string ToString()
        {
            string tt = tinhTrang ? "Mới" : "Cũ";
            return $"{base.ToString()} | Trạng thái: {tt,-4} | Thành tiền: {getThanhTien(),10:N0} VNĐ";
        }
    }
}
