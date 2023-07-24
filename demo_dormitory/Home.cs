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
    
    public partial class Home : UserControl
    {
        SqlConnection conn;
        SqlDataAdapter da;
        
        public Home()
        {
            InitializeComponent();
            
        }

        private void lbCount_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            DataSet ds  = new DataSet();
            string sql = "Select * from tblStudent";
            da = new SqlDataAdapter(sql,frmLogin.con);
            da.Fill(ds, "dtCountStd");
            lbCountStudent.Text = ds.Tables["dtCountStd"].Rows.Count.ToString();


            sql = "Select * from tblStaff";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtCountStaff");
            lbCountStaff.Text = ds.Tables["dtCountStaff"].Rows.Count.ToString();


            sql = "Select * from tblDormitory";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtCountDorm");
            lbCountDormitory.Text = ds.Tables["dtCountDorm"].Rows.Count.ToString();


            sql = "Select * from tblLive";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtCountLive");
            lbCountRent.Text = ds.Tables["dtCountLive"].Rows.Count.ToString();

        }
    }
}
