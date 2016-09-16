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
            LoadComboBox();
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
            dgvNhanVien.Columns["IDQuanLi"].Visible = false;
            dgvNhanVien.Columns["IDPhong"].Visible = false;
        }
        public void LoadComboBox()
        {
            cboPhongBan.DataSource = PhongBanDAO.LoadDataPB();
            cboPhongBan.ValueMember = "IDPhong";
            cboPhongBan.DisplayMember = "TenPhong";
            cboQuanLi.DataSource = NhanVienDAO.LoadDataNV();
            cboQuanLi.ValueMember = "IDNhanVien";
            cboQuanLi.DisplayMember = "HoTen";
        }
        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvNhanVien.SelectedRows[0];
            txtIDNhanVien.Text = dr.Cells["IDNhanVien"].Value.ToString();
            txtHoTen.Text = dr.Cells["HoTen"].Value.ToString();
            txtLuong.Text = dr.Cells["Luong"].Value.ToString();
            txtQueQuan.Text = dr.Cells["QueQuan"].Value.ToString();
            txtChucVu.Text = dr.Cells["ChucVu"].Value.ToString();
            DateTime dt;
            DateTime.TryParse(dr.Cells["NgaySinh"].Value.ToString(), out dt);
            if (dt.Year < 1995)
            {
                dtpNgaySinh.Value = DateTimePicker.MinimumDateTime;
            }
            else
            {
                dtpNgaySinh.Value = dt;

            }

            cboPhongBan.SelectedValue = dr.Cells["IDPhong"].Value;
            cboQuanLi.SelectedValue = dr.Cells["IDQuanLi"].Value;
            if(dr.Cells["GioiTinh"].Value.ToString().ToUpper()=="NAM")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQueQuan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {

        }


        private void dgvNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmThemTaiKhoan frm = new FrmThemTaiKhoan();
            frm.ShowDialog();
        }
    }
}
