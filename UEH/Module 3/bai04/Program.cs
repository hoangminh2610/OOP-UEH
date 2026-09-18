using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            DanhSachSach quanLy = new DanhSachSach(50);

            quanLy.them(new SachGiaoKhoa("GK01", new DateTime(2024, 1, 10), 30_000, 10, "Giáo Dục", true));
            quanLy.them(new SachGiaoKhoa("GK02", new DateTime(2024, 2, 15), 40_000, 15, "Kim Đồng", false));
            quanLy.them(new SachGiaoKhoa("GK03", new DateTime(2024, 3, 20), 50_000, 8, "Giáo Dục", true));
            quanLy.them(new SachThamKhao("TK01", new DateTime(2024, 1, 5), 120_000, 5, "Trẻ", 20_000));
            quanLy.them(new SachThamKhao("TK02", new DateTime(2024, 2, 18), 80_000, 10, "Kim Đồng", 30_000));

            int chon;
            do
            {
                Console.WriteLine("\n================ MENU QUẢN LÝ SÁCH ================");
                Console.WriteLine("1. Thêm sách giáo khoa");
                Console.WriteLine("2. Thêm sách tham khảo");
                Console.WriteLine("3. Xuất toàn bộ danh sách sách");
                Console.WriteLine("4. Tính tổng thành tiền từng loại sách");
                Console.WriteLine("5. Tìm sách giáo khoa theo Nhà xuất bản");
                Console.WriteLine("6. Tìm thành tiền cao nhất");
                Console.WriteLine("0. Thoát chương trình");
                Console.Write("Mời bạn chọn chức năng (0-6): ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    chon = -1;
                }

                Console.WriteLine();
                switch (chon)
                {
                    case 1:
                        Console.WriteLine("--- NHẬP SÁCH GIÁO KHOA ---");
                        Console.Write("Mã sách: "); string maGK = Console.ReadLine();
                        Console.Write("Đơn giá: "); double giaGK = double.Parse(Console.ReadLine());
                        Console.Write("Số lượng: "); int slGK = int.Parse(Console.ReadLine());
                        Console.Write("Nhà xuất bản: "); string nxbGK = Console.ReadLine();
                        Console.Write("Tình trạng (1: Mới, 0: Cũ): "); bool ttGK = Console.ReadLine().Trim() == "1";

                        SachGiaoKhoa sgk = new SachGiaoKhoa(maGK, DateTime.Now, giaGK, slGK, nxbGK, ttGK);
                        if (quanLy.them(sgk)) Console.WriteLine("=> Thêm thành công!");
                        else Console.WriteLine("=> Thất bại (Trùng mã sách hoặc bộ nhớ đầy)!");
                        break;

                    case 2:
                        Console.WriteLine("--- NHẬP SÁCH THAM KHẢO ---");
                        Console.Write("Mã sách: "); string maTK = Console.ReadLine();
                        Console.Write("Đơn giá: "); double giaTK = double.Parse(Console.ReadLine());
                        Console.Write("Số lượng: "); int slTK = int.Parse(Console.ReadLine());
                        Console.Write("Nhà xuất bản: "); string nxbTK = Console.ReadLine();
                        Console.Write("Tiền thuế: "); double thue = double.Parse(Console.ReadLine());

                        SachThamKhao stk = new SachThamKhao(maTK, DateTime.Now, giaTK, slTK, nxbTK, thue);
                        if (quanLy.them(stk)) Console.WriteLine("=> Thêm thành công!");
                        else Console.WriteLine("=> Thất bại (Trùng mã sách hoặc bộ nhớ đầy)!");
                        break;

                    case 3:
                        Console.WriteLine("--- DANH SÁCH SÁCH HIỆN CÓ ---");
                        Console.WriteLine(quanLy.ToString());
                        break;

                    case 4:
                        Console.WriteLine("--- TỔNG THÀNH TIỀN TỪNG LOẠI ---");
                        Console.WriteLine($"* Tổng tiền Sách Giáo Khoa: {quanLy.tinhTongThanhTienSGK():N0} VNĐ");
                        Console.WriteLine($"* Tổng tiền Sách Tham Khảo: {quanLy.tinhTongThanhTienSTK():N0} VNĐ");
                        break;

                    case 5:
                        Console.Write("Nhập tên nhà xuất bản cần tìm: ");
                        string nxb = Console.ReadLine()?.Trim();
                        var ketQua = quanLy.timSachGiaoKhoaTheoNXB(nxb);
                        if (ketQua.Count > 0)
                        {
                            Console.WriteLine($"\nSách giáo khoa của NXB '{nxb}':");
                            foreach (var s in ketQua) Console.WriteLine(s);
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy sách giáo khoa nào của NXB '{nxb}'.");
                        }
                        break;

                    case 6:
                        double max = quanLy.timThanhTienCaoNhat();
                        Console.WriteLine($"Thành tiền cao nhất: {max:N0} VNĐ");
                        Console.WriteLine("Chi tiết cuốn sách đạt cao nhất:");
                        foreach (var s in quanLy.getList())
                        {
                            if (s.getThanhTien() == max) Console.WriteLine($"-> {s}");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Đã thoát chương trình!");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại!");
                        break;
                }
            } while (chon != 0);
        }
    }
}
