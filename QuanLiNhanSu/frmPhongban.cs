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
        
    }
}
