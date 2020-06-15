namespace WindowsFormsCSharpProject
{
    partial class frmDVP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnHuyDichVu = new System.Windows.Forms.Button();
            this.dgvDichVuPhong = new System.Windows.Forms.DataGridView();
            this.MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MieuTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDichVuDaChon = new System.Windows.Forms.DataGridView();
            this.TenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnADDDH = new System.Windows.Forms.Button();
            this.cboPhieuDat = new System.Windows.Forms.ComboBox();
            this.lbPhieuDat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaChon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHuyDichVu
            // 
            this.btnHuyDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHuyDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDichVu.ForeColor = System.Drawing.Color.White;
            this.btnHuyDichVu.Location = new System.Drawing.Point(409, 436);
            this.btnHuyDichVu.Name = "btnHuyDichVu";
            this.btnHuyDichVu.Size = new System.Drawing.Size(96, 29);
            this.btnHuyDichVu.TabIndex = 5;
            this.btnHuyDichVu.Text = "Hủy Dịch Vụ";
            this.btnHuyDichVu.UseVisualStyleBackColor = false;
            this.btnHuyDichVu.Click += new System.EventHandler(this.btnHuyDichVu_Click);
            // 
            // dgvDichVuPhong
            // 
            this.dgvDichVuPhong.AllowUserToAddRows = false;
            this.dgvDichVuPhong.AllowUserToDeleteRows = false;
            this.dgvDichVuPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVuPhong.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDichVuPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDV,
            this.TenDichVu,
            this.MieuTa,
            this.GiaDichVu});
            this.dgvDichVuPhong.Location = new System.Drawing.Point(12, 135);
            this.dgvDichVuPhong.MultiSelect = false;
            this.dgvDichVuPhong.Name = "dgvDichVuPhong";
            this.dgvDichVuPhong.ReadOnly = true;
            this.dgvDichVuPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVuPhong.Size = new System.Drawing.Size(358, 293);
            this.dgvDichVuPhong.TabIndex = 8;
            // 
            // MaDV
            // 
            this.MaDV.DataPropertyName = "MaDV";
            this.MaDV.HeaderText = "Mã Dịch Vụ";
            this.MaDV.Name = "MaDV";
            this.MaDV.ReadOnly = true;
            // 
            // TenDichVu
            // 
            this.TenDichVu.DataPropertyName = "TenDichVu";
            this.TenDichVu.HeaderText = "Tên Dịch Vụ";
            this.TenDichVu.Name = "TenDichVu";
            this.TenDichVu.ReadOnly = true;
            // 
            // MieuTa
            // 
            this.MieuTa.DataPropertyName = "MieuTa";
            this.MieuTa.HeaderText = "Miêu Tả";
            this.MieuTa.Name = "MieuTa";
            this.MieuTa.ReadOnly = true;
            // 
            // GiaDichVu
            // 
            this.GiaDichVu.DataPropertyName = "GiaDichVu";
            this.GiaDichVu.HeaderText = "Giá Dịch Vụ";
            this.GiaDichVu.Name = "GiaDichVu";
            this.GiaDichVu.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Danh Sách Dịch Vụ";
            // 
            // dgvDichVuDaChon
            // 
            this.dgvDichVuDaChon.AllowUserToAddRows = false;
            this.dgvDichVuDaChon.AllowUserToDeleteRows = false;
            this.dgvDichVuDaChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVuDaChon.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDichVuDaChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuDaChon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenDV,
            this.MaDVP,
            this.DonGia,
            this.MaDichVu,
            this.GiaDV,
            this.SoLuong,
            this.ThanhTien});
            this.dgvDichVuDaChon.Location = new System.Drawing.Point(409, 135);
            this.dgvDichVuDaChon.MultiSelect = false;
            this.dgvDichVuDaChon.Name = "dgvDichVuDaChon";
            this.dgvDichVuDaChon.ReadOnly = true;
            this.dgvDichVuDaChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVuDaChon.Size = new System.Drawing.Size(370, 293);
            this.dgvDichVuDaChon.TabIndex = 10;
            // 
            // TenDV
            // 
            this.TenDV.DataPropertyName = "TenDV";
            this.TenDV.HeaderText = "Tên Dịch Vụ";
            this.TenDV.Name = "TenDV";
            this.TenDV.ReadOnly = true;
            // 
            // MaDVP
            // 
            this.MaDVP.DataPropertyName = "MaDVP";
            this.MaDVP.HeaderText = "Mã Dịch Vụ Phòng";
            this.MaDVP.Name = "MaDVP";
            this.MaDVP.ReadOnly = true;
            this.MaDVP.Visible = false;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.Visible = false;
            // 
            // MaDichVu
            // 
            this.MaDichVu.DataPropertyName = "MaDichVu";
            this.MaDichVu.HeaderText = "Mã Dịch Vụ";
            this.MaDichVu.Name = "MaDichVu";
            this.MaDichVu.ReadOnly = true;
            this.MaDichVu.Visible = false;
            // 
            // GiaDV
            // 
            this.GiaDV.DataPropertyName = "GiaDV";
            this.GiaDV.HeaderText = "Giá Dịch Vụ";
            this.GiaDV.Name = "GiaDV";
            this.GiaDV.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.SoLuong.DefaultCellStyle = dataGridViewCellStyle1;
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(405, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Dịch Vụ Đã Chọn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Phòng";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(114, 32);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(162, 21);
            this.cboPhong.TabIndex = 13;
            this.cboPhong.SelectedIndexChanged += new System.EventHandler(this.cboPhong_SelectedIndexChanged);
            this.cboPhong.SelectionChangeCommitted += new System.EventHandler(this.cboPhong_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(208, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Số Lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(282, 109);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(55, 20);
            this.txtSoLuong.TabIndex = 15;
            this.txtSoLuong.Text = "1";
            // 
            // btnThemDV
            // 
            this.btnThemDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThemDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDV.ForeColor = System.Drawing.Color.White;
            this.btnThemDV.Location = new System.Drawing.Point(271, 434);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(99, 29);
            this.btnThemDV.TabIndex = 16;
            this.btnThemDV.Text = "Thêm Dịch Vụ";
            this.btnThemDV.UseVisualStyleBackColor = false;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(604, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tổng Tiền";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(692, 439);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(87, 20);
            this.txtTotal.TabIndex = 18;
            // 
            // btnADDDH
            // 
            this.btnADDDH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnADDDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnADDDH.ForeColor = System.Drawing.Color.White;
            this.btnADDDH.Location = new System.Drawing.Point(658, 93);
            this.btnADDDH.Name = "btnADDDH";
            this.btnADDDH.Size = new System.Drawing.Size(121, 29);
            this.btnADDDH.TabIndex = 19;
            this.btnADDDH.Text = "Thêm Vào Hóa Đơn";
            this.btnADDDH.UseVisualStyleBackColor = false;
            this.btnADDDH.Click += new System.EventHandler(this.btnADDDH_Click);
            // 
            // cboPhieuDat
            // 
            this.cboPhieuDat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieuDat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cboPhieuDat.FormattingEnabled = true;
            this.cboPhieuDat.Location = new System.Drawing.Point(474, 31);
            this.cboPhieuDat.Name = "cboPhieuDat";
            this.cboPhieuDat.Size = new System.Drawing.Size(162, 21);
            this.cboPhieuDat.TabIndex = 23;
            this.cboPhieuDat.SelectedIndexChanged += new System.EventHandler(this.cboPhieuDat_SelectedIndexChanged);
            this.cboPhieuDat.SelectionChangeCommitted += new System.EventHandler(this.cboPhieuDat_SelectionChangeCommitted);
            // 
            // lbPhieuDat
            // 
            this.lbPhieuDat.AutoSize = true;
            this.lbPhieuDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhieuDat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbPhieuDat.Location = new System.Drawing.Point(365, 32);
            this.lbPhieuDat.Name = "lbPhieuDat";
            this.lbPhieuDat.Size = new System.Drawing.Size(88, 20);
            this.lbPhieuDat.TabIndex = 22;
            this.lbPhieuDat.Text = "Phiếu Đặt";
            // 
            // frmDVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(811, 543);
            this.Controls.Add(this.cboPhieuDat);
            this.Controls.Add(this.lbPhieuDat);
            this.Controls.Add(this.btnADDDH);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThemDV);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDichVuDaChon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDichVuPhong);
            this.Controls.Add(this.btnHuyDichVu);
            this.Name = "frmDVP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDichVuPhong";
            this.Load += new System.EventHandler(this.frmDVP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaChon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHuyDichVu;
        private System.Windows.Forms.DataGridView dgvDichVuPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MieuTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaDichVu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView dgvDichVuDaChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDVP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.Button btnADDDH;
        private System.Windows.Forms.ComboBox cboPhieuDat;
        private System.Windows.Forms.Label lbPhieuDat;
    }
}