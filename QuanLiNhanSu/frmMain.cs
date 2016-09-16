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
            btnLuu.Visible = false;
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            txtHoTen.Focus();
            txtIDNhanVien.ReadOnly=true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = false;
        }

        private void dgvNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvNhanVien.Rows[e.RowIndex];
            txtIDNhanVien.Text = row.Cells[0].Value.ToString();
            txtHoTen.Text = row.Cells[1].Value.ToString();
            dtpNgaySinh.Text = row.Cells[2].Value.ToString();
            if(row.Cells[3].Value.ToString().ToUpper()=="NAM")
            {
                rdbNam.Checked = true;
              
            }
            else
            {
                rdbNu.Checked = false;
            }
            txtQueQuan.Text = row.Cells[4].Value.ToString();
            txtChucVu.Text = row.Cells[5].Value.ToString();
            cboQuanLi.Text = row.Cells[6].Value.ToString();
            txtLuong.Text = row.Cells[7].Value.ToString();
            cboPhongBan.Text = row.Cells[8].Value.ToString();
        }
    }
}
