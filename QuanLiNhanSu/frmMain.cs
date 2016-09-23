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
    public partial class frmMain : Form
    {
        TabPage tabpage;
        public frmMain()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabpage!=null)
            {
                tabControl1.TabPages.Remove(tabpage);
            }
            frmNhanVien f = new frmNhanVien();
            tabpage = new TabPage();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabpage.Controls.Add(f);
            tabpage.Text = "Quản lí nhân viên                ";
            f.Visible = true;
            tabControl1.TabPages.Add(tabpage);
        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabpage!=null)
            {
                tabControl1.TabPages.Remove(tabpage);
            }
            FrmThemTaiKhoan f = new FrmThemTaiKhoan();
            tabpage = new TabPage();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabpage.Controls.Add(f);
            tabpage.Text = "Thêm tài khoản            ";
            f.Visible = true;
            tabControl1.TabPages.Add(tabpage);
        }

        private void xóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabpage != null)
            {
                tabControl1.TabPages.Remove(tabpage);
            }
            frmXoaTaiKhoan f = new frmXoaTaiKhoan();
            tabpage = new TabPage();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabpage.Controls.Add(f);
            tabpage.Text = "Xóa tài khoản              ";
            f.Visible = true;
            tabControl1.TabPages.Add(tabpage);
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabpage != null)
            {
                tabControl1.TabPages.Remove(tabpage);
            }
            frmDoiMatKhaucs f = new frmDoiMatKhaucs("");
            tabpage = new TabPage();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            tabpage.Controls.Add(f);
            tabpage.Text = "Đổi mật khẩu           ";
            f.Visible = true;
            tabControl1.TabPages.Add(tabpage);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
