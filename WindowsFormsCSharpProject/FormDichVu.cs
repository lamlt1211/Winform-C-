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
    public partial class frmDichVu : Form
    {
        ProjectCSharpDataContext db = new ProjectCSharpDataContext();
        bool edit = false;
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Load_DV();
        }



        private void btnAddDV_Click(object sender, EventArgs e)
        {
            txtMaDV.Text = txtTenDV.Text = txtMT.Text = txtGiaDV.Text = "";
            txtMaDV.ReadOnly = false;
            edit = false;

        }
        private void Load_DV()
        {
            dgvDichVu.DataSource = from dv in db.tbl_dichvus
                                   where dv.TenDichVu.Contains(txtTimkiemDV.Text)
                                   select new
                                   {
                                       MaDichVu = dv.MaDichVu,
                                       TenDichVu = dv.TenDichVu,
                                       MieuTa = dv.MieuTa,
                                       GiaDichVu = dv.GiaDichVu,
                                   };
        }
        private void btnEditDV_Click(object sender, EventArgs e)
        {
            if (checkEmpty() && IsNumber())
            {

                if (edit)
                {
                    var _dv = db.tbl_dichvus.SingleOrDefault(x => x.MaDichVu.Equals(txtMaDV.Text));
                    _dv.TenDichVu = txtTenDV.Text;
                    _dv.MieuTa = txtMT.Text;
                    _dv.GiaDichVu = float.Parse(txtGiaDV.Text);
                    db.SubmitChanges();
                    Load_DV();
                }
                else
                {
                    if (checkExistTenDV() && checkMaDV())
                    {
                        tbl_dichvu dv = new tbl_dichvu();
                        dv.MaDichVu = txtMaDV.Text;
                        dv.TenDichVu = txtTenDV.Text;
                        dv.MieuTa = txtMT.Text;
                        dv.GiaDichVu = float.Parse(txtGiaDV.Text);
                        db.tbl_dichvus.InsertOnSubmit(dv);
                        db.SubmitChanges();
                        Load_DV();
                    }

                }

            }



        }
        private void Details_DV()
        {
            if (dgvDichVu.CurrentRow != null)
            {
                var _dv = dgvDichVu.CurrentRow;
                txtMaDV.Text = _dv.Cells["MaDichVu"].Value.ToString();
                txtTenDV.Text = _dv.Cells["TenDichVu"].Value.ToString();
                txtMT.Text = _dv.Cells["MieuTa"].Value.ToString();
                txtGiaDV.Text = _dv.Cells["GiaDichVu"].Value.ToString();
                txtMaDV.ReadOnly = true;
                edit = true;
            }
        }
        private void dgvDichVu_SelectionChanged(object sender, EventArgs e)
        {
            Details_DV();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            Load_DV();
        }
        private bool IsNumber()
        {
            Regex regex = new Regex(@"^[+]?[0-9]*\.?[0-9]+$");
            if (regex.IsMatch(txtGiaDV.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Giá Dịch Vụ phải là số và không được âm", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private bool checkMaDV()
        {
            var madv = (from dv in db.tbl_dichvus
                        where dv.MaDichVu == txtMaDV.Text
                        select dv).ToList();
            if (madv.Any())
            {
                MessageBox.Show("Mã dịch vụ đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkExistTenDV()
        {
            var tendv = (from dv in db.tbl_dichvus
                         where dv.TenDichVu == txtTenDV.Text
                         select dv).ToList();
            if (tendv.Any())
            {
                MessageBox.Show("Tên dịch vụ đã tồn tại", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool checkEmpty()
        {
            if (string.IsNullOrEmpty(txtMaDV.Text))
            {
                MessageBox.Show("Mã dịch vụ không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDV.Text))
            {
                MessageBox.Show("Tên dịch vụ không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtMT.Text))
            {
                MessageBox.Show("Miêu tả không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtGiaDV.Text))
            {
                MessageBox.Show("Giá dịch vụ không được để trống", "Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            var _dv = db.tbl_dichvus.SingleOrDefault(x => x.MaDichVu.Equals(txtMaDV.Text));
            if (MessageBox.Show("Bạn có muốn xóa dịch vụ này không", "Hệ Thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.tbl_dichvus.DeleteOnSubmit(_dv);
                db.SubmitChanges();
                Load_DV();
            }
        }

        private void btnDelDV_Click(object sender, EventArgs e)
        {
            Details_DV();
        }
    }
}
