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
    public partial class frmPhongBan : Form
    {
        enum LuaChon
        {
            Them,
            Sua,
            Xoa
        }
        LuaChon lc;
        QuanLyNhanSuDataContext db = new QuanLyNhanSuDataContext();
        public frmPhongBan()
        {
            InitializeComponent();
            dgvPhongBan.AutoGenerateColumns = true;
        }

        class ChiTietPhongBan
        {
            int _IDPhong;
            string _TenPhong;
            string _HoTen;
            int? _IDTruongPhong;

            public int IDPhong
            {
                get
                {
                    return _IDPhong;
                }

                set
                {
                    _IDPhong = value;
                }
            }

            public string TenPhong
            {
                get
                {
                    return _TenPhong;
                }

                set
                {
                    _TenPhong = value;
                }
            }

            public string HoTen
            {
                get
                {
                    return _HoTen;
                }

                set
                {
                    _HoTen = value;
                }
            }

            public int? IDTruongPhong
            {
                get
                {
                    return _IDTruongPhong;
                }

                set
                {
                    _IDTruongPhong = value;
                }
            }
        }

        void LoadDataPhongBan()
        {
          List<ChiTietPhongBan> phongbans=  db.ExecuteQuery<ChiTietPhongBan>(@"select PhongBan.IDPhong,TenPhong,IDTruongPhong, HoTen
                          from PhongBan left join NhanVien on PhongBan.IDPhong = NhanVien.IDPhong
                          where IDTruongPhong is null or IDTruongPhong = IDNhanVien").ToList();
            //             var phongbans = from nv in db.NhanViens
            //                             join pb in db.PhongBans
            //                             on nv.IDPhong equals pb.IDPhong
            //                             where pb.IDTruongPhong == nv.IDNhanVien
            //                             select new { pb.IDPhong, pb.TenPhong, pb.IDTruongPhong, nv.HoTen };
           
            dgvPhongBan.DataSource = phongbans;
            dgvPhongBan.Columns["IDPhong"].HeaderText = "Mã Phòng";
            dgvPhongBan.Columns["TenPhong"].HeaderText = "Tên Phòng";
            dgvPhongBan.Columns["IDTruongPhong"].Visible = false;
            dgvPhongBan.Columns["HoTen"].HeaderText = "Trưởng Phòng";
           
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
        private void ChiDoc()
        {
            txtIDPhong.ReadOnly = true;
            txtTenPhong.ReadOnly = true;
        }
        private void ChoViet()
        {
            txtIDPhong.ReadOnly = false;
            txtTenPhong.ReadOnly = false;
        }
        private void dgvPhongBan_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvPhongBan.SelectedRows[0];
            txtIDPhong.Text = row.Cells["IDPhong"].Value.ToString();
            txtTenPhong.Text = row.Cells["TenPhong"].Value.ToString();
            cboTruongPhong.DataSource = db.NhanViens.Where(n => n.IDPhong == int.Parse(txtIDPhong.Text));
            cboTruongPhong.DisplayMember = "HoTen";
            cboTruongPhong.ValueMember = "IDNhanVien";
            if (row.Cells["IDTruongPhong"].Value == null) cboTruongPhong.Text = "";
            else cboTruongPhong.SelectedValue = (int)row.Cells["IDTruongPhong"].Value;
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            LoadDataPhongBan();
            cboTruongPhong.DataSource = db.NhanViens;
            cboTruongPhong.DisplayMember = "HoTen";
            cboTruongPhong.ValueMember = "IDNhanVien";
            HienButton();
            ChiDoc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChoViet();
            lc = LuaChon.Them;
            AnButton();
            txtIDPhong.Text = "Tự động sinh";
            txtIDPhong.ReadOnly = true;
            txtTenPhong.Clear();
            cboTruongPhong.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lc = LuaChon.Sua;
            AnButton();
            ChoViet();
            txtIDPhong.ReadOnly = true;
            cboTruongPhong.DataSource = db.NhanViens.Where(n => n.IDPhong == int.Parse(txtIDPhong.Text));
            cboTruongPhong.DisplayMember = "HoTen";
            cboTruongPhong.ValueMember = "IDNhanVien";
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

        private void ThemPhongBan()
        {
            PhongBan pb = new PhongBan();
            pb.IDPhong = db.PhongBans.Select(n => n.IDPhong).Max() + 1;
            pb.IDTruongPhong = null;
            pb.TenPhong = txtTenPhong.Text;
            db.PhongBans.InsertOnSubmit(pb);
            db.SubmitChanges();
            ChiDoc();
            LoadDataPhongBan();
        }

        private void SuaPhongBan()
        {
            PhongBan pb = db.PhongBans.Where(n => n.IDPhong == int.Parse(txtIDPhong.Text)).First();
            pb.TenPhong = txtTenPhong.Text;
            if (cboTruongPhong.Text == "") pb.IDTruongPhong = null;
            else pb.IDTruongPhong = (int)cboTruongPhong.SelectedValue;
            db.SubmitChanges();
            ChiDoc();
            LoadDataPhongBan();
        }

        private void XoaPhongBan()
        {
            PhongBan pb = db.PhongBans.Where(n => n.IDPhong == int.Parse(txtIDPhong.Text)).First();
            db.PhongBans.DeleteOnSubmit(pb);
            db.SubmitChanges();
            LoadDataPhongBan();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (lc)
            {
                case LuaChon.Them:
                    ThemPhongBan();
                    break;
                case LuaChon.Sua:
                    SuaPhongBan();
                    break;
                case LuaChon.Xoa:
                    XoaPhongBan();
                    break;
            }
            HienButton();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<ChiTietPhongBan> phongbans = db.ExecuteQuery<ChiTietPhongBan>(@"select PhongBan.IDPhong,TenPhong,IDTruongPhong, HoTen
                          from PhongBan left join NhanVien on PhongBan.IDPhong = NhanVien.IDPhong
                          where IDTruongPhong is null or IDTruongPhong = IDNhanVien").Where(n => n.TenPhong.ToUpper().Contains(txtTimKiem.Text.ToUpper())).ToList();
            dgvPhongBan.DataSource = phongbans;
        }
    }
}
