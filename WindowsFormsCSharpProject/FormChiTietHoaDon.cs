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
    public partial class frmChiTiet : Form
        
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        public string sdt { get; set; }
        public int madvp{ get; set; }
        public static string mapd { get; set; }
        public int mahd { get; set; }
        public int songay { get; set; }
        public static string MaPhong { get; set; }
        public static float PhiDV { get; set; }
        public static float PhiThue { get; set; }
        public static string sodienthoai { get; set; }
        public frmChiTiet()
        {
            InitializeComponent();
        }

        private void frmChiTiet_Load(object sender, EventArgs e)
        {
            Load_cboPhong();
         

        }
        
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            
                
            
            
        }
        private void Load_DV()
        {
            
            var p = (cboPhong.SelectedItem as tbl_phong).MaPhong;
            
            dgvDV.DataSource = from cthd in db.tbl_chitiethoadons
                                         join hd in db.tbl_hoadons
                                         on cthd.MaHoaDon equals hd.MaHoaDon
                                         join ph in db.tbl_phongs
                                         on cthd.MaPhong equals ph.MaPhong
                                         join dp in db.tbl_datphongs
                                         on cthd.Mapd equals dp.Mapd
                                         join dvp in db.tbl_dichvuphongs
                                         on cthd.MaPhong equals dvp.MaPhong
                                         join dv in db.tbl_dichvus
                                         on dvp.MaDichVu equals dv.MaDichVu
                                         where dvp.MaPhong == p && hd.TrangThai == true && dvp.Mapd == dp.Mapd
            select new
                                                 {
                                                     TenDichVu = dv.TenDichVu,
                                                     Gia = dv.GiaDichVu,
                                                     SoLuong = dvp.SoLuong,
                                                     ThanhTien = dvp.SoLuong * dv.GiaDichVu
                                                     
                                                 };
            TongTien();
        }
        public int TongTien()
        {
            int tongtien = 0;
            
                for (int i = 0; i < dgvDV.Rows.Count; i++)
                {
                    if (dgvDV.Rows[i].Cells["ThanhTien"] != null && dgvDV.Rows[i].Cells["ThanhTien"].Value != null)
                    {
                        tongtien += int.Parse(dgvDV.Rows[i].Cells["ThanhTien"].Value.ToString());
                    }
                }
            
            
            return tongtien;
        }
        private void Load_cboPhong()
        {
            cboPhong.DataSource = (from p in db.tbl_phongs
                                  where p.TinhTrang == false
                                  select p).ToList();
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }
        
        private void Load_TT()
        {
            var dt = db.GetallByMaPhong((cboPhong.SelectedItem as tbl_phong).MaPhong).ToList();
            if (dt.Count>0)
            {
                foreach (var item in dt)
                {
                    MaPhong = (cboPhong.SelectedItem as tbl_phong).MaPhong;
                  
                    madvp = item.MaDichVuPhong;
                    mapd = item.Mapd;
                    TimeSpan ts;
                    DateTime nd = Convert.ToDateTime(item.NgayDen.Value);
                    DateTime nt = Convert.ToDateTime(item.NgayDi.Value);
                    ts = nt - nd;
                    songay = ts.Days;
                    double total = 0;
                    total += (double)(item.GiaDichVu * item.SoLuong);
                    txtNhanVien.Text = frmLogin.nhanvien.TenNhanVien;
                    txtPhong.Text = item.TenPhong;
                    txtNgayThue.Text = item.NgayDen.Value.ToShortDateString();
                    txtNgayTra.Text = item.NgayDi.Value.ToShortDateString();
                    txtPhiThue.Text = (item.GiaPhong * songay).ToString();
                    PhiThue = (float)item.GiaPhong * songay;
                    txtPhiDV.Text = TongTien().ToString();
                    PhiDV = TongTien();
                    txtTotal.Text = (TongTien() + (item.GiaPhong * songay)).ToString();
                }
            }
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            

            
            Load_DV();
            TongTien();
            Load_TT();
            
            
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNhanVien.Text = txtPhong.Text = txtNgayThue.Text = txtNgayTra.Text = txtPhiThue.Text = txtPhiDV.Text = txtTotal.Text = "";
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            frmXuatHD frm = new frmXuatHD();



            var hoadon = db.GetMaHD(MaPhong);
            
            foreach (var item in hoadon)
            {
                sdt = item.SoDienThoai;
                frm.sdt = item.SoDienThoai;
            }

            var xbc = (db.XuatBaoCao(sdt)).ToList();
            foreach (var item in xbc)
            {
                frm.PhiDv += (float)(item.SoLuong * item.GiaDichVu);
               
            }
            var bc = db.HD(sdt).ToList();
            foreach (var item in bc)
            {
                frm.Tiencoc +=(float) item.SoTienDat;
                frm.PhiThue += (float)(item.GiaPhong * item.SoNgayDaO);
            }
            
            frm.ShowDialog();
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            var hd = db.GetMaHD(MaPhong);
            foreach (var item in hd)
            {
                sdt = item.SoDienThoai;
                frm.sdt = item.SoDienThoai;
            }
           
            frm.Show();
        }
    }
}
