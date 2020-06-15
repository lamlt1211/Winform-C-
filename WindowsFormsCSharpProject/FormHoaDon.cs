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
    public partial class frmHoaDon : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        public string mapd { get; set; }
        public string maphong { get; set; }
        public int mahd { get; set; }
        public string  sdt { get; set; }
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            Load_HD();
        }
        
        private void Load_HD()
        {
            dgvHD.DataSource = from hd in db.tbl_hoadons
                               join kh in db.tbl_khachhangs
                               on hd.SoDienThoai equals kh.SoDienThoai
                               join nv in db.tbl_nhanviens
                               on hd.MaNhanVien equals nv.MaNhanVien
                               select new
                               {
                                   MaPhong = hd.MaPhong,
                                   MaHoaDon = hd.MaHoaDon,
                                   SoDienThoai = kh.SoDienThoai,
                                   TenKhachHang = kh.TenKhachHang,
                                   MaNhanVien = nv.MaNhanVien,
                                   TenNhanVien = nv.TenNhanVien,
                                   NgayLap = hd.NgayLap,
                                   TinhTrang =(bool) hd.TrangThai ? "Chưa Thanh Toán" : "Đã Thanh Toán"

                               };
        }

        private void btnAddHD_Click(object sender, EventArgs e)
        {
            
        }
        private void Details_HD()
        {
            

        }
        private void btnSaveHD_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvHD_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelHD_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

           


                
                db.UpdateTTHD(sdt);
                var mp = (from hd in db.tbl_hoadons
                          where hd.SoDienThoai == sdt
                          select hd).ToList();
                foreach (var item in mp)
                {
                    maphong = item.MaPhong;
                    db.UpdateTTPhong(maphong);
                }
               

                db.UpdateTTDP(sdt);

                Load_HD();
            }
        }
            
        }
    

