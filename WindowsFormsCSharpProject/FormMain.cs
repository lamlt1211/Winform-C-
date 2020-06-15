using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCSharpProject
{
    public partial class frmMain : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhong frm = new frmPhong();
            Load_Frm_MdiChild(frm);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmMHC frm = new frmMHC();
           
            Load_Frm_MdiChild(frm);
            

        }
        private void Load_Frm_MdiChild(Form frm)
        {
            // Chọn form Mdi cha để hiện thị vào bên trong form đó
            frm.MdiParent = this;
            // Set một số tùy chỉnh cho form
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.StartPosition = FormStartPosition.Manual;


            if (this.ActiveMdiChild != null) // có form đang mở
            {
                Form frmCurrent = this.ActiveMdiChild;
                if (frmCurrent.Name != frm.Name) // Không trùng
                {
                    // Hiển thị form sắp mở
                    frm.Show();
                    //Đóng form đang mở
                    frmCurrent.Close();
                }
            }
            else // ko có form nào
            {
                // Hiển thị form
                frm.Show();
            }
            //frm.ShowDialog();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMHC frm = new frmMHC();
            Load_Frm_MdiChild(frm);

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichVu frm = new frmDichVu();
            Load_Frm_MdiChild(frm);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void kháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKh frm = new frmKh();
            Load_Frm_MdiChild(frm);
        }

        private void đặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatPhong frm = new frmDatPhong();
            Load_Frm_MdiChild(frm);
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            Load_Frm_MdiChild(frm);
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTiet frm = new frmChiTiet();
            Load_Frm_MdiChild(frm);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
          
        }
    }
}
        

