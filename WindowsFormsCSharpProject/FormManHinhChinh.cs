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
    public partial class frmMHC : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        public int sophongtrong { get; set; }
        public int sophongDPV { get; set; }
        public frmMHC()
        {
            
            InitializeComponent();
            

        }
       
        private void frmMHC_Load(object sender, EventArgs e)
        {
            lblUserName.Text = frmLogin.nhanvien.TenNhanVien;
            Load_Phong();
            frmDatPhong frm = new frmDatPhong();
            sophongtrong = (from p in db.tbl_phongs where p.TinhTrang == true select p).Count();
            txtSPT.Text = sophongtrong.ToString();
            sophongDPV = (from p in db.tbl_phongs where p.TinhTrang == false select p).Count();
            txtPDPV.Text = sophongDPV.ToString();
            txtSPT.ReadOnly = true;
            txtPDPV.ReadOnly = true;


        }
        
        public void Load_Phong()
        {
            var _lstP = db.tbl_phongs.ToList();

                        
            int x = 16, y = 13;
            int count = 1;
            pnlQLP.Controls.Clear();
            foreach (var item in _lstP)
            {
                // button1
                // 
                Button btn = new Button();
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                if (item.TinhTrang == true)
                {
                    btn.ForeColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    btn.ForeColor = System.Drawing.Color.Red;
                }
                btn.Location = new System.Drawing.Point(x,y);
                btn.Name = "tbl_phong"+item.MaPhong;
                btn.Size = new System.Drawing.Size(75, 75);
                btn.Tag = item.MaLoaiPhong;
                btn.Text = item.TenPhong;
                btn.UseVisualStyleBackColor = true;
                pnlQLP.Controls.Add(btn);
                if (count > 7)
                {
                    y += 88;
                    x = 16;
                    count = 1;
                }
                else
                {
                    x += 91;
                }
                count++;
            }
        }
        private bool checkP()
        {
            var dt = (from p in db.tbl_phongs
                      where p.TinhTrang == false
                      select p).ToList();
            if (dt.Count() == 0)
            {
                return false;
            }
            return true;
        }
        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkP())
            {
                MessageBox.Show("Không có phòng nào đang phục vụ", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmDVP frm = new frmDVP();
                frm.ShowDialog();
            }
            
        }
    }
}
