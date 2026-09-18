using Module03.bai01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module03.bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<ChuyenXe> danhSachChuyenXe = new List<ChuyenXe>()
            {
                new ChuyenXeNoiThanh("NT01", "Nguyễn Văn A", "51A-123.45", 1_200_000, "T01", 85.5),
                new ChuyenXeNoiThanh("NT02", "Trần Văn B", "51B-678.90", 950_000, "T05", 62.0),

                new ChuyenXeNgoaiThanh("NG01", "Lê Văn C", "77C-111.22", 3_500_000, "Đà Lạt", 3),
                new ChuyenXeNgoaiThanh("NG02", "Phạm Văn D", "77D-333.44", 2_800_000, "Vũng Tàu", 2)
            };

            Console.WriteLine("================ DANH SÁCH CHI TIẾT CHUYẾN XE ================\n");
            foreach (var xe in danhSachChuyenXe)
            {
                Console.WriteLine(xe);
            }

            // Tính toán doanh thu
            double tongDoanhThuNoiThanh = 0;
            double tongDoanhThuNgoaiThanh = 0;

            foreach (var xe in danhSachChuyenXe)
            {
                if (xe is ChuyenXeNoiThanh)
                {
                    tongDoanhThuNoiThanh += xe.DoanhThu;
                }
                else if (xe is ChuyenXeNgoaiThanh)
                {
                    tongDoanhThuNgoaiThanh += xe.DoanhThu;
                }
            }

            double tongTatCa = tongDoanhThuNoiThanh + tongDoanhThuNgoaiThanh;

            Console.WriteLine("\n================ BÁO CÁO DOANH THU ================");
            Console.WriteLine($" Doanh thu xe nội thành  : {tongDoanhThuNoiThanh,14:N0}");
            Console.WriteLine($" Doanh thu xe ngoại thành: {tongDoanhThuNgoaiThanh,14:N0}");
            Console.WriteLine($"---------------------------------------------------");
            Console.WriteLine($" TỔNG DOANH THU          : {tongTatCa,14:N0}");
        }
    }
}
