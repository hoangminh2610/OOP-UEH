using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Sach> danhSachSach = new List<Sach>()
            {
                new SachGiaoKhoa("GK01", new DateTime(2024, 1, 10), 30_000, 10, "Giáo Dục", "mới"),
                new SachGiaoKhoa("GK02", new DateTime(2024, 2, 15), 45_000, 15, "Kim Đồng", "cũ"),
                new SachGiaoKhoa("GK03", new DateTime(2024, 3, 20), 50_000, 8, "Giáo Dục", "mới"),

                new SachThamKhao("TK01", new DateTime(2024, 1, 5), 120_000, 5, "Trẻ", 25_000),
                new SachThamKhao("TK02", new DateTime(2024, 2, 18), 85_000, 12, "Tổng Hợp", 40_000),
                new SachThamKhao("TK03", new DateTime(2024, 4, 12), 150_000, 4, "Kim Đồng", 30_000)
            };

            Console.WriteLine("================ DANH SÁCH TẤT CẢ SÁCH ================\n");
            foreach (var sach in danhSachSach)
            {
                Console.WriteLine(sach);
            }

            double tongGK = danhSachSach.OfType<SachGiaoKhoa>().Sum(s => s.TinhThanhTien());
            double tongTK = danhSachSach.OfType<SachThamKhao>().Sum(s => s.TinhThanhTien());

            Console.WriteLine("\n================ TỔNG THÀNH TIỀN ================");
            Console.WriteLine($"* Tổng tiền Sách Giáo Khoa: {tongGK:N0} VNĐ");
            Console.WriteLine($"* Tổng tiền Sách Tham Khảo: {tongTK:N0} VNĐ");

            Console.WriteLine("\n================ TÌM KIẾM THEO NXB ================");
            Console.Write("Nhập tên nhà xuất bản K: ");
            string nxbK = Console.ReadLine()?.Trim();

            var ketQua = danhSachSach.OfType<SachGiaoKhoa>()
                                     .Where(s => string.Equals(s.NhaXuatBan, nxbK, StringComparison.OrdinalIgnoreCase));

            if (ketQua.Any())
            {
                Console.WriteLine($"\nSách giáo khoa của NXB '{nxbK}':");
                foreach (var item in ketQua) Console.WriteLine(item);
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sách giáo khoa của NXB '{nxbK}'.");
            }

            Console.WriteLine("\n================ THÀNH TIỀN CAO NHẤT ================");
            double maxTien = danhSachSach.Max(s => s.TinhThanhTien());
            Console.WriteLine($"Mức cao nhất: {maxTien:N0}");
            foreach (var item in danhSachSach.Where(s => s.TinhThanhTien() == maxTien))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
