namespace demo_dormitory
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new FontAwesome.Sharp.IconButton();
            this.btnPosition = new FontAwesome.Sharp.IconButton();
            this.btnInvoice = new FontAwesome.Sharp.IconButton();
            this.btnRental = new FontAwesome.Sharp.IconButton();
            this.btnRoom = new FontAwesome.Sharp.IconButton();
            this.btnDormitory = new FontAwesome.Sharp.IconButton();
            this.btnStaff = new FontAwesome.Sharp.IconButton();
            this.btnStudent = new FontAwesome.Sharp.IconButton();
            this.btnHome = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(208)))), ((int)(((byte)(178)))));
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnPosition);
            this.panel1.Controls.Add(this.btnInvoice);
            this.panel1.Controls.Add(this.btnRental);
            this.panel1.Controls.Add(this.btnRoom);
            this.panel1.Controls.Add(this.btnDormitory);
            this.panel1.Controls.Add(this.btnStaff);
            this.panel1.Controls.Add(this.btnStudent);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 845);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnLogout.IconColor = System.Drawing.Color.Black;
            this.btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLogout.IconSize = 40;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 783);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(223, 62);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "    Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.iconButton1_Click_1);
            // 
            // btnPosition
            // 
            this.btnPosition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosition.FlatAppearance.BorderSize = 0;
            this.btnPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosition.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosition.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            this.btnPosition.IconColor = System.Drawing.Color.Black;
            this.btnPosition.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPosition.IconSize = 40;
            this.btnPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosition.Location = new System.Drawing.Point(0, 338);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnPosition.Size = new System.Drawing.Size(223, 62);
            this.btnPosition.TabIndex = 4;
            this.btnPosition.Text = "    Position";
            this.btnPosition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosition.UseVisualStyleBackColor = true;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInvoice.FlatAppearance.BorderSize = 0;
            this.btnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoice.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            this.btnInvoice.IconColor = System.Drawing.Color.Black;
            this.btnInvoice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInvoice.IconSize = 40;
            this.btnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.Location = new System.Drawing.Point(-1, 610);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnInvoice.Size = new System.Drawing.Size(223, 62);
            this.btnInvoice.TabIndex = 3;
            this.btnInvoice.Text = "    invoice";
            this.btnInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnRental
            // 
            this.btnRental.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRental.FlatAppearance.BorderSize = 0;
            this.btnRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRental.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRental.IconChar = FontAwesome.Sharp.IconChar.Bed;
            this.btnRental.IconColor = System.Drawing.Color.Black;
            this.btnRental.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRental.IconSize = 40;
            this.btnRental.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRental.Location = new System.Drawing.Point(-3, 542);
            this.btnRental.Name = "btnRental";
            this.btnRental.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnRental.Size = new System.Drawing.Size(223, 62);
            this.btnRental.TabIndex = 3;
            this.btnRental.Text = "    Rental";
            this.btnRental.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRental.UseVisualStyleBackColor = true;
            this.btnRental.Click += new System.EventHandler(this.btnRental_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoom.FlatAppearance.BorderSize = 0;
            this.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoom.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            this.btnRoom.IconColor = System.Drawing.Color.Black;
            this.btnRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRoom.IconSize = 40;
            this.btnRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom.Location = new System.Drawing.Point(-3, 474);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnRoom.Size = new System.Drawing.Size(223, 62);
            this.btnRoom.TabIndex = 3;
            this.btnRoom.Text = "    Room";
            this.btnRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRoom.UseVisualStyleBackColor = true;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnDormitory
            // 
            this.btnDormitory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDormitory.FlatAppearance.BorderSize = 0;
            this.btnDormitory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDormitory.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDormitory.IconChar = FontAwesome.Sharp.IconChar.Hotel;
            this.btnDormitory.IconColor = System.Drawing.Color.Black;
            this.btnDormitory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDormitory.IconSize = 40;
            this.btnDormitory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDormitory.Location = new System.Drawing.Point(-3, 406);
            this.btnDormitory.Name = "btnDormitory";
            this.btnDormitory.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnDormitory.Size = new System.Drawing.Size(223, 62);
            this.btnDormitory.TabIndex = 3;
            this.btnDormitory.Text = "    Dormitory";
            this.btnDormitory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDormitory.UseVisualStyleBackColor = true;
            this.btnDormitory.Click += new System.EventHandler(this.btnDormitory_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnStaff.IconColor = System.Drawing.Color.Black;
            this.btnStaff.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStaff.IconSize = 40;
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Location = new System.Drawing.Point(0, 270);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnStaff.Size = new System.Drawing.Size(223, 62);
            this.btnStaff.TabIndex = 3;
            this.btnStaff.Text = "    Staff";
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudent.FlatAppearance.BorderSize = 0;
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudent.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btnStudent.IconColor = System.Drawing.Color.Black;
            this.btnStudent.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStudent.IconSize = 40;
            this.btnStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudent.Location = new System.Drawing.Point(0, 202);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnStudent.Size = new System.Drawing.Size(223, 62);
            this.btnStudent.TabIndex = 3;
            this.btnStudent.Text = "    Student";
            this.btnStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Black;
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.btnHome.IconColor = System.Drawing.Color.Black;
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.IconSize = 40;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 134);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(222, 62);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "    Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(245)))), ((int)(((byte)(222)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 132);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PSU Stidti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dormitory Manage System";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(55, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(107, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(245)))), ((int)(((byte)(222)))));
            this.panel3.Controls.Add(this.lbStatus);
            this.panel3.Controls.Add(this.lbWelcome);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(223, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1159, 132);
            this.panel3.TabIndex = 1;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("PSU Stidti", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(25, 78);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 51);
            this.lbStatus.TabIndex = 6;
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Location = new System.Drawing.Point(862, 48);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(95, 31);
            this.lbWelcome.TabIndex = 5;
            this.lbWelcome.Text = "welcome";
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(223, 132);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1159, 713);
            this.content.TabIndex = 2;
            this.content.Paint += new System.Windows.Forms.PaintEventHandler(this.content_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(69)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(1382, 845);
            this.Controls.Add(this.content);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("PSU Stidti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btnRental;
        private FontAwesome.Sharp.IconButton btnRoom;
        private FontAwesome.Sharp.IconButton btnDormitory;
        private FontAwesome.Sharp.IconButton btnStaff;
        private FontAwesome.Sharp.IconButton btnStudent;
        private FontAwesome.Sharp.IconButton btnHome;
        private System.Windows.Forms.Panel content;
        private FontAwesome.Sharp.IconButton btnPosition;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbStatus;
        private FontAwesome.Sharp.IconButton btnInvoice;
        private FontAwesome.Sharp.IconButton btnLogout;
    }
}