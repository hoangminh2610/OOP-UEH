using Module03.bai01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module03.bai01
{
    public class ChuyenXeNoiThanh : ChuyenXe
    {
        public string SoTuyen { get; set; }
        public double SoKmDiDuoc { get; set; }

        public ChuyenXeNoiThanh() : base() { }

        public ChuyenXeNoiThanh(string maSoChuyen, string hoTenTaiXe, string soXe, double doanhThu, string soTuyen, double soKmDiDuoc)
            : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
        {
            SoTuyen = soTuyen;
            SoKmDiDuoc = soKmDiDuoc;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Tuyến số: {SoTuyen,-5} | Quãng đường: {SoKmDiDuoc} km";
        }
    }
}
