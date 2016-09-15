using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
    }
}
