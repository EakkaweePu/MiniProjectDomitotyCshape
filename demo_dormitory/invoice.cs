using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace demo_dormitory
{
    public partial class invoice : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        SqlDataAdapter da;
        public invoice()
        {
            InitializeComponent();
            conn = new SqlConnection(frmLogin.con);
        }
        private void getInvoice()
        {
            
            ds = new DataSet();
            if (ds.Tables.Contains("dtViewInvoice "))
            {
                ds.Tables.Remove("dtViewInvoice");
            }
            string sql = "SELECT * FROM ViewInvoice";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtViewInvoice");
            gridInvoice.DataSource = ds.Tables["dtViewInvoice"];
            
        }
        private void invoice_Load(object sender, EventArgs e)
        {
            getInvoice();
            string sql = "Select r_id from tblLive";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtRoom");
            cbbRoom.Text = "Select Room";
            cbbRoom.Items.Clear();
            foreach (DataRow dr in ds.Tables["dtRoom"].Rows)
            {
                cbbRoom.Items.Add(dr["r_id"].ToString());
            }
        }
        private bool checkFill()
        {
            if (txtInvoiceID.Text == "" || cbbRoom.Text == "Select Room" || txtAfter.Text == "" || txtBefore.Text == "")
            {
                return true;
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM tblInvoice WHERE in_id = '" + txtInvoiceID.Text + "';", conn);
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
                //User Exists
                try
                {
                    if (checkFill())
                    {
                        MessageBox.Show("Please fill in the blanks.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        cmd = new SqlCommand("update tblInvoice " +
                            "set  in_id = '" + txtInvoiceID.Text + "', " +
                            " r_id = '" + cbbRoom.SelectedItem + "', " +
                            " rate_elec = 4.5 ," +
                            " before_elec = '" + txtBefore.Text + "' , " +
                            " after_elec = '" + txtAfter.Text + "' ," +
                            " water_fee = 100 " +
                            " where in_id = '" + txtInvoiceID.Text + "' ; ", conn);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getInvoice();
                        clearData();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (checkFill())
                    {
                        MessageBox.Show("Please fill in the blanks.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        cmd = new SqlCommand("insert into tblInvoice(in_id,r_id,rate_elec,before_elec,after_elec,water_fee) VALUES('" + txtInvoiceID.Text + "' , '"+cbbRoom.SelectedItem +"' , 4.5 , '"+txtBefore.Text+"' , '"+txtAfter.Text+"' , 100 )", conn);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getInvoice();
                        clearData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void clearData()
        {

            txtInvoiceID.Text = "";
            cbbRoom.Text = "Select Room";
            txtBefore.Text = "";
            txtAfter.Text = "";
        }
        private void gridInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else {
                txtInvoiceID.Text = gridInvoice.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbRoom.Text = gridInvoice.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtBefore.Text = gridInvoice.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtAfter.Text = gridInvoice.Rows[e.RowIndex].Cells[6].Value.ToString();
                gridInvoice.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            txtInvoiceID.Focus();
            gridInvoice.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete data?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    cmd = new SqlCommand("DELETE  FROM tblInvoice WHERE in_id = '" + txtInvoiceID.Text + "'", conn);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The information has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getInvoice();
                    clearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                clearData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                dt = new DataTable();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from ViewInvoice where [invoice id] LIKE '%" + txtSearch.Text + "%' or  dormitory LIKE '%" + txtSearch.Text + "%' or Room  like '%" + txtSearch.Text + "%'", conn);
                da.Fill(dt);
                gridInvoice.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
