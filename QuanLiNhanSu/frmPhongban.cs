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
                cboTentruongphong.SelectedValue = (int?)dr.Cells["IDTruongPhong"].Value;
            }
            catch
            { 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            txtIDPhong.ReadOnly = false;
            txtTenPhong.ReadOnly = false;
            cboTentruongphong.Enabled = true;
            dtpNgayNhanChuc.Enabled = true;
            DataTable maxid = new DataTable();
            maxid = PhongBanDAO.ID_PBMax();
            int idpb = (int)maxid.Rows[0][0];
            idpb++;
            txtIDPhong.Text = idpb.ToString();
            txtTenPhong.Focus();
            luu = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            txtIDPhong.ReadOnly = true;
            txtTenPhong.ReadOnly = true;
            cboTentruongphong.Enabled = false;
            dtpNgayNhanChuc.Enabled = false;
            PhongBanDTO pb = new PhongBanDTO();
            pb.IdPhong =int.Parse(txtIDPhong.Text);   
            pb.TenPhong = txtTenPhong.Text;
           /*
            if (ktluu == 1)
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
            luu = 0;*/
        }
        
    }
}
