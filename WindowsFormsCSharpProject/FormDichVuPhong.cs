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
    public partial class frmDVP : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        public int t { get; set; }
        public string madv { get; set; }
        public static int mahd { get; set; }
        public int madvp { get; set; }
        public string sdt { get; set; }
        public static string mapd { get; set; }
        public int songay { get; set; }
        public static string maphong { get; set; }

        public frmDVP()
        {
            InitializeComponent();
        }

        private void frmDVP_Load(object sender, EventArgs e)
        {
            
            Load_cboPhong();
            maphong = (cboPhong.SelectedItem as tbl_phong).MaPhong;
            Load_DichVuPhong();
            lbPhieuDat.Visible = false;
            cboPhieuDat.Visible = false;
            mapd = (cboPhieuDat.SelectedItem as tbl_datphong).Mapd;

            t = total();
            
        }

        private void Load_cboPhieudat()
        {
            cboPhieuDat.DataSource = (from pd in db.tbl_datphongs
                                      where pd.TinhTrangHD == true && pd.MaPhong == (cboPhong.SelectedItem as tbl_phong).MaPhong
                                      select pd).ToList();
            cboPhieuDat.DisplayMember = "Mapd";
            cboPhieuDat.ValueMember = "Mapd";

        }

        private bool checknumber()
        {
            int sln = 0;
            var r = dgvDichVuPhong.CurrentRow;
            madv = r.Cells["MaDV"].Value.ToString();
            for (int i = 0; i < dgvDichVuDaChon.Rows.Count; i++)
            {

                if (madv == dgvDichVuDaChon.Rows[i].Cells["MaDichVu"].Value.ToString())
                {
                    sln = (Convert.ToInt32(dgvDichVuDaChon.Rows[i].Cells["SoLuong"].Value.ToString())) + (Convert.ToInt32(txtSoLuong.Text));

                    var _dv = db.tbl_dichvuphongs.FirstOrDefault(x => x.MaDichVu.Equals(madv) && x.Mapd.Equals((cboPhieuDat.SelectedItem as tbl_datphong).Mapd));

                    _dv.SoLuong = sln;

                    db.SubmitChanges();
                    Load_DVDaChon();
                    return false;
                }
            }
            return true;
        }
        public int total()
        {
            int tongtien = 0;
            for (int i = 0; i < dgvDichVuDaChon.Rows.Count; i++)
            {
                if (dgvDichVuDaChon.Rows[i].Cells["ThanhTien"] != null && dgvDichVuDaChon.Rows[i].Cells["ThanhTien"].Value != null)
                {
                    tongtien += int.Parse(dgvDichVuDaChon.Rows[i].Cells["ThanhTien"].Value.ToString());
                }
            }
            return tongtien;
        }
        private void Load_DichVuPhong()
        {
            dgvDichVuPhong.DataSource = from dv in db.tbl_dichvus
                                        select new
                                        {

                                            MaDV = dv.MaDichVu,
                                            TenDichVu = dv.TenDichVu,
                                            MieuTa = dv.MieuTa,
                                            GiaDichVu = dv.GiaDichVu,
                                        };
        }

        private void Load_DVDaChon()
        {


            var p = (cboPhong.SelectedItem as tbl_phong).MaPhong;
            mapd = (cboPhieuDat.SelectedItem as tbl_datphong).Mapd;
            dgvDichVuDaChon.DataSource = from dvp in db.tbl_dichvuphongs
                                         join dv in db.tbl_dichvus
                                         on dvp.MaDichVu equals dv.MaDichVu
                                         where dvp.MaPhong == p && dvp.Mapd == mapd
                                         select new
                                         {
                                             MaDVP = dvp.MaDichVuPhong,
                                             MaDichVu = dvp.MaDichVu,
                                             TenDV = dv.TenDichVu,
                                             GiaDV = dv.GiaDichVu,
                                             SoLuong = dvp.SoLuong,
                                             ThanhTien = dvp.SoLuong * dv.GiaDichVu
                                         };
            total();

            txtTotal.Text = total().ToString();



        }
        private void Load_cboPhong()
        {
            cboPhong.DataSource = (from p in db.tbl_phongs
                                   where p.TinhTrang == false 
                                   select p).ToList();
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }
        private bool checkHD()
        {
            var dt = (from hd in db.tbl_hoadons
                     where hd.MaPhong == (cboPhong.SelectedItem as tbl_phong).MaPhong && hd.TrangThai == true
                     select hd).ToList();
            if (dt.Any())
            {
                MessageBox.Show("Phòng đã có hóa đơn không thể thêm dịch vụ", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                
            }
            return true;  

        }
        private bool checkNullSL()
        {
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Số Lượng không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnHuyDichVu_Click(object sender, EventArgs e)
        {
            if (dgvDichVuDaChon.CurrentRow != null)
            {
                var r = dgvDichVuDaChon.CurrentRow;
                var del = db.tbl_dichvuphongs.FirstOrDefault(x => x.MaDichVuPhong == Convert.ToInt32(r.Cells["MaDVP"].Value.ToString()));
                db.tbl_dichvuphongs.DeleteOnSubmit(del);
                db.SubmitChanges();
                Load_DVDaChon();
            }
        }

        private void cboPhong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_DVDaChon();


        }


        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (checknumber()&&checkHD())
            {
                if (dgvDichVuPhong.CurrentRow != null && checkNullSL())
                {

                    var r = dgvDichVuPhong.CurrentRow;
                    tbl_dichvuphong dvp = new tbl_dichvuphong();
                    dvp.MaDichVu = r.Cells["MaDV"].Value.ToString();
                    dvp.MaPhong = (cboPhong.SelectedItem as tbl_phong).MaPhong;
                    dvp.Mapd = (cboPhieuDat.SelectedItem as tbl_datphong).Mapd;
                    dvp.SoLuong = Convert.ToInt32(txtSoLuong.Text);
                    dvp.DonGia = Convert.ToDouble(15000);
                    db.tbl_dichvuphongs.InsertOnSubmit(dvp);
                    db.SubmitChanges();
                    Load_DVDaChon();
                    txtSoLuong.Text = "1";
                }
            }
        }

        private void btnADDDH_Click(object sender, EventArgs e)
        {
            var datphong = from dp in db.tbl_datphongs
                           where dp.MaPhong == (cboPhong.SelectedItem as tbl_phong).MaPhong
                           select dp;
                    
            foreach (var item in datphong)
            {
                sdt = item.SoDienThoai;
                mapd = item.Mapd;
                TimeSpan ts;
                DateTime nd = Convert.ToDateTime(item.NgayDen);
                DateTime nt = Convert.ToDateTime(item.NgayDi);
                ts = nt - nd;
                songay = ts.Days;

            }
            var ctd = db.tbl_chitietdats.ToList();

            db.InsertOrder(sdt, frmLogin.nhanvien.MaNhanVien, true, (cboPhong.SelectedItem as tbl_phong).MaPhong, DateTime.Now);
            var dh = from hd in db.tbl_hoadons
                     select hd;
            if (dh.Count() > 0)
            {
                mahd = dh.ToList().Last().MaHoaDon;

            }
            

            db.InsertOrderDetail((cboPhong.SelectedItem as tbl_phong).MaPhong, null, (cboPhieuDat.SelectedItem as tbl_datphong).Mapd, mahd, songay, 15000);

            db.SubmitChanges();
            MessageBox.Show("Thêm vào hóa đơn thành công", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cboPhieuDat_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Load_DVDaChon();



        }

        private void cboPhieuDat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_cboPhieudat();
            Load_DVDaChon();
        }
    }


}

