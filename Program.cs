using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De01_22_PhanTrongNguyen_KTL2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PhanTrongNguyen_KhachHangCaNhan khachHangCaNhan = new PhanTrongNguyen_KhachHangCaNhan();
            //khachHangCaNhan.Xuat();
            //Console.WriteLine("******************************************************");
            //PhanTrongNguyen_DaiLyCap1 daiLyCap1 = new PhanTrongNguyen_DaiLyCap1();
            //daiLyCap1.Xuat();
            //Console.WriteLine("******************************************************");
            //PhanTrongNguyen_KhachHangCongTy khachHangCongTy = new PhanTrongNguyen_KhachHangCongTy();
            //khachHangCongTy.Xuat(); 
            PhanTrongNguyen_DanhSachKhachHang danhSach = new PhanTrongNguyen_DanhSachKhachHang();
            danhSach.DocFile(@"../../KhachHangCongTy.xml");
            danhSach.Xuat();
        }
    }
}
