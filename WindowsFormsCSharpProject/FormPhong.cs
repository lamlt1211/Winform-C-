using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCSharpProject
{
    public partial class frmPhong : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        bool edit = false;
        public frmPhong()
        {
            InitializeComponent();

        }
        private bool checkSoNguoi()
        {
            Regex regex = new Regex(@"^[+]?[0-9]*\.?[0-9]+$");
            if (regex.IsMatch(txtSoNguoi.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Số Người phải là số và không được âm", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool checkGia()
        {
            Regex regex = new Regex(@"^[+]?[0-9]*\.?[0-9]+$");
            if (regex.IsMatch(txtGiaPhong.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Giá phòng phải là số và không được âm", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool checkEmptyPhong()
        {

            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Mã phòng không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Tên phòng không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtGiaPhong.Text))
            {
                MessageBox.Show("Giá phòng không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void FormPhong_Load(object sender, EventArgs e)
        {
            Load_LP();
            Load_cboLP();
            rdoTrong.Checked = true;
            Load_Phong();
        }
        private void Load_cboLP()
        {
            db.Refresh(System.Data.Linq.RefreshMode.KeepChanges, db.tbl_loaiphongs);
            cboLoaiPhong.DataSource = db.tbl_loaiphongs.ToList();
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
        }
        private void Detail_LP()
        {
            if (dgvLoaiPhong.CurrentRow != null)
            {
                var r = dgvLoaiPhong.CurrentRow;
                txtMaLP.Text = r.Cells["MaLoaiPhong"].Value.ToString();
                txtTenLoaiPhong.Text = r.Cells["TenLoaiPhong"].Value.ToString();
                txtSoNguoi.Text = r.Cells["SoNguoi"].Value.ToString();
                txtMaLP.ReadOnly = true;
                edit = true;
            }
        }
        private void btnAddLP_Click(object sender, EventArgs e)
        {
            txtMaLP.Text = txtTenLoaiPhong.Text = txtSoNguoi.Text = "";
            edit = false;
            txtMaLP.ReadOnly = false;
        }
        private void Load_LP()
        {
            dgvLoaiPhong.DataSource = from lp in db.tbl_loaiphongs
                                      select new
                                      {
                                          MaLoaiPhong = lp.MaLoaiPhong,
                                          TenLoaiPhong = lp.TenLoaiPhong,
                                          SoNguoi = (int)lp.SoNguoi
                                      };
        }
        private bool checkEmptyLP()
        {
            if (txtMaLP.Text == "")
            {
                MessageBox.Show("Mã loại phòng không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTenLoaiPhong.Text == "")
            {
                MessageBox.Show("Tên loại phòng không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkExistMaLP()
        {
            var ch = from lp in db.tbl_loaiphongs
                     where lp.MaLoaiPhong == txtMaLP.Text
                     select lp;
            if (ch.Any())
            {
                MessageBox.Show("Mã loại phòng đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkExistMaPhong()
        {
            var ch = from p in db.tbl_phongs
                     where p.MaPhong == txtMaPhong.Text
                     select p;
            if (ch.Any())
            {
                MessageBox.Show("Mã phòng đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnSaveLP_Click(object sender, EventArgs e)
        {
            if (checkEmptyLP() && checkExistMaLP() && checkSoNguoi())
            {
                if (edit)
                {
                    var _lp = db.tbl_loaiphongs.SingleOrDefault(x => x.MaLoaiPhong.Equals(txtMaLP.Text));
                    _lp.TenLoaiPhong = txtTenLoaiPhong.Text;
                    _lp.SoNguoi = Convert.ToInt32(txtSoNguoi.Text);
                    db.SubmitChanges();
                    Load_LP();
                }
                else
                {

                    tbl_loaiphong lp = new tbl_loaiphong();
                    lp.MaLoaiPhong = txtMaLP.Text;
                    lp.TenLoaiPhong = txtTenLoaiPhong.Text;
                    lp.SoNguoi = Convert.ToInt32(txtSoNguoi.Text);
                    db.tbl_loaiphongs.InsertOnSubmit(lp);
                    db.SubmitChanges();
                    Load_LP();
                    Load_cboLP();
                }

            }


        }

        private void btnHuyLP_Click(object sender, EventArgs e)
        {
            Detail_LP();
        }

        private void dgvLoaiPhong_SelectionChanged(object sender, EventArgs e)
        {
            Detail_LP();
        }
        private bool checkDELLP()
        {
            var lp = db.CheckDELLP(txtMaLP.Text);
            if (lp.Any())
            {
                MessageBox.Show("Loại phòng đã có trong phòng", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnDelLP_Click(object sender, EventArgs e)
        {
            if (checkDELLP())
            {


                var _lp = db.tbl_loaiphongs.SingleOrDefault(x => x.MaLoaiPhong.Equals(txtMaLP.Text));
                if (MessageBox.Show("Bạn có muốn xóa loại phòng này không", "Hệ Thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.tbl_loaiphongs.DeleteOnSubmit(_lp);
                    db.SubmitChanges();
                }
                Load_LP();
            }
        }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            Detail_Phong();
        }
        private void Load_Phong()
        {
            dgvPhong.DataSource = from p in db.tbl_phongs
                                  join lp in db.tbl_loaiphongs
                                  on p.MaLoaiPhong equals lp.MaLoaiPhong
                                  where p.MaPhong.Contains(txtTimKiem.Text)
                                  select new
                                  {
                                      MaPhong = p.MaPhong,
                                      TenPhong = p.TenPhong,
                                      MaLP = p.MaLoaiPhong,
                                      TenLP = lp.TenLoaiPhong,
                                      TinhTrang = (bool)p.TinhTrang ? "Trống" : "Đang phục vụ",
                                      GiaPhong = (float)(p.GiaPhong),
                                      MieuTa = p.MieuTa
                                  };
        }
        private void Detail_Phong()
        {
            if (dgvPhong.CurrentRow != null)
            {
                var p = dgvPhong.CurrentRow;
                txtMaPhong.Text = p.Cells["MaPhong"].Value.ToString();
                txtTenPhong.Text = p.Cells["TenPhong"].Value.ToString();
                rdoTrong.Checked = true;
                if (p.Cells["TinhTrang"].Value.ToString() == "Đang phục vụ")
                {
                    rdoDangPV.Checked = true;
                }
                cboLoaiPhong.SelectedValue = Convert.ToString(p.Cells["MaLP"].Value);
                txtGiaPhong.Text = p.Cells["GiaPhong"].Value.ToString();
                txtMieuTa.Text = p.Cells["MieuTa"].Value.ToString();
                txtMaPhong.ReadOnly = true;
                edit = true;
            }
        }
        private  bool checkExistPhong()
        {
            var ch = (from p in db.tbl_phongs
                     where p.TenPhong == txtTenPhong.Text
                     select p).ToList();
            if (ch.Count()>0)
            {
                MessageBox.Show("Tên phòng đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnAddPhong_Click(object sender, EventArgs e)
        {
            txtMaPhong.Text = txtTenPhong.Text = txtGiaPhong.Text = txtMieuTa.Text = "";
            edit = false;
            txtMaPhong.ReadOnly = false;
            rdoTrong.Checked = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Detail_Phong();
        }

        private void btnSavePhong_Click(object sender, EventArgs e)
        {
            if (checkEmptyPhong() && checkGia()&&checkExistMaPhong()&&checkExistPhong())
            {
                if (edit)
                {
                    var _p = db.tbl_phongs.SingleOrDefault(x => x.MaPhong.Equals(txtMaPhong.Text));

                    _p.TenPhong = txtTenPhong.Text;
                    _p.TinhTrang = rdoTrong.Checked ? true : false;
                    _p.MaLoaiPhong = (cboLoaiPhong.SelectedItem as tbl_loaiphong).MaLoaiPhong;
                    _p.GiaPhong = float.Parse(txtGiaPhong.Text);
                    _p.MieuTa = txtMieuTa.Text;
                    db.SubmitChanges();
                    Load_Phong();
                }
                else
                {
                    

                    
                    tbl_phong p = new tbl_phong();
                    p.MaPhong = txtMaPhong.Text;
                    p.TenPhong = txtTenPhong.Text;
                    p.TinhTrang = rdoTrong.Checked ? true : false;
                    p.MaLoaiPhong = (cboLoaiPhong.SelectedItem as tbl_loaiphong).MaLoaiPhong;
                    p.GiaPhong = float.Parse(txtGiaPhong.Text);
                    p.MieuTa = txtMieuTa.Text;
                    db.tbl_phongs.InsertOnSubmit(p);
                    db.SubmitChanges();
                    Load_Phong();
                    
                }

            }
        }
        private bool checkDVPhong()
        {
            var dvphong = (from dvp in db.tbl_dichvuphongs
                           join dp in db.tbl_datphongs
                           on dvp.Mapd equals dp.Mapd
                           where dp.TinhTrangHD == true
                           select dvp.MaPhong).ToList();
            if (dvphong.Any())
            {
                MessageBox.Show("Phòng đang có dịch vụ không thể xóa", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkDP()
        {
            var dphong = (from dp in db.tbl_datphongs
                         where dp.TinhTrangHD == true
                         select dp).ToList();
            if (dphong.Any())
            {
                MessageBox.Show("Phòng đang được đặt không thể xóa", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnDelPhong_Click(object sender, EventArgs e)
        {
            var _p = db.tbl_phongs.SingleOrDefault(x => x.MaPhong.Equals(txtMaPhong.Text));
            if (MessageBox.Show("Bạn có muốn phòng này không", "Hệ Thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkDVPhong()&& checkDP())
                {
                    db.tbl_phongs.DeleteOnSubmit(_p);
                    db.SubmitChanges();
                }
                
            }
            Load_Phong();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Load_Phong();
        }
    }
}
