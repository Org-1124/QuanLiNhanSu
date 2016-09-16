using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAO;
using DTO;
namespace QuanLiNhanSu
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = NhanVienDAO.LoadDataNV();
            SetHeaderColumn();
        }
        public void SetHeaderColumn()
        {
            dgvNhanVien.Columns["IDNhanVien"].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvNhanVien.Columns["QueQuan"].HeaderText = "Quê quán";
            dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức vụ";
            dgvNhanVien.Columns["QuanLi"].HeaderText = "Quản lí";
            dgvNhanVien.Columns["Luong"].HeaderText = "Lương";
            dgvNhanVien.Columns["TenPhong"].HeaderText = "Tên phòng";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = DataProvider.KetNoi();
            string sTruyVan = "select a.IDNhanVien,a.HoTen,a.NgaySinh,a.GioiTinh,a.QueQuan,a.ChucVu,b.HoTen 'QuanLi',a.Luong,TenPhong from (tblNhanVien a left join tblNhanVien b on a.IDQuanLi = b.IDNhanVien) join tblPhongBan on a.IDPhong = tblPhongBan.IDPhong and a.HoTen like N'%" + txtTimKiem.Text + "%'";
            dgvNhanVien.DataSource = NhanVienDAO.SearchNhanVien(sTruyVan);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con;
                con = DataProvider.KetNoi();
                string sTruyVan = "select a.IDNhanVien,a.HoTen,a.NgaySinh,a.GioiTinh,a.QueQuan,a.ChucVu,b.HoTen 'QuanLi',a.Luong,TenPhong from (tblNhanVien a left join tblNhanVien b on a.IDQuanLi = b.IDNhanVien) join tblPhongBan on a.IDPhong = tblPhongBan.IDPhong and a.HoTen like N'%" + txtTimKiem.Text + "%'";
                dgvNhanVien.DataSource = NhanVienDAO.SearchNhanVien(sTruyVan);
            }
        }
    }
}
