using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De01_22_PhanTrongNguyen_KTL2
{
    public class PhanTrongNguyen_KhachHangCaNhan:PhanTrongNguyen_KhachHang
    {
        double khoangCach;
        public double KhoangCach { get => khoangCach; set => khoangCach = value; }

        public PhanTrongNguyen_KhachHangCaNhan()
        {
            this.KhoangCach = khoangCach;
        }

        public PhanTrongNguyen_KhachHangCaNhan(string maKhachHang, string tenKhachHang, int soLuong, double giaBan, double khoangCach):
            base(maKhachHang, tenKhachHang, soLuong, giaBan)
        {
            this.KhoangCach = khoangCach;
        }

        public override double TinhChietKhau()
        {
            if (KhoangCach < 10)
            {
                return 0.03 * SoLuong * GiaBan + 20000;
            }
            else if (SoLuong >= 5)
            {
                return 0.03 * SoLuong * GiaBan;
            }
            else
            {
                return 0;
            }
        }
        public override void Xuat()
        {
            Console.WriteLine("---> KHACH HANG CA NHAN <---");
            base.Xuat();
            Console.WriteLine("Khoang cach: " + KhoangCach);
        }

    }
}
