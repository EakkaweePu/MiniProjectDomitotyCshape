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
    public partial class Rental : UserControl
    {
        
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        DataSet ds;
        SqlDataAdapter da;
        public Rental()
        {
            InitializeComponent();
            conn = new SqlConnection(frmLogin.con);
        }
        private void checkCbb(string dt){
           
            if (ds.Tables.Contains(dt))
            {
                ds.Tables.Remove(dt);
            }
            /*
            
            */
        }

        private void getLive()
        {
            ds = new DataSet();
            if (ds.Tables.Contains("ViewLive"))
            {
                ds.Tables.Remove("ViewLive");
            }
            string sql = "SELECT * FROM ViewLive";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "ViewLive");
            gridRental.DataSource = ds.Tables["ViewLive"];
        }
        private void Rental_Load(object sender, EventArgs e)
        {
            getLive();
            
            string sql = "Select * FROM tblStudent";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtStudent");
            cbbStudent.DisplayMember = "s_name";
            cbbStudent.ValueMember = "s_id";
            cbbStudent.DataSource = ds.Tables["dtStudent"];
            cbbStudent.Text = "Select Student";
            cbbDormitory.Text = "Select Dormitory";
            cbbRoom.Text = "Select Room";
            
        }

        private void cbbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbbStudent.SelectedValue.ToString() != null) {
                checkCbb("dtDormitory");
                string sql = "Select dr.d_id , dr.d_name FROM tblDormitory as dr , tblStudent as std where std.s_id = '" + cbbStudent.SelectedValue.ToString() + "' and dr.gender = std.gender;";
                da = new SqlDataAdapter(sql, frmLogin.con);
                da.Fill(ds, "dtDormitory");
                cbbDormitory.DisplayMember = "d_name";
                cbbDormitory.ValueMember = "d_id";
                cbbDormitory.DataSource = ds.Tables["dtDormitory"];
                cbbDormitory.Text = "Select Dormitory";
                

            }
        }

        private void cbbDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkCbb("dtRoom");
            string sql = "select r.r_id From tblRoom as r , tblDormitory as dr where dr.d_id = '" + cbbDormitory.SelectedValue.ToString() + "' and dr.d_id = r.d_id and  num_people < 3; ";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtRoom");
            cbbDormitory.Text = "Select Room";
            cbbRoom.Items.Clear();
            foreach (DataRow dr in ds.Tables["dtRoom"].Rows) {
                cbbRoom.Items.Add(dr["r_id"].ToString());
            }
           // cbbRoom.DataSource = ds.Tables["dtRoom"];
            
        }
        private void clearData()
        {

            txtRentalId.Text = "";
            cbbDormitory.Text = "Select Dormitory";
            cbbRoom.Text = "Select Room";
            cbbStudent.Text = "Select Student";
        }
        private bool checkFill()
        {
            if (txtRentalId.Text == "" || cbbStudent.Text == "Select Student" || cbbDormitory.Text == "Select Dormitory" || cbbRoom.Text == "Select Room")
            {
                return true;
            }
            return false;
        }

        private void gridRental_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else
            {
                txtRentalId.Text = gridRental.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbStudent.Text = gridRental.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbbDormitory.Text = gridRental.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbbRoom.Text = gridRental.Rows[e.RowIndex].Cells[3].Value.ToString();
                gridRental.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            txtRentalId.Focus();
            gridRental.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM tblLive WHERE l_id = '" + txtRentalId.Text + "';", conn);
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
                        cmd = new SqlCommand("update tblLive " +
                            "set  l_id = '" + txtRentalId.Text + "', " +
                            " s_id = '" + cbbStudent.SelectedValue + "', " +
                            " d_id = '" + cbbDormitory.SelectedValue + "' , " +
                            " r_id = '" + cbbRoom.SelectedItem + "' " +
                            " where l_id = '" + txtRentalId.Text + "' ; ", conn);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getLive();
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
                        cmd = new SqlCommand("insert into tblLive(l_id,s_id,d_id,r_id) " +
                            "VALUES('" + txtRentalId.Text + "','" +
                            cbbStudent.SelectedValue.ToString() + "','" +
                            cbbDormitory.SelectedValue.ToString() + "','" +
                            cbbRoom.SelectedItem + "')" , conn);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getLive();
                        clearData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                    cmd = new SqlCommand("DELETE  FROM tblLive WHERE l_id = '" + txtRentalId.Text + "'", conn);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The information has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getLive();
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
                SqlDataAdapter da = new SqlDataAdapter("select * from ViewLive where [Rental ID] LIKE '%" + txtSearch.Text + "%' or  Name LIKE '%" + txtSearch.Text + "%' or Dormitory  like '%" + txtSearch.Text + "%' or [Room number] like '%" + txtSearch.Text + "%'", conn);
                da.Fill(dt);
                gridRental.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
