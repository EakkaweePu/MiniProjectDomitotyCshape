using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_dormitory
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        DataSet ds = new DataSet();
        public static string con = "Data Source=.\\SQLEXPRESS;Initial Catalog=Dormitory; UID = sa; password = 123; ";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblLogin WHERE username='" + txtUserName.Text + "' AND password='" + txtPassword.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con); 
            DataTable dt = new DataTable();
            sda.Fill(dt);

            string sql2 = "SELECT sf.sf_name FROM tblLogin as lg , tblStaff as sf where lg.username = '"+txtUserName.Text+ "' and  lg.sf_id = sf.sf_id";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt.Rows.Count == 1)
            {
                //dt2.Rows[0]["sf_name"].ToString()
                string name = "weclome " + dt2.Rows[0]["sf_name"].ToString();
                
                frmMain Main = new frmMain(name);
                this.Hide();
                Main.Show();
            }
            else if ((txtUserName.Text.ToString().Trim() == string.Empty) || (txtPassword.Text.ToString().Trim() == string.Empty)) {
                MessageBox.Show("Please complete the information.", "an error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                txtPassword.Text = null;
            }
            else
            {
                MessageBox.Show("Invalid username or password", "an error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Text = null;
                txtPassword.Text = null;
                txtUserName.Focus();

            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
