using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace QuanLiNhanSu
{
    public partial class frmNhanVien : Form
    {
        enum LuaChon
        {
            Them,
            Sua,
            Xoa
        }
        LuaChon lc;
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        void LoadDataNhanVien()
        {
            var s = from nv in db.NhanViens
                    select new { nv.IDNhanVien, nv.HoTen, nv.GioiTinh, nv.NgaySinh, nv.QueQuan,nv.ChucVu,nv.Luong,nv.PhongBan.IDPhong,nv.PhongBan.TenPhong};
            dgvNhanVien.DataSource = s;
            SuaTenCot();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataNhanVien();
            cboPhong.DataSource = db.PhongBans.Select(n => n);
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "IDPhong";
            
            ChiDoc();
            HienButton();
        }
        
        private void SuaTenCot()
        {
            dgvNhanVien.Columns["IDNhanVien"].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns["HoTen"].HeaderText = "Họ tên";
            dgvNhanVien.Columns["QueQuan"].HeaderText = "Quê quán";
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns["IDPhong"].Visible = false;
            dgvNhanVien.Columns["TenPhong"].HeaderText = "Tên phòng";
            dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức vụ";
            dgvNhanVien.Columns["Luong"].HeaderText = "Lương";
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvNhanVien.SelectedRows[0];
            txtIDNhanVien.Text = row.Cells["IDNhanVien"].Value.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            txtLuong.Text = row.Cells["Luong"].Value?.ToString();
            txtQueQuan.Text = row.Cells["QueQuan"].Value?.ToString();
            txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString();
            dtpNgaySinh.Value = row.Cells["NgaySinh"].Value== null ? dtpNgaySinh.MinDate : (DateTime)row.Cells["NgaySinh"].Value;
            cboPhong.SelectedValue = (int)row.Cells["IDPhong"].Value;
            rdbNam.Checked = row.Cells["GioiTinh"].Value.ToString() == "Nam" ? true : false;
            rdbNu.Checked = row.Cells["GioiTinh"].Value.ToString() == "Nam" ? false : true;
        }

        private void ChiDoc()
        {
            txtChucVu.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtIDNhanVien.ReadOnly = true;
            txtLuong.ReadOnly = true;
            txtQueQuan.ReadOnly = true;
        }

        private void ChoViet()
        {
            txtChucVu.ReadOnly = false;
            txtHoTen.ReadOnly = false;
            txtIDNhanVien.ReadOnly = false;
            txtLuong.ReadOnly = false;
            txtQueQuan.ReadOnly = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtChucVu.Clear();
            txtHoTen.Clear();
            txtIDNhanVien.Text = "Tự động sinh";
            txtIDNhanVien.ReadOnly = true;
            txtLuong.Clear();
            txtQueQuan.Clear();
            AnButton();
            ChoViet();
            lc = LuaChon.Them;
        }
        private void AnButton()
        {
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnThem.Visible = false;
        }
        private void HienButton()
        {
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnThem.Visible = true;
        }

        void ThemNhanVien()
        {
            NhanVien nv = new NhanVien();
            nv.HoTen = txtHoTen.Text;
            nv.NgaySinh = dtpNgaySinh.Value;
            if (txtLuong.Text == null || txtLuong.Text == "") nv.Luong = null;
            else nv.Luong = long.Parse(txtLuong.Text);
            nv.IDNhanVien = db.NhanViens.Select(n => n.IDNhanVien).Max()+1;
            nv.IDPhong = (int?)cboPhong.SelectedValue;
            nv.QueQuan = txtQueQuan.Text;
            nv.GioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
            nv.ChucVu = txtChucVu.Text;
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            ChiDoc();
            HienButton();
            LoadDataNhanVien();
        }
        void XoaNhanVien()
        {
            NhanVien nv = db.NhanViens.Where(n => n.IDNhanVien == int.Parse(txtIDNhanVien.Text)).First();
            db.NhanViens.DeleteOnSubmit(nv);
            db.SubmitChanges();
            LoadDataNhanVien();
            HienButton();
        }
        void SuaNhanVien()
        {
            NhanVien nv = db.NhanViens.Where(n => n.IDNhanVien == int.Parse(txtIDNhanVien.Text)).First();
            nv.HoTen = txtHoTen.Text;
            nv.NgaySinh = dtpNgaySinh.Value;
            if (txtLuong.Text == null || txtLuong.Text == "") nv.Luong = null;
            else nv.Luong = long.Parse(txtLuong.Text);
            nv.IDPhong = (int?)cboPhong.SelectedValue;
            nv.QueQuan = txtQueQuan.Text;
            nv.GioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
            nv.ChucVu = txtChucVu.Text;
            db.SubmitChanges();
            HienButton();
            ChiDoc();
            LoadDataNhanVien();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch(lc)
            {
                case LuaChon.Xoa:
                    XoaNhanVien();
                    break;
                case LuaChon.Them:
                    ThemNhanVien();
                    break;
                case LuaChon.Sua:
                    SuaNhanVien();
                    break;
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            AnButton();
            lc = LuaChon.Xoa;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HienButton();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ChoViet();
            AnButton();
            lc = LuaChon.Sua;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = db.NhanViens.Where(n => n.HoTen.Contains(txtTimKiem.Text)).Select(nv => new { nv.IDNhanVien, nv.HoTen, nv.GioiTinh, nv.NgaySinh, nv.QueQuan, nv.ChucVu, nv.Luong, nv.PhongBan.IDPhong, nv.PhongBan.TenPhong });
        }
    }
}
