using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLiNhanSu
{
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {
            //txtUser.Focus();
           // txtPassword.Focus();
            this.ActiveControl = txtUser;
        }
        string strConnection = @"Data Source=.;Initial Catalog=QuanLiNhanSu;Integrated Security=True";
        SqlConnection conn = null;
        public string GetValue(string strsql)
        {
            string temp = null;
            conn = new SqlConnection(strConnection);
            conn.Open();
            SqlCommand sqlcmd = new SqlCommand(strsql, conn);
            SqlDataReader sqldr = sqlcmd.ExecuteReader();
            while (sqldr.Read())
            {
                temp = sqldr[0].ToString();
            }
            conn.Close();
            return temp;
        }
        public bool DangNhapKVC(string Username, string Pass)
        {
            string sql = "SELECT * FROM tblTaiKhoan WHERE TenDangNhap = '" + Username + "'AND MatKhau = '" + Pass + "'";
            SqlConnection con = new SqlConnection(strConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
           if (DangNhapKVC(txtUser.Text, txtPassword.Text) == true)
            {
                MessageBox.Show("Đăng nhập thành công !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPhongban frm = new frmPhongban();
                frm.ShowDialog();
              //if(DialogResult.OK==MessageBox.Show())
                //this.MdiParent = this;
              //  this.DialogResult = DialogResult.OK;
                //this.Close();
                this.Close();
            }
            else
                MessageBox.Show("Đăng nhập thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
