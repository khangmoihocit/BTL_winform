using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ThongKeBaoCaoGUI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoanhThuDaThanhToan = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnChuaThanhToan = new System.Windows.Forms.Button();
            this.btnLayThongKe = new System.Windows.Forms.Button();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDoanhThuDaThanhToan);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnChuaThanhToan);
            this.panel1.Controls.Add(this.btnLayThongKe);
            this.panel1.Controls.Add(this.txtNam);
            this.panel1.Controls.Add(this.txtThang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 175);
            this.panel1.TabIndex = 1;
            // 
            // btnDoanhThuDaThanhToan
            // 
            this.btnDoanhThuDaThanhToan.AutoSize = true;
            this.btnDoanhThuDaThanhToan.Location = new System.Drawing.Point(695, 141);
            this.btnDoanhThuDaThanhToan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoanhThuDaThanhToan.Name = "btnDoanhThuDaThanhToan";
            this.btnDoanhThuDaThanhToan.Size = new System.Drawing.Size(239, 35);
            this.btnDoanhThuDaThanhToan.TabIndex = 14;
            this.btnDoanhThuDaThanhToan.Text = "Doanh thu đã thanh toán";
            this.btnDoanhThuDaThanhToan.UseVisualStyleBackColor = true;
            this.btnDoanhThuDaThanhToan.Click += new System.EventHandler(this.btnDoanhThuDaThanhToan_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Location = new System.Drawing.Point(939, 141);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 35);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnChuaThanhToan
            // 
            this.btnChuaThanhToan.AutoSize = true;
            this.btnChuaThanhToan.Location = new System.Drawing.Point(452, 141);
            this.btnChuaThanhToan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChuaThanhToan.Name = "btnChuaThanhToan";
            this.btnChuaThanhToan.Size = new System.Drawing.Size(239, 35);
            this.btnChuaThanhToan.TabIndex = 13;
            this.btnChuaThanhToan.Text = "Doanh thu chưa thanh toán";
            this.btnChuaThanhToan.UseVisualStyleBackColor = true;
            this.btnChuaThanhToan.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLayThongKe
            // 
            this.btnLayThongKe.AutoSize = true;
            this.btnLayThongKe.Location = new System.Drawing.Point(323, 141);
            this.btnLayThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLayThongKe.Name = "btnLayThongKe";
            this.btnLayThongKe.Size = new System.Drawing.Size(124, 35);
            this.btnLayThongKe.TabIndex = 13;
            this.btnLayThongKe.Text = "Lấy thống kê";
            this.btnLayThongKe.UseVisualStyleBackColor = true;
            this.btnLayThongKe.Click += new System.EventHandler(this.btnLayThongKe_Click);
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(225, 60);
            this.txtNam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(138, 30);
            this.txtNam.TabIndex = 9;
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(225, 16);
            this.txtThang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(138, 30);
            this.txtThang.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Năm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tháng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvThongKe);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 175);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(1045, 454);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê doanh thu";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKe.Location = new System.Drawing.Point(2, 27);
            this.dgvThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(1041, 425);
            this.dgvThongKe.TabIndex = 0;
            // 
            // ThongKeBaoCaoGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 629);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ThongKeBaoCaoGUI";
            this.Text = "ThongKeBaoCaoGUI";
            this.Load += new System.EventHandler(this.ThongKeBaoCaoGUI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnRefresh;
        private Button btnChuaThanhToan;
        private Button btnLayThongKe;
        private TextBox txtNam;
        private TextBox txtThang;
        private Label label2;
        private Label label1;
        private GroupBox groupBox1;
        private DataGridView dgvThongKe;
        private Button btnDoanhThuDaThanhToan;
    }
}