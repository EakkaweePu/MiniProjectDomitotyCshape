using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_dormitory
{
    public partial class frmMain : Form
    {
        public frmMain(string name_login)
        {
            
            InitializeComponent();
            lbWelcome.Text = name_login;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        Home home = new Home();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Home";
            showControl(home);
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            studentControl stdc = new studentControl();
            showControl(stdc);
            lbStatus.Text = "Student";
        }

        public void showControl(Control control) { 
        content.Controls.Clear();

        control.Dock = DockStyle.Fill;
        control.BringToFront();
        control.Focus();
        content.Controls.Add(control);
        
        
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
           // staff
           staffControl1 sfc = new staffControl1();
            showControl(sfc);
            lbStatus.Text = "Staff";

        }

        private void btnDormitory_Click(object sender, EventArgs e)
        {
            Dormitory dtr = new Dormitory();
            showControl(dtr);
            lbStatus.Text = "Dormitory";
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            showControl(room);
            lbStatus.Text = "Room";
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            Posotion pos = new Posotion();
            showControl(pos);
            lbStatus.Text = "Position";
        }

        private void btnRental_Click(object sender, EventArgs e)
        {
            Rental rental = new Rental();
            showControl(rental);
            lbStatus.Text = "Rental";
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            
            invoice invoice = new invoice();
            showControl(invoice);
            lbStatus.Text = "invoice";

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            showControl(home);
            lbStatus.Text = "Home";
        }

        private void content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to log out?", "log out", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                frmLogin frmout = new frmLogin();
                frmout.Show();
                
                

            }
            else {
                return;
            }
        }
    }
}
