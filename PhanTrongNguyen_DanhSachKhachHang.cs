using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;

namespace De01_22_PhanTrongNguyen_KTL2
{
    public class PhanTrongNguyen_DanhSachKhachHang
    {
        string tenCongTy, diaChi, dienThoai;
        List<PhanTrongNguyen_KhachHang> lst = new List<PhanTrongNguyen_KhachHang>();

        public string TenCongTy { get => tenCongTy; set => tenCongTy = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public List<PhanTrongNguyen_KhachHang> Lst { get => lst; set => lst = value; }

        public PhanTrongNguyen_DanhSachKhachHang()
        {
            this.TenCongTy = string.Empty;
            this.DiaChi = string.Empty;
            this.DienThoai = string.Empty;
            this.Lst = new List<PhanTrongNguyen_KhachHang>();
        }

        public void DocFile(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            TenCongTy = doc.SelectSingleNode("/KhachHangCongTy/TenCongTy").InnerText;
            DiaChi = doc.SelectSingleNode("/KhachHangCongTy/DiaChi").InnerText;
            DienThoai = doc.SelectSingleNode("/KhachHangCongTy/DienThoai").InnerText;
            XmlNodeList nodeList = doc.SelectNodes("/KhachHangCongTy/DanhSach/KhachHang");
            foreach(XmlNode node in nodeList)
            {
                PhanTrongNguyen_KhachHang khachHang;
                string loai = node["Loai"].InnerText;
                string maKhachHang = node["MaKhachHang"].InnerText;
                string tenKhachHang = node["TenKhachHang"].InnerText;
                int soLuong = int.Parse(node["SoLuong"].InnerText);
                double giaBan = double.Parse(node["GiaBan"].InnerText);

                if (loai == "1")
                {
                    double khoangCach = double.Parse(node["KhoangCach"].InnerText);
                    khachHang = new PhanTrongNguyen_KhachHangCaNhan(maKhachHang, tenKhachHang, soLuong, giaBan, khoangCach);
                }
                else if (loai == "2")
                {
                    int thoiGianHopTac = int.Parse(node["ThoiGianHopTac"].InnerText);
                    khachHang = new PhanTrongNguyen_DaiLyCap1(maKhachHang, tenKhachHang, soLuong, giaBan, thoiGianHopTac);
                }
                else
                {
                    int soLuongNhanVien = int.Parse(node["SoLuongNhanVien"].InnerText);
                    khachHang = new PhanTrongNguyen_KhachHangCongTy(maKhachHang, tenKhachHang, soLuong, giaBan, soLuongNhanVien);
                }
                Lst.Add(khachHang);
            }
        }

        public void Xuat()
        {
            Console.WriteLine("---> DANH SACH KHACH HANG <---");
            Console.WriteLine("Ten cong ty: " + TenCongTy);
            Console.WriteLine("Dien thoai: " + DienThoai);
            Console.WriteLine("Dia chi: " + DiaChi);
            foreach(PhanTrongNguyen_KhachHang khachHang in Lst)
            {
                khachHang.Xuat();   
            }
        }

        public double TinhTong()
        {
            return Lst.Sum(t => t.TinhThanhTien());
        }

        public double TinhTongPhiGiamGia()
        {
            return Lst.OfType<IPhiGiamGia>().Sum(t => t.PhiGiamGia());  
        }

        public double TinhTongKhachHangCongTy()
        {
            return Lst.OfType<PhanTrongNguyen_KhachHangCongTy>().Sum(t => t.TinhThanhTien());
        }

        public void TimKhachHang(string maKhachHangX)
        {
            bool timThay = false;
            foreach(PhanTrongNguyen_KhachHang khachHang in Lst)
            {
                if (khachHang.MaKhachHang == maKhachHangX)
                {
                    khachHang.Xuat();
                    timThay = true;
                    break;
                }
            }
            if (!timThay)
            {
                Console.WriteLine("Khach hang khong ton tai!");
            }
        }

        public void XuatDaiLyCap1()
        {
            foreach(PhanTrongNguyen_KhachHang khachHang in Lst)
            {
                if (khachHang is PhanTrongNguyen_DaiLyCap1)
                {
                    khachHang.Xuat();
                }
            }
        }

        public double TimPhiGiamGiaLonNhat()
        {
            return Lst.OfType<IPhiGiamGia>().Max(t => t.PhiGiamGia());
        }

        public void XuatKhachHangMax()
        {
            double maxPhiGiamGia = TimPhiGiamGiaLonNhat();
            foreach(PhanTrongNguyen_KhachHang khachHang in Lst)
            {
                if (khachHang is IPhiGiamGia)
                {
                    IPhiGiamGia khachHangGiamGia = (IPhiGiamGia)khachHang;
                    if (khachHangGiamGia.PhiGiamGia() == maxPhiGiamGia)
                    {
                        khachHang.Xuat();
                        break;
                    }
                }
            }
        }
    }
}
