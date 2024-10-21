namespace Chromaseed
{
    partial class About
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
            btnExit = new CustomControls.RJControls.RJButton();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.BackgroundColor = Color.Transparent;
            btnExit.BorderColor = Color.DarkGray;
            btnExit.BorderRadius = 5;
            btnExit.BorderSize = 1;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(15, 15, 15);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 15, 15);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.DarkGray;
            btnExit.Location = new Point(259, 6);
            btnExit.Name = "btnExit";
            btnExit.Padding = new Padding(1, 0, 0, 0);
            btnExit.Size = new Size(22, 22);
            btnExit.TabIndex = 29;
            btnExit.Text = "X";
            btnExit.TextColor = Color.DarkGray;
            btnExit.UseVisualStyleBackColor = false;
            // 
            // linkLabel3
            // 
            linkLabel3.ActiveLinkColor = Color.FromArgb(255, 128, 0);
            linkLabel3.AutoSize = true;
            linkLabel3.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel3.Location = new Point(149, 112);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(81, 15);
            linkLabel3.TabIndex = 35;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Tips / support";
            linkLabel3.VisitedLinkColor = Color.FromArgb(255, 128, 0);
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = Color.FromArgb(255, 128, 0);
            linkLabel2.AutoSize = true;
            linkLabel2.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel2.Location = new Point(149, 87);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(121, 15);
            linkLabel2.TabIndex = 34;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "More BXL909 projects";
            linkLabel2.VisitedLinkColor = Color.FromArgb(255, 128, 0);
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(255, 128, 0);
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(255, 128, 0);
            linkLabel1.Location = new Point(149, 63);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(117, 15);
            linkLabel1.TabIndex = 33;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Chromaseed website";
            linkLabel1.VisitedLinkColor = Color.FromArgb(255, 128, 0);
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 136);
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(143, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(116, 50);
            pictureBox2.TabIndex = 37;
            pictureBox2.TabStop = false;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            CancelButton = btnExit;
            ClientSize = new Size(287, 140);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.None;
            Name = "About";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            Paint += About_Paint;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.RJControls.RJButton btnExit;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}