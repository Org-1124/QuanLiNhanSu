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
        int ktluu = 0;
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
            if (dr.Cells["GioiTinh"].Value.ToString().ToUpper() == "NAM")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
        }
        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmThemTaiKhoan frm = new FrmThemTaiKhoan();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dgvNhanVien.DataSource = NhanVienDAO.SearchNV(txtTimKiem.Text);
                ReadOnly1();
            }
            catch
            {
                MessageBox.Show("Không tìm thấy !");
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvNhanVien.DataSource = NhanVienDAO.SearchNV(txtTimKiem.Text);
                    ReadOnly1();
                }
            }
           catch
            {
                MessageBox.Show("Không tìm thấy !");
            }
        }

        public void ReadOnly1()
        {
            txtChucVu.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtIDNhanVien.ReadOnly = true;
            txtLuong.ReadOnly = true;
            txtQueQuan.ReadOnly = true;
            cboPhongBan.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cboQuanLi.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtIDNhanVien.Text == "")
                MessageBox.Show("Bạn chưa chọn dữ liệu");
            else
            {
                btnLuu.Visible = true;
                txtChucVu.ReadOnly = false;
                txtHoTen.ReadOnly = false;
                txtHoTen.Focus();
                txtIDNhanVien.ReadOnly = true;
                txtLuong.ReadOnly = false;
                txtQueQuan.ReadOnly = false;
                cboPhongBan.Enabled = true;
                cboQuanLi.Enabled = true;
                rdbNam.Enabled = true;
                rdbNu.Enabled = true;
                ktluu=1;
            }    
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.ChucVu = txtChucVu.Text.ToString();
            nv.HoTen = txtHoTen.Text.ToString();
            if (rdbNam.Checked == true)
                nv.GioiTinh = "Nam";
            else
                nv.GioiTinh = "Nữ";
            //int idnv = 0;
           // int.TryParse(txtIDNhanVien.ToString(), out idnv);
           // nv.IDNhanVien = idnv;
            nv.IDNhanVien = int.Parse(txtIDNhanVien.Text);
            int luong=0;
            int.TryParse(txtLuong.Text.ToString(), out luong);
            nv.Luong = luong;
            nv.IdPhong = (int)cboPhongBan.SelectedValue;
            nv.IDQuanLi = (int)cboQuanLi.SelectedValue;
            nv.NgaySinh = dtpNgaySinh.Value;
            nv.QueQuan = txtQueQuan.Text.ToString();
            if(ktluu==1)
            {
                try
                {
                    NhanVienDAO.SuaNV(nv);
                    dgvNhanVien.DataSource = NhanVienDAO.LoadDataNV();
                    MessageBox.Show("Bạn đã sửa thành công");
                    ReadOnly1();
                }
                catch
                {
                    MessageBox.Show("Lỗi chưa sửa được");
                }
            }
            if (ktluu == 2)
            {
                try
                {
                    NhanVienDAO.ThemNV(nv);
                    dgvNhanVien.DataSource = NhanVienDAO.LoadDataNV();
                    ReadOnly1();
                }
                catch
                {
                    MessageBox.Show("Bạn chưa thêm được");
                }
            }
            btnLuu.Visible = false;
            ktluu = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            DataTable maxid = new DataTable();
            maxid = NhanVienDAO.ID_NVMax();
            int idnv = (int)maxid.Rows[0][0];
            idnv++;
            txtIDNhanVien.Text = idnv.ToString();
            txtChucVu.ReadOnly = false;
            txtHoTen.ReadOnly = false;
            txtHoTen.Focus();
            txtIDNhanVien.ReadOnly = true;
            txtLuong.ReadOnly = false;
            txtQueQuan.ReadOnly = false;
            cboPhongBan.Enabled = true;
            dtpNgaySinh.Enabled = true;
            cboQuanLi.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            ktluu = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtIDNhanVien.Text == "")
                MessageBox.Show("Bạn chưa chọn nhân viên");
            else
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.IDNhanVien = int.Parse(txtIDNhanVien.Text.ToString());
                NhanVienDAO.XoaNV(nv);
                ReadOnly1();
                MessageBox.Show("Bạn đã xóa nhân viên thành công");
                dgvNhanVien.DataSource = NhanVienDAO.LoadDataNV();
            }
        }
    }
}
