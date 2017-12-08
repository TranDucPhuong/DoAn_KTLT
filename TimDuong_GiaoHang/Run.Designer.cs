namespace TimDuong_GiaoHang
{
    partial class Run
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
            this.but_thapHN = new System.Windows.Forms.Button();
            this.but_timdg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_thapHN
            // 
            this.but_thapHN.Location = new System.Drawing.Point(12, 12);
            this.but_thapHN.Name = "but_thapHN";
            this.but_thapHN.Size = new System.Drawing.Size(102, 23);
            this.but_thapHN.TabIndex = 0;
            this.but_thapHN.Text = "Hà Nội Tower";
            this.but_thapHN.UseVisualStyleBackColor = true;
            this.but_thapHN.Click += new System.EventHandler(this.but_thapHN_Click);
            // 
            // but_timdg
            // 
            this.but_timdg.Location = new System.Drawing.Point(155, 12);
            this.but_timdg.Name = "but_timdg";
            this.but_timdg.Size = new System.Drawing.Size(126, 23);
            this.but_timdg.TabIndex = 1;
            this.but_timdg.Text = "Tim Đường Giao Hàng";
            this.but_timdg.UseVisualStyleBackColor = true;
            this.but_timdg.Click += new System.EventHandler(this.but_timdg_Click);
            // 
            // Run
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 49);
            this.Controls.Add(this.but_timdg);
            this.Controls.Add(this.but_thapHN);
            this.Name = "Run";
            this.Text = "Run";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_thapHN;
        private System.Windows.Forms.Button but_timdg;

    }
}