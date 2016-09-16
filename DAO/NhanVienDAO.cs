using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class NhanVienDAO
    {
        public static SqlConnection con;

        public static DataTable LoadDataNV()
        {
            string sTruyVan = "select a.IDNhanVien,a.HoTen,a.NgaySinh,a.GioiTinh,a.QueQuan,a.ChucVu,b.HoTen 'QuanLi',a.Luong,TenPhong,a.IDPhong,a.IDQuanLi from (tblNhanVien a left join tblNhanVien b on a.IDQuanLi = b.IDNhanVien) join tblPhongBan on a.IDPhong = tblPhongBan.IDPhong";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable SearchNhanVien(string sTruyVan)
        {
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable HienThiYeuCau(string a)
        {
            string sTruyVan = "select * from tblNhanVien where idNhanVien=";
            sTruyVan += a;
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool ThemNV(NhanVienDTO nv)
        {
            try
            {
                string sTruyVan = string.Format("Insert into tblNhanVien(IDNhanVien,HoTen,NgaySinh,GioiTinh,QueQuan,ChucVu,IDQuanLy,Luong,IDPhong) values (N'{0}',N'{1}',N'{2}','{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}')", nv.IDNhanVien, nv.HoTen, nv.NgaySinh, nv.GioiTinh, nv.QueQuan, nv.ChucVu, nv.IDQuanLi, nv.Luong, nv.IdPhong);
                con = DataProvider.KetNoi();
                DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }

            catch
            {
                return false;
            }
        }

        public static bool SuaNV(NhanVienDTO nv)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Update tblNhanVien set HoTen = N'{0}',NgaySinh='{1}',GioiTinh = N'{2}', QueQuan=N'{3}',ChucVu='{4}',IDQuanLy='{5}',Luong='{6}',IDPhong='{7}' where IDNhanVien='{8}'", nv.HoTen, nv.NgaySinh, nv.GioiTinh, nv.QueQuan, nv.ChucVu, nv.IDQuanLi, nv.Luong, nv.IdPhong);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaNV(NhanVienDTO nv)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Delete tblNhanVien where IDNhanVien=N'{0}'", nv.IDNhanVien);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable LayThongTinNhanVien(int IDNhanVien)
        {
            string sTruyVan = string.Format("Select * From tblNhanVien where IDNhanVien='{0}'", IDNhanVien);
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}
