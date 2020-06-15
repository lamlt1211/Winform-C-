using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCSharpProject
{
    public partial class frmNhanVien : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        bool edit = false;
        public frmNhanVien()
        {
            InitializeComponent();
            dgvNhanVien.AutoGenerateColumns = false;
        }


        private void btnAddNV_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = txtTenNV.Text = txtUserName.Text = txtPassword.Text = txtPhone.Text = txtDiaChi.Text = "";
            edit = false;
            txtMaNV.ReadOnly = false;
        }
        private void Load_NhanVien()
        {
            dgvNhanVien.DataSource = from nv in db.tbl_nhanviens
                                     where nv.TenNhanVien.Contains(txtTimKiem.Text)
                                     select new
                                     {
                                         MaNV = nv.MaNhanVien,
                                         TenNhanVien = nv.TenNhanVien,
                                         UserName = nv.UserName,
                                         Password = nv.PassWord,
                                         GioiTinh = (bool)nv.GioiTinh ? "Nam" : "Nữ",
                                         NgaySinh = nv.NgaySinh,
                                         SoDienThoai = nv.SoDienThoai,
                                         DiaChi = nv.DiaChi,
                                     };
        }
        private void Detail_NV()
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                var r = dgvNhanVien.CurrentRow;
                txtMaNV.Text = r.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = r.Cells["TenNhanVien"].Value.ToString();
                txtUserName.Text = r.Cells["UserName"].Value.ToString();
                txtPassword.Text = r.Cells["Password"].Value.ToString();
                rdoNam.Checked = true;
                if (r.Cells["GioiTinh"].Value.ToString() == "Nữ")
                {
                    rdoNu.Checked = true;
                }
                txtPhone.Text = r.Cells["SoDienThoai"].Value.ToString().Trim();
                txtNgaySinh.Value = Convert.ToDateTime(r.Cells["NgaySinh"].Value.ToString());
                txtMaNV.ReadOnly = true;
                edit = true;
                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
            }
        }

        private bool checkEmpty()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Username không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Password không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkPhoneNumber()
        {
            Regex r = new Regex("^[0]{1}\\d{9}$");
            if (r.IsMatch(txtPhone.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Số điện thoại sai định dạng", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private bool checkAge()
        {
            DateTime BirthDate = DateTime.Parse(txtNgaySinh.Text);
            DateTime CurrentDate = DateTime.Today;
            int Age = CurrentDate.Year - BirthDate.Year;
            if (Age < 18)
            {
                MessageBox.Show("Nhân viên phải trên 18 tuổi", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            Detail_NV();
        }

        private void btnDelNV_Click(object sender, EventArgs e)
        {
            var _nhanvien = db.tbl_nhanviens.SingleOrDefault(x => x.SoDienThoai.Equals(txtPhone.Text));
            if (MessageBox.Show("Bạn có muốn xóa nhân viên này không", "Hệ Thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.tbl_nhanviens.DeleteOnSubmit(_nhanvien);
                db.SubmitChanges();
            }
            Load_NhanVien();
        }

        private void btnSaveNV_Click(object sender, EventArgs e)
        {
            if (checkEmpty()&&checkPhoneNumber()&&checkAge() )
            {
                if (edit)
                {
                    var _nhanvien = db.tbl_nhanviens.SingleOrDefault(x => x.MaNhanVien.Equals(txtMaNV.Text));
                    _nhanvien.TenNhanVien = txtTenNV.Text;
                    _nhanvien.UserName = txtUserName.Text;
                    _nhanvien.PassWord = txtPassword.Text;
                    _nhanvien.GioiTinh = rdoNam.Checked ? true : false;
                    _nhanvien.NgaySinh = txtNgaySinh.Value;
                    _nhanvien.SoDienThoai = txtPhone.Text;
                    _nhanvien.DiaChi = txtDiaChi.Text;
                    db.SubmitChanges();
                    Load_NhanVien();


                }
                else
                {
                    if (checkExistMaNV() && checkExistUser() && checkExistPhone())
                    {

                   
                        tbl_nhanvien nv = new tbl_nhanvien();
                        nv.MaNhanVien = txtMaNV.Text;
                        nv.TenNhanVien = txtTenNV.Text;
                        nv.UserName = txtUserName.Text;
                        nv.PassWord = txtPassword.Text;
                        nv.GioiTinh = rdoNam.Checked ? true : false;
                        nv.NgaySinh = txtNgaySinh.Value;
                        nv.SoDienThoai = txtPhone.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        db.tbl_nhanviens.InsertOnSubmit(nv);
                        db.SubmitChanges();
                        Load_NhanVien();

                    }

                }
               

            }
        }
        private bool checkExistPhone()
        {
            var ph = from nv in db.tbl_nhanviens
                     where nv.SoDienThoai == txtPhone.Text
                     select nv;
            if (ph.Any())
            {
                MessageBox.Show("Số điện thoại đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkExistUser()
        {
            var dt = from nv in db.tbl_nhanviens
                     where nv.UserName == txtUserName.Text
                     select nv;
            if (dt.Any())
            {
                MessageBox.Show("UserName đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            Load_NhanVien();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            Detail_NV();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Load_NhanVien();
        }
        private bool checkExistMaNV()
        {
            var ch = from lp in db.tbl_nhanviens
                     where lp.MaNhanVien == txtMaNV.Text
                     select lp;
            if (ch.Any())
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
