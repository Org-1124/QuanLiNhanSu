using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class PhongBanDAO
    {
        public static SqlConnection con;

        public static DataTable LoadDataPB()
        {
            string sTruyVan = "select a.IDPhong, a.TenPhong, a.IDTruongPhong, a.NgayNhanChuc from  tblPhongBan a, tblNhanVien b where a.IDTruongPhong =b.IDNhanVien";
            
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static DataTable ID_PBMax()
        {
            string sTruyVan = "select max(IDPhong) from tblPhongBan";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
        public static bool ThemPB(PhongBanDTO pb)
        {
            try
            {
                string sTruyVan = string.Format("Insert into tblPhongBan(IDPhong,TenPhong,IDTruongPhong,NgayNhanChuc) values ({0},N'{1}',{2},'{3}')", pb.IdPhong, pb.TenPhong, pb.IdTruongPhong, pb.NgayNhanChuc);
                con = DataProvider.KetNoi();
                DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
                string s = string.Format("Update tblnhanvien set idphong = {0},chucvu=N'trưởng phòng' where IDnhanvien={1}", pb.IdPhong, pb.IdTruongPhong);
                DataProvider.ThucThiTruyVan(s, con);
                DataProvider.DongKetNoi(con);
                return true;
            }

            catch
            {
                return false;
            }
        }

        public static bool SuaPB(PhongBanDTO pb)
        {
            try
            {
                con = DataProvider.KetNoi();
                string s = string.Format("Update tblnhanvien set idphong = {0},chucvu=N'trưởng phòng' where IDnhanvien={1}",pb.IdPhong, pb.IdTruongPhong);
                DataProvider.ThucThiTruyVan(s, con);
                string sTruyVan = string.Format("Update tblPhongBan set TenPhong = N'{0}',IDTruongPhong={1},NgayNhanChuc='{2}' where IDPhong={3}", pb.TenPhong, pb.IdTruongPhong, pb.NgayNhanChuc, pb.IdPhong);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaPB(PhongBanDTO pb)
        {
            try
            {
                con = DataProvider.KetNoi();
                string s = string.Format("delete tblNhanVien where IDPhong={0}",pb.IdPhong);
                DataProvider.ThucThiTruyVan(s, con);
                string sTruyVan = string.Format("Delete tblPhongBan where IDPhong={0}", pb.IdPhong);
                DataProvider.ThucThiTruyVan(sTruyVan, con);
                DataProvider.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable SearchPB(string tim)
        {
            string sTruyVan = "select a.IDPhong, a.TenPhong, a.IDTruongPhong, a.NgayNhanChuc from  tblPhongBan a, tblNhanVien b where a.IDTruongPhong =b.IDNhanVien and a.TenPhong like N'%" + tim + "%'";
            con = DataProvider.KetNoi();
            DataTable dt = DataProvider.LayDataTable(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}
