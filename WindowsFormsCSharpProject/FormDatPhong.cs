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
using static System.Windows.Forms.DataFormats;

namespace WindowsFormsCSharpProject
{
    public partial class frmDatPhong : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        public string maphong { get; set; }
        public static string sdt { get; set; }
        public static string mapd { get; set; }
        public static int songay { get; set; }
        public frmDatPhong()
        {
            InitializeComponent();
           
        }

        private void FormDatPhong_Load(object sender, EventArgs e)
        {
            Load_cboKH();
            Load_KH();
            ChonPhong();
            Load_PhongTrong();
            Load_DSDat();

        }
        private void Load_cboKH()
        {
            cboKh.DataSource = db.tbl_khachhangs.ToList();
            cboKh.DisplayMember = "TenKhachHang";
            cboKh.ValueMember = "SoDienThoai";
            
        }
        private void Load_KH()
        {
            sdt = (cboKh.SelectedItem as tbl_khachhang).SoDienThoai;
           
            var r = (from kh in db.tbl_khachhangs
                    where kh.SoDienThoai == sdt
                    select kh).ToList();
            foreach (var item in r)
            {
                lsvChiTiet.Items[0].SubItems[1].Text = item.SoDienThoai;
                lsvChiTiet.Items[1].SubItems[1].Text = item.TenKhachHang;
                lsvChiTiet.Items[2].SubItems[1].Text =(bool)item.GioiTinh?"Nam":"Nữ";
                lsvChiTiet.Items[3].SubItems[1].Text =  item.NgaySinh.Value.ToShortDateString();
                lsvChiTiet.Items[4].SubItems[1].Text = item.CMND.ToString();
                lsvChiTiet.Items[5].SubItems[1].Text = item.QuocTich.ToString();

            }


        }
        private void Load_DSDat()
        {
            dgvDatPhong.DataSource = from dp in db.tbl_datphongs
                                     join kh in db.tbl_khachhangs
                                     on dp.SoDienThoai equals kh.SoDienThoai
                                     
                                     select new
                                     {
                                         MP = dp.MaPhong,
                                         MaPhieu = dp.Mapd,
                                         SoDienThoai = kh.SoDienThoai,
                                         HoTen = kh.TenKhachHang,
                                         NgayDen = dp.NgayDen,
                                         NgayDi = dp.NgayDi,
                                         SoTienDat = dp.SoTienDat,
                                         TinhTrang = (bool)dp.TinhTrang ?"Ok":"Chờ",
                                         TinhTrangHD =(bool)dp.TinhTrangHD?"Chưa Thanh Toán":"Đã Thanh Toán"

                                     };
        }
        
        private bool checkNgayDen()
        {
            DateTime nd = txtNgayDen.Value;
            if (nd>DateTime.Now)
            {
                MessageBox.Show("Ngày đến không lớn hơn ngày hiện tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkDate()
        {
            DateTime nd = txtNgayDen.Value;
            DateTime ndi = txtNgayDi.Value;
            if (nd>=ndi)
            {
                MessageBox.Show("Ngày đến không được lớn hơn hoặc bằng ngày đi", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void Load_PhongTrong()
        {
            

                dgvPhongTrong.DataSource = from p in db.tbl_phongs
                                           join lp in db.tbl_loaiphongs
                                           on p.MaLoaiPhong equals lp.MaLoaiPhong
                                           where p.TinhTrang == true
                                           select new
                                           {
                                               MaPhong = p.MaPhong,
                                               Phong = p.TenPhong,
                                               Loai = lp.TenLoaiPhong,
                                               SoNguoi = lp.SoNguoi,
                                               Gia = (float)p.GiaPhong

                                           };
            
            
        }
        private void ChonPhong()
        {
            lvdp.Items.Clear();
            if (dgvPhongTrong.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgvPhongTrong.SelectedRows.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    DataGridViewRow row = dgvPhongTrong.SelectedRows[i];
                    item.SubItems.Add(row.Cells["Phong"].Value.ToString());
                    item.SubItems.Add(row.Cells["Loai"].Value.ToString());
                    item.SubItems.Add(row.Cells["SoNguoi"].Value.ToString());
                    item.SubItems.Add(row.Cells["Gia"].Value.ToString());
                    
                    lvdp.Items.Add(item);
                }

            }
        }
        private void cboKh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_KH();
        }

        

        private void dgvPhongTrong_SelectionChanged(object sender, EventArgs e)
        {
            ChonPhong();
        }

        private void txtTienCoc_TextChanged(object sender, EventArgs e)
        {
            lsvChiTiet.Items[8].SubItems[1].Text = txtTienCoc.Text;
        }

        private void txtNgayDen_ValueChanged(object sender, EventArgs e)
        {
            lsvChiTiet.Items[6].SubItems[1].Text = txtNgayDen.Value.ToShortDateString();
        }

        private void txtNgayDi_ValueChanged(object sender, EventArgs e)
        {
            lsvChiTiet.Items[7].SubItems[1].Text = txtNgayDi.Value.ToShortDateString();
        }
        private bool checkEmpty()
        {
            if (string.IsNullOrEmpty(txtMaPD.Text))
            {
                MessageBox.Show("Mã phiếu đặt không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtTienCoc.Text))
            {
                MessageBox.Show("Tiền cọc không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool IsNumber()
        {
            Regex regex = new Regex(@"^[+]?[0-9]*\.?[0-9]+$");
            if (regex.IsMatch(txtTienCoc.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Tiền cọc phải là số và không được âm", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool checkExistMaPD()
        {
            var pd = (from dp in db.tbl_datphongs
                      where dp.Mapd == txtMaPD.Text
                      select dp).ToList();
            if (pd.Any())
            {
                MessageBox.Show("Mã phiếu đặt đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnDat_Click(object sender, EventArgs e)
        {
            if (checkEmpty() && checkExistMaPD() && IsNumber() && checkNgayDen()&& checkDate())
            {
                tbl_datphong dp = new tbl_datphong();
                dp.Mapd = txtMaPD.Text;

                dp.SoDienThoai = (cboKh.SelectedItem as tbl_khachhang).SoDienThoai;
                dp.SoTienDat = Convert.ToDouble(txtTienCoc.Text);
                dp.NgayDen = txtNgayDen.Value;
                dp.NgayDi = txtNgayDi.Value;
                dp.TinhTrang = false;
                dp.TinhTrangHD = true;
                if (dgvPhongTrong.CurrentRow !=null)
                {
                    var r = dgvPhongTrong.CurrentRow;
                    dp.MaPhong = r.Cells["MaPhong"].Value.ToString();
                }
                
                db.tbl_datphongs.InsertOnSubmit(dp);
                db.SubmitChanges();



                for (int i = 0; i < dgvPhongTrong.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = dgvPhongTrong.SelectedRows[i];
                    tbl_chitietdat ctd = new tbl_chitietdat();
                    ctd.Mapd = txtMaPD.Text;
                    ctd.MaPhong = row.Cells["MaPhong"].Value.ToString();
                    db.tbl_chitietdats.InsertOnSubmit(ctd);
                    ;

                }
                db.SubmitChanges();
                txtMaPD.Text = txtTienCoc.Text = "";
                MessageBox.Show("Thành công", "Đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DSDat();
            }
            

        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.CurrentRow!=null)
            {
                var r = dgvDatPhong.CurrentRow;

                var mp = from dp in db.tbl_chitietdats
                         where dp.Mapd.Equals(r.Cells["MaPhieu"].Value.ToString())
                         select dp;
                foreach (var item in mp)
                {
                    maphong = item.MaPhong;
                }
                db.UpdateNhanPhong(r.Cells["MaPhieu"].Value.ToString());
                db.UpdatePhong(maphong);
                Load_PhongTrong();
                Load_DSDat();
                MessageBox.Show("Thành công", "Nhận Phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMHC frm = new frmMHC();
                frm.Load_Phong();
                

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvDatPhong.CurrentRow!=null)
            {
                var r = dgvDatPhong.CurrentRow;
                var mp = from dp in db.tbl_chitietdats
                         where dp.Mapd.Equals(r.Cells["MaPhieu"].Value.ToString())
                         select dp;
                foreach (var item in mp)
                {
                    maphong = item.MaPhong;
                }
                db.DelChiTietDat(r.Cells["MaPhieu"].Value.ToString());
                db.DelNhanPhong(r.Cells["MaPhieu"].Value.ToString());
                db.UpdateTTPhong(maphong);
                db.SubmitChanges();
                Load_PhongTrong();
                Load_DSDat();
                MessageBox.Show("Thành công", "Hủy Nhận Phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMHC frm = new frmMHC();
                frm.Load_Phong();
            }
        }
    }
}
