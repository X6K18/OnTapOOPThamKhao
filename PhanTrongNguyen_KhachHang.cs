using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De01_22_PhanTrongNguyen_KTL2
{
    public abstract class PhanTrongNguyen_KhachHang
    {
        string maKhachHang, tenKhachHang;
        int soLuong;
        double giaBan;

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set
            {
                if (value.Length == 6 && value.StartsWith("KH") && value.Substring(2).All(Char.IsDigit))
                {
                    maKhachHang = value;    
                }
                else
                {
                    Console.WriteLine("Ma khach hang khong hop le!");
                    maKhachHang = "KH0001";
                }
            }
        }

        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }

        public PhanTrongNguyen_KhachHang()
        {
            this.MaKhachHang = "KH0002";
            this.TenKhachHang = "Phan Trong Nguyen";
            this.SoLuong = 90;
            this.GiaBan = 1000000;
        }
        public PhanTrongNguyen_KhachHang(string maKhachHang, string tenKhachHang, int soLuong, double giaBan)
        {
            this.MaKhachHang = maKhachHang;
            this.TenKhachHang = tenKhachHang;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
        }
        public abstract double TinhChietKhau();
        public double TinhThueVAT()
        {
            return 0.1 * SoLuong * GiaBan;
        }
        public double TinhThanhTien()
        {
            return SoLuong * GiaBan - TinhChietKhau() + TinhThueVAT();
        }
        public virtual void Xuat()
        {
            Console.WriteLine("\tMa khach hang\tTen khach hang\tSo luong\tGia ban\tChieu khau\tThanh tien");
            Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", MaKhachHang, TenKhachHang, SoLuong, GiaBan, TinhChietKhau(), TinhThanhTien());
        }
    }
}
