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

    public partial class frmKh : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        bool edit = false;
        public frmKh()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtTenKH.Text = txtCMND.Text = txtQuocTich.Text = txtSDT.Text = "";
            edit = false;
            txtSDT.ReadOnly = false;
        }
        private void Load_KH()
        {
            dgvKhachHang.DataSource = from kh in db.tbl_khachhangs
                                      where kh.TenKhachHang.Contains(txtTimKiem.Text)
                                      select new
                                      {
                                          SoDienThoai = kh.SoDienThoai,
                                          TenKhachHang = kh.TenKhachHang,
                                          GioiTinh = (bool)kh.GioiTinh ? "Nam" : "Nữ",
                                          NgaySinh = kh.NgaySinh,
                                          QuocTich = kh.QuocTich,
                                          CMND = kh.CMND,
                                      };

        }
        private void Detail_KH()
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                var r = dgvKhachHang.CurrentRow;
                txtTenKH.Text = r.Cells["TenKhachHang"].Value.ToString();
                rdoNam.Checked = true;
                if (r.Cells["GioiTinh"].Value.ToString() == "Nữ")
                {
                    rdoNu.Checked = true;
                }
                txtCMND.Text = r.Cells["CMND"].Value.ToString();
                txtBirthday.Value = Convert.ToDateTime(r.Cells["NgaySinh"].Value.ToString());
                txtQuocTich.Text = r.Cells["QuocTich"].Value.ToString();
                txtSDT.Text = r.Cells["SoDienThoai"].Value.ToString().Trim();
                txtSDT.ReadOnly = true;
                edit = true;
            }
        }
        private bool IsNumber()
        {
            Regex regex = new Regex(@"^[+]?[0-9]*\.?[0-9]+$");
            if (regex.IsMatch(txtCMND.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("CMND sai định dạng", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool checkEmpty()
        {
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Tên Khách Hàng không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCMND.Text))
            {
                MessageBox.Show("CMND không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtQuocTich.Text))
            {
                MessageBox.Show("Quốc tịch không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void frmKh_Load(object sender, EventArgs e)
        {
            Load_KH();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Detail_KH();
        }

        private void btnDelKH_Click(object sender, EventArgs e)
        {
            var _khachhang = db.tbl_khachhangs.SingleOrDefault(x => x.SoDienThoai.Equals(txtSDT.Text));
            if (MessageBox.Show("Bạn có muốn xóa khách hàng này không", "Hệ Thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkHD())
                {
                    db.tbl_khachhangs.DeleteOnSubmit(_khachhang);
                    db.SubmitChanges();
                }

            }
            Load_KH();
        }


        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            Detail_KH();

        }
        private bool checkPhoneNumber()
        {
            Regex r = new Regex("^[0]{1}\\d{9}$");
            if (r.IsMatch(txtSDT.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Số điện thoại sai định dạng", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private bool checkExistPhone()
        {
            var ph = from kh in db.tbl_khachhangs
                     where kh.SoDienThoai == txtSDT.Text
                     select kh;
            if (ph.Any())
            {
                MessageBox.Show("Số điện thoại đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkHD()
        {
            var dt = db.CheckHD(txtSDT.Text);
            if (dt.Any())
            {
                MessageBox.Show("Khách hàng đang có đơn hàng", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkAge()
        {
            DateTime BirthDate = txtBirthday.Value;
            DateTime CurrentDate = DateTime.Now;
            int Age = CurrentDate.Year - BirthDate.Year;
            if (Age < 18)
            {
                MessageBox.Show("Khách hàng phải trên 18 tuổi", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool checkNgay()
        {
            DateTime ns = txtBirthday.Value;

            if (ns > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không vượt quá ngày hiện tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (checkEmpty() &&   IsNumber() && checkNgay() && checkAge() && checkPhoneNumber())
            {
                if (edit)
                {
                    var _khachhang = db.tbl_khachhangs.SingleOrDefault(x => x.SoDienThoai.Equals(txtSDT.Text));
                    _khachhang.TenKhachHang = txtTenKH.Text;
                    _khachhang.GioiTinh = rdoNam.Checked ? true : false;
                    _khachhang.NgaySinh = txtBirthday.Value;
                    _khachhang.CMND = txtCMND.Text;
                    _khachhang.QuocTich = txtQuocTich.Text;
                    
                    db.SubmitChanges();
                    Load_KH();

                }
                else
                {

                    if (checkExistPhone())
                    {

                  
                    
                        tbl_khachhang kh = new tbl_khachhang();
                        kh.TenKhachHang = txtTenKH.Text;
                        kh.GioiTinh = rdoNam.Checked ? true : false;
                        kh.NgaySinh = txtBirthday.Value;
                        kh.CMND = txtCMND.Text;
                        kh.QuocTich = txtQuocTich.Text;
                        kh.SoDienThoai = txtSDT.Text;
                        db.tbl_khachhangs.InsertOnSubmit(kh);
                        db.SubmitChanges();
                        Load_KH();
                    }
                }



            }

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Load_KH();
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
