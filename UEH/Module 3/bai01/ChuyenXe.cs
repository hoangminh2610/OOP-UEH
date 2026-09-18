using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module03.bai01
{
    public class ChuyenXe
    {
        public string MaSoChuyen { get; set; }
        public string HoTenTaiXe { get; set; }
        public string SoXe { get; set; }
        public double DoanhThu { get; set; }

        public ChuyenXe() { }

        public ChuyenXe(string maSoChuyen, string hoTenTaiXe, string soXe, double doanhThu)
        {
            MaSoChuyen = maSoChuyen;
            HoTenTaiXe = hoTenTaiXe;
            SoXe = soXe;
            DoanhThu = doanhThu;
        }

        public override string ToString()
        {
            return $"Mã chuyến: {MaSoChuyen,-4} | Tài xế: {HoTenTaiXe,-8} | Biển số: {SoXe,-10} | Doanh thu: {DoanhThu:N0}";
        }
    }
}
