using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCSharpProject.Reports;

namespace WindowsFormsCSharpProject
{
    public partial class frmXuatHD : Form
    {
        ProjectCSharpDataContext db;
        public string madp { get; set; }
        public int mahd { get; set; }
        public string sdt { get; set; }
        public float PhiDv { get; set; }
        public float PhiThue { get; set; }
        public float Tiencoc { get; set; }
        public frmXuatHD()
        {
            InitializeComponent();
            db= new ProjectCSharpDataContext();
        }

        private void FormXuatHoaDon_Load(object sender, EventArgs e)
        {


            /*RptHoaDon rpt = new RptHoaDon();
            var data = db.XuatBaoCao(mahd).Select(x => new HoaDon
            {
                TenKhachHang = x.TenKhachHang,
                TenNhanVien = x.TenNhanVien,
                TenPhong = x.TenPhong,
                GiaPhong = (float)(x.GiaPhong),
                TenDichVu = x.TenDichVu,
                SoLuong = (int)x.SoLuong,
                GiaDichVu = (float)x.GiaDichVu,
                Mapd = x.Mapd,
                TienCoc = (float)x.SoTienDat,
                PhiDichVu = frmChiTiet.PhiDV,
                PhiThue = frmChiTiet.PhiThue,
                TongTien = frmChiTiet.PhiDV + frmChiTiet.PhiThue - (float)x.SoTienDat              
                

            }).ToList();
            rpt.SetDataSource(data);
            rptViewer.ReportSource = rpt;

            rptViewer.Show();*/
            RptHoaDon rpt = new RptHoaDon();
            var dt = db.XuatBaoCao(sdt).Select(x => new HoaDon
            {
                TenKhachHang = x.TenKhachHang,
                TenNhanVien = x.TenNhanVien,
                TenPhong = x.TenPhong,
                GiaPhong = (float)x.GiaPhong,
                TenDichVu = x.TenDichVu,
                SoLuong = (int)x.SoLuong,
                GiaDichVu = (float)x.GiaDichVu,
                Mapd = x.Mapd,
                TienCoc = Tiencoc,
                PhiDichVu = PhiDv,
                PhiThue = PhiThue,
                TongTien = PhiDv + PhiThue- Tiencoc

            }).ToList();
            rpt.SetDataSource(dt);
            rptViewer.ReportSource = rpt;
            rptViewer.Show();


        }
    }
}
