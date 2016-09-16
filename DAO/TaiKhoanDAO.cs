using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class TaiKhoanDAO
    {
        public static SqlConnection con;

        public static DataTable LoadDataTK()
        {
            string sTruyVan = "select * from tblTaiKhoan";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static DataTable HienThiYeuCauTK(string a)
        {
            string sTruyVan = "select * from tblTaiKhoan where TenDangNhap=";
            sTruyVan += a;
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static bool ThemTK(TaiKhoanDTO tk)
        {
            try
            {
                string sTruyVan = string.Format("Insert into tblTaiKhoan(TenDangNhap,MatKhau) values (N'{0}',N'{1}')", tk.TenDangNhap, tk.MatKhau);
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

        public static bool SuaTK(TaiKhoanDTO tk)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Update tblTaiKhoan set MatKhau = N'{0}' where TenDangNhap='{1}'", tk.MatKhau, tk.TenDangNhap);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaTK(TaiKhoanDTO tk)
        {
            try
            {
                con = DataProvider.KetNoi();
                string sTruyVan = string.Format("Delete tblTaiKhoan where TenDangNhap=N'{0}'", tk.TenDangNhap);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
