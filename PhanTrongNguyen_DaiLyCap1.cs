using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De01_22_PhanTrongNguyen_KTL2
{
    public class PhanTrongNguyen_DaiLyCap1:PhanTrongNguyen_KhachHang,IPhiGiamGia
    {
        int thoiGianHopTac;
        public int ThoiGianHopTac
        {
            get { return thoiGianHopTac; }
            set
            {
                if (value > 0)
                    thoiGianHopTac = value;
                else
                    thoiGianHopTac = 3;
            }
        }
        public PhanTrongNguyen_DaiLyCap1()
        {
            this.ThoiGianHopTac = 3;
        }
        public PhanTrongNguyen_DaiLyCap1(string maKhachHang, string tenKhachHang, int soLuong, double giaBan, int thoiGianHopTac):
            base(maKhachHang, tenKhachHang, soLuong, giaBan)
        {
            this.ThoiGianHopTac = thoiGianHopTac;
        }
        public override double TinhChietKhau()
        {
            double chietKhau = 0.3;
            if (ThoiGianHopTac > 3)
            {
                chietKhau += (ThoiGianHopTac - 3) * 0.01;
            }
            // Gioi han muc chiet khau toi da la 0.35 
            chietKhau = Math.Min(chietKhau, 0.35);

            return chietKhau * SoLuong * GiaBan;
        }
        public double PhiGiamGia()
        {
            if (ThoiGianHopTac > 10)
            {
                return 0.5 * TinhThanhTien();
            }
            else
            {
                return 0.3 * TinhThanhTien();   
            }
        }
        public override void Xuat()
        {
            Console.WriteLine("---> DAI LY CAP 1 <---");
            base.Xuat();
            Console.WriteLine("Thoi gian hop tac: " + ThoiGianHopTac);
            Console.WriteLine("Phi giam gia: " + PhiGiamGia());
        }

    }
}
