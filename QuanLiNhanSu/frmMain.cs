using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class frmMain : Form
    {
        TabPage tab;
        public frmMain()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabForm.TabPages.Count != 0) tabForm.TabPages.Remove(tab);
            frmNhanVien frm = new frmNhanVien();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab = new TabPage("Quản lí nhân viên           ");
            tab.Controls.Add(frm);
            tabForm.TabPages.Add(tab);
            frm.Visible = true;
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabForm.TabPages.Count != 0) tabForm.TabPages.Remove(tab);
            frmPhongBan frm = new frmPhongBan();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab = new TabPage("Quản lí phòng ban          ");
            tab.Controls.Add(frm);
            tabForm.TabPages.Add(tab);
            frm.Visible = true;
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabForm.TabPages.Count != 0) tabForm.TabPages.Remove(tab);
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tab = new TabPage("Quản lí tài khoản          ");
            tab.Controls.Add(frm);
            tabForm.TabPages.Add(tab);
            frm.Visible = true;
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabForm_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("✖", e.Font, Brushes.Red, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabForm.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabForm_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabForm.TabPages.Count; i++)
            {
                Rectangle r = tabForm.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabForm.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void phiênBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string HelpPath;
            HelpPath = Application.StartupPath + @"\Helps\Trợ giúp quản lý nhân viên.docx";
            if (File.Exists(HelpPath))
            {
                System.Diagnostics.ProcessStartInfo proStarInfor = new System.Diagnostics.ProcessStartInfo();
                HelpPath = "\"" + HelpPath + "\"";
                System.Diagnostics.Process.Start("WINWORD.EXE", HelpPath);
            }
            else
                MessageBox.Show("File trợ giúp không tồn tại. " + System.Environment.NewLine +
                    "Kiểm tra lại đường dẫn: " + HelpPath, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
