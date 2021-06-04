
namespace PBL3_DATVEXE.View
{
    partial class AffterLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AffterLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.veCuaToi = new System.Windows.Forms.Button();
            this.searchRout1 = new PBL3_DATVEXE.View.SearchRout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(46, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chào bạn! ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox2.Image = global::PBL3_DATVEXE.Properties.Resources.bus;
            this.pictureBox2.Location = new System.Drawing.Point(32, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(187, 212);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 775);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // veCuaToi
            // 
            this.veCuaToi.BackColor = System.Drawing.Color.Transparent;
            this.veCuaToi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.veCuaToi.Location = new System.Drawing.Point(0, 320);
            this.veCuaToi.Name = "veCuaToi";
            this.veCuaToi.Size = new System.Drawing.Size(255, 74);
            this.veCuaToi.TabIndex = 8;
            this.veCuaToi.Text = "Vé của tôi";
            this.veCuaToi.UseVisualStyleBackColor = false;
            this.veCuaToi.Click += new System.EventHandler(this.veCuaToi_Click);
            // 
            // searchRout1
            // 
            this.searchRout1.arrival = null;
            this.searchRout1.BackColor = System.Drawing.Color.White;
            this.searchRout1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchRout1.BackgroundImage")));
            this.searchRout1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchRout1.date = new System.DateTime(((long)(0)));
            this.searchRout1.Location = new System.Drawing.Point(254, 0);
            this.searchRout1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchRout1.Name = "searchRout1";
            this.searchRout1.Size = new System.Drawing.Size(1264, 761);
            this.searchRout1.TabIndex = 7;
            // 
            // AffterLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1517, 600);
            this.Controls.Add(this.veCuaToi);
            this.Controls.Add(this.searchRout1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AffterLogin";
            this.Text = "AfterLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private buttonSearch buttonSearch1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private SearchRout searchRout1;
        private System.Windows.Forms.Button veCuaToi;
    }
}