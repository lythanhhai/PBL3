
namespace PBL3_DATVEXE.View
{
    partial class seeTicket
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNameGhe = new System.Windows.Forms.Label();
            this.lbGia = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbGia);
            this.panel1.Controls.Add(this.lbNameGhe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 78);
            this.panel1.TabIndex = 0;
            // 
            // lbNameGhe
            // 
            this.lbNameGhe.AutoSize = true;
            this.lbNameGhe.Location = new System.Drawing.Point(35, 26);
            this.lbNameGhe.Name = "lbNameGhe";
            this.lbNameGhe.Size = new System.Drawing.Size(51, 20);
            this.lbNameGhe.TabIndex = 0;
            this.lbNameGhe.Text = "label1";
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.Location = new System.Drawing.Point(350, 26);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(51, 20);
            this.lbGia.TabIndex = 1;
            this.lbGia.Text = "label2";
            // 
            // seeTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.panel1);
            this.Name = "seeTicket";
            this.Size = new System.Drawing.Size(441, 78);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.Label lbNameGhe;
    }
}
