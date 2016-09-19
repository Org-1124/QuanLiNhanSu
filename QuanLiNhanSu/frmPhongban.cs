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
    public partial class frmPhongban : Form
    {
        int luu = 0;
        public frmPhongban()
        {
            InitializeComponent();
        }

        private void frmPhongban_Load(object sender, EventArgs e)
        {
            dgvPhongban.DataSource = PhongBanDAO.LoadDataPB();
            SetHeaderColumn();
           // LoadComboBox();
        }
        public void SetHeaderColumn()
        {
            dgvPhongban.Columns["IDPhong"].HeaderText = "Mã Phòng";
            dgvPhongban.Columns["IDPhong"].Width = 100;
            dgvPhongban.Columns["TenPhong"].HeaderText = "Tên Phòng";
            dgvPhongban.Columns["IDTruongPhong"].HeaderText = "Mã Trưởng Phòng";
            dgvPhongban.Columns["NgayNhanChuc"].HeaderText = "Ngày nhận chức";    
        }
        /*
        public void LoadComboBox()
        {
            cboTentruongphong.DataSource = NhanVienDAO.LoadDataNVTruongPhong();
            cboTentruongphong.ValueMember = "IDPhong";
            cboTentruongphong.DisplayMember = "HoTen";

        }
        */
        private void dgvPhongban_Click(object sender, EventArgs e)
        {
            luu = 0;
            button5.Visible = false;
            txtTenPhong.ReadOnly = true;
            cboTentruongphong.Enabled = false;
            dtpNgayNhanChuc.Enabled = false;
            DataGridViewRow dr = dgvPhongban.SelectedRows[0];
            txtIDPhong.Text = dr.Cells["IDPhong"].Value.ToString();
            txtTenPhong.Text = dr.Cells["TenPhong"].Value.ToString();
            DateTime dt;
            DateTime.TryParse(dr.Cells["NgayNhanChuc"].Value.ToString(), out dt);
            if (dt.Year < 1995)
            {
                dtpNgayNhanChuc.Value = DateTimePicker.MinimumDateTime;
            }
            else
            {
                dtpNgayNhanChuc.Value = dt;

            }
            try
            {
                cboTentruongphong.DataSource = NhanVienDAO.LayThongTinNhanVien_1((int)dr.Cells["IDPhong"].Value);
                cboTentruongphong.ValueMember = "IDNhanVien";
                cboTentruongphong.DisplayMember = "HoTen";
                cboTentruongphong.SelectedValue = (int)dr.Cells["IDTruongPhong"].Value;
            }
            catch
            { 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            txtTenPhong.ReadOnly = false;
            cboTentruongphong.Enabled = true;
            dtpNgayNhanChuc.Enabled = true;
            DataTable maxid = new DataTable();
            maxid = PhongBanDAO.ID_PBMax();
            int idpb = (int)maxid.Rows[0][0];
            idpb++;
            txtIDPhong.Text = idpb.ToString();
            txtTenPhong.Focus();
            cboTentruongphong.DataSource = NhanVienDAO.LoadDataNV();
            cboTentruongphong.ValueMember = "IDNhanVien";
            cboTentruongphong.DisplayMember = "HoTen";
            luu = 2;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtIDPhong.Text == "")
                MessageBox.Show("Bạn chưa chọn dữ liệu");
            else
            {
                button5.Visible = true;
                txtTenPhong.ReadOnly = false;
                txtTenPhong.Focus();
                cboTentruongphong.Enabled = true;
                dtpNgayNhanChuc.Enabled = true;
                cboTentruongphong.DataSource = NhanVienDAO.LoadDataNV();
                cboTentruongphong.ValueMember = "IDNhanVien";
                cboTentruongphong.DisplayMember = "HoTen";
                luu = 1;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            txtTenPhong.ReadOnly = true;
            cboTentruongphong.Enabled = false;
            dtpNgayNhanChuc.Enabled = false;
            PhongBanDTO pb = new PhongBanDTO();
            pb.IdPhong =int.Parse(txtIDPhong.Text);   
            pb.TenPhong = txtTenPhong.Text;
            pb.IdTruongPhong = (int)cboTentruongphong.SelectedValue;
            pb.NgayNhanChuc = dtpNgayNhanChuc.Value;
            if (luu == 1)
            {
                try
                {
                    PhongBanDAO.SuaPB(pb);
                    dgvPhongban.DataSource = PhongBanDAO.LoadDataPB();
                    MessageBox.Show("Bạn đã sửa thành công");
                }
                catch
                {
                    MessageBox.Show("Lỗi chưa sửa được");
                }
            }
            if (luu == 2)
            {
                try
                {
                    PhongBanDAO.ThemPB(pb);
                    dgvPhongban.DataSource = PhongBanDAO.LoadDataPB();
                    MessageBox.Show("Bạn đã lưu thành công");
                }
                catch
                {
                    MessageBox.Show("Bạn chưa thêm được");
                }
            }
            luu = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtIDPhong.Text == "")
                MessageBox.Show("Bạn chưa chọn phòng ban");
            else
            {
                PhongBanDTO pb = new PhongBanDTO();
                pb.IdPhong = int.Parse(txtIDPhong.Text);
                PhongBanDAO.XoaPB(pb);
                MessageBox.Show("Bạn đã xóa phòng ban thành công");
                dgvPhongban.DataSource = PhongBanDAO.LoadDataPB();
            }
        }

       
        
    }
}
