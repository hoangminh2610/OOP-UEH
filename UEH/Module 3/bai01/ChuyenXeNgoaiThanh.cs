using Module03.bai01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module03.bai01
{
    public class ChuyenXeNgoaiThanh : ChuyenXe
    {
        public string NoiDen { get; set; }
        public int SoNgayDiDuoc { get; set; }

        public ChuyenXeNgoaiThanh() : base() { }

        public ChuyenXeNgoaiThanh(string maSoChuyen, string hoTenTaiXe, string soXe, double doanhThu, string noiDen, int soNgayDiDuoc)
            : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
        {
            NoiDen = noiDen;
            SoNgayDiDuoc = soNgayDiDuoc;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Nơi đến: {NoiDen,-12} | Số ngày: {SoNgayDiDuoc} ngày";
        }
    }
}
