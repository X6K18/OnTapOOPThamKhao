using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De01_22_PhanTrongNguyen_KTL2
{
    public class PhanTrongNguyen_KhachHangCongTy:PhanTrongNguyen_KhachHang,IPhiGiamGia
    {
        int soLuongNhanVien;
        public int SoLuongNhanVien
        {
            get { return soLuongNhanVien; }
            set
            {
                if (value > 0)
                    soLuongNhanVien = value;
                else
                    soLuongNhanVien = 200;
            }
        }
        public PhanTrongNguyen_KhachHangCongTy()
        {
            this.SoLuongNhanVien = 1000;
        }
        public PhanTrongNguyen_KhachHangCongTy(string maKhachHang, string tenKhachHang, int soLuong, double giaBan, int soLuongNhanVien):
            base(maKhachHang, tenKhachHang, soLuong, giaBan)
        {
            this.SoLuongNhanVien = soLuongNhanVien; 
        }
        public override double TinhChietKhau()
        {
            if (SoLuongNhanVien > 1000)
            {
                return 0.03;
            }
            else if (SoLuongNhanVien > 5000)
            {
                return 0.05;
            }
            else
                return 0;
        }
        public double PhiGiamGia()
        {
            return 0.2 * TinhThanhTien();
        }
        public override void Xuat()
        {
            Console.WriteLine("---> KHACH HANG CONG TY <---");
            base.Xuat();
            Console.WriteLine("So luong nhan vien: " + SoLuongNhanVien);
            Console.WriteLine("Phi giam gia: " + PhiGiamGia());
        }
    }
}
