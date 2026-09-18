using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<GiaoDich> danhSachGD = new List<GiaoDich>()
            {
                new GiaoDichVang("GDV01", new DateTime(2024, 5, 10), 82_000_000, 5, "9999"),
                new GiaoDichVang("GDV02", new DateTime(2024, 5, 12), 1_200_000_000, 2, "Vàng miếng SJC"), 
                new GiaoDichVang("GDV03", new DateTime(2024, 5, 15), 75_000_000, 10, "24K"),

                new GiaoDichTienTe("GDT01", new DateTime(2024, 5, 18), 100, 50, 25_400, "USD"),
                new GiaoDichTienTe("GDT02", new DateTime(2024, 5, 20), 200, 30, 27_200, "Euro"),
                new GiaoDichTienTe("GDT03", new DateTime(2024, 5, 22), 1_500_000_000, 1, 1, "VND") 
            };

            Console.WriteLine("================ DANH SÁCH CÁC GIAO DỊCH ================\n");
            foreach (var gd in danhSachGD)
            {
                Console.WriteLine(gd);
            }

            int tongSoLuongVang = danhSachGD.OfType<GiaoDichVang>().Sum(g => g.SoLuong);
            int tongSoLuongTienTe = danhSachGD.OfType<GiaoDichTienTe>().Sum(g => g.SoLuong);

            Console.WriteLine("\n================ TỔNG SỐ LƯỢNG TỪNG LOẠI ================");
            Console.WriteLine($" Tổng số lượng giao dịch Vàng    : {tongSoLuongVang}");
            Console.WriteLine($" Tổng số lượng giao dịch Tiền tệ : {tongSoLuongTienTe}");

            var dsGDTienTe = danhSachGD.OfType<GiaoDichTienTe>().ToList();
            double tbThanhTienTienTe = dsGDTienTe.Any() ? dsGDTienTe.Average(g => g.TinhThanhTien()) : 0;

            Console.WriteLine("\n================ TRUNG BÌNH THÀNH TIỀN TIỀN TỆ ================");
            Console.WriteLine($" Trung bình thành tiền giao dịch Tiền tệ: {tbThanhTienTienTe:N0} VNĐ");

            Console.WriteLine("\n================ CÁC GIAO DỊCH CÓ ĐƠN GIÁ > 1 TỶ ================");
            var gdLonHon1Ty = danhSachGD.Where(g => g.DonGia > 1_000_000_000).ToList();

            if (gdLonHon1Ty.Any())
            {
                foreach (var item in gdLonHon1Ty)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Không có giao dịch nào có đơn giá lớn hơn 1 tỷ VNĐ.");
            }
        }
    }
}
