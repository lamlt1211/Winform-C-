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
    public partial class frmLogin : Form
    {
        public frmMHC frmMHC;
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        public static tbl_nhanvien nhanvien;
        public frmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;

        }
        private bool username()
        {
            if (txtUserName.Text=="")
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool pass()
        {
            if (txtPassWord.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool kiemtra()
        {
            if (username()&&pass())
            {
                return true;
            }
            return false;
        }
        private bool IsValidUser(string username,string password)
        {

            var q = from nv in db.tbl_nhanviens
                    where nv.UserName == txtUserName.Text
                    && nv.PassWord == txtPassWord.Text
                    select nv;
            
            
            
            if (q.Any())
            {
                foreach (var item in q)
                {
                    nhanvien = new tbl_nhanvien();
                    nhanvien.MaNhanVien = item.MaNhanVien;
                    nhanvien.TenNhanVien = item.TenNhanVien;
                    nhanvien.NgaySinh = item.NgaySinh;
                    nhanvien.GioiTinh = item.GioiTinh;
                    nhanvien.SoDienThoai = item.SoDienThoai;
                    nhanvien.DiaChi = item.DiaChi;
                    nhanvien.UserName = item.UserName;
                    nhanvien.PassWord = item.PassWord;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {
                if (IsValidUser(txtUserName.Text, txtPassWord.Text))
                {
                    MessageBox.Show("Đăng nhập thành công","!Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Đăng nhập thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
