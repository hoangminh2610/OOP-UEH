using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3.bai04
{
    public class DanhSachSach
    {
        private Sach[] list;
        private int count;

        public DanhSachSach(int n)
        {
            list = new Sach[n];
            count = 0;
        }

        public bool them(Sach s)
        {
            if (count >= list.Length) return false;

            for (int i = 0; i < count; i++)
            {
                if (list[i].getMaSach().Equals(s.getMaSach(), StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            list[count] = s;
            count++;
            return true;
        }

        public override string ToString()
        {
            if (count == 0) return "Danh sách rỗng.";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.AppendLine(list[i].ToString());
            }
            return sb.ToString();
        }

        public double tinhTongThanhTienSGK()
        {
            double tong = 0;
            for (int i = 0; i < count; i++)
            {
                if (list[i] is SachGiaoKhoa)
                {
                    tong += list[i].getThanhTien();
                }
            }
            return tong;
        }

        public double tinhTongThanhTienSTK()
        {
            double tong = 0;
            for (int i = 0; i < count; i++)
            {
                if (list[i] is SachThamKhao)
                {
                    tong += list[i].getThanhTien();
                }
            }
            return tong;
        }

        public List<Sach> timSachGiaoKhoaTheoNXB(string nxb)
        {
            List<Sach> ketQua = new List<Sach>();
            for (int i = 0; i < count; i++)
            {
                if (list[i] is SachGiaoKhoa &&
                    string.Equals(list[i].getNhaXuatBan(), nxb, StringComparison.OrdinalIgnoreCase))
                {
                    ketQua.Add(list[i]);
                }
            }
            return ketQua;
        }

        public double timThanhTienCaoNhat()
        {
            if (count == 0) return 0;

            double max = list[0].getThanhTien();
            for (int i = 1; i < count; i++)
            {
                if (list[i].getThanhTien() > max)
                {
                    max = list[i].getThanhTien();
                }
            }
            return max;
        }

        public Sach[] getList()
        {
            Sach[] validList = new Sach[count];
            Array.Copy(list, validList, count);
            return validList;
        }
    }
}
