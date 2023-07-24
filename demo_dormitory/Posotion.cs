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
    public partial class Posotion : UserControl
    {
        DataSet ds;
        SqlDataAdapter da;
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        public Posotion()
        {
            InitializeComponent();
            conn = new SqlConnection(frmLogin.con);
        }
        private void getposition()
        {
            ds = new DataSet();
            if (ds.Tables.Contains("tblPosition"))
            {
                ds.Tables.Remove("tblPosition");
            }
            string sql = "SELECT * FROM tblPosition";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "tblPosition");
            gridPosition.DataSource = ds.Tables["tblPosition"];
        }

        private void Posotion_Load(object sender, EventArgs e)
        {
            getposition();
        }

        private bool checkFill()
        {
            if (txtPositionID.Text == "" || txtPositionName.Text == "") 
            {
                return true;
            }
            return false;
        }

        private void gridPosition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else { 
            txtPositionID.Text = gridPosition.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPositionName.Text = gridPosition.Rows[e.RowIndex].Cells[1].Value.ToString();
            gridPosition.Rows[e.RowIndex].Selected = true;
            }
        }
        private void clearData()
        {
            txtPositionID.Text = "";
            txtPositionName.Text = "";  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM tblPosition WHERE positionID = '" + txtPositionID.Text + "';", conn);
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
                        cmd = new SqlCommand("update tblPosition " +
                            "set  positionID = '" + txtPositionID.Text + "', " +
                            " positionName = '" + txtPositionName.Text + "' " +
                            " where positionID = '" + txtPositionID.Text + "' ; ", conn);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getposition();
                        clearData();


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
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
                        cmd = new SqlCommand("insert into tblPosition(positionID,positionName) " +
                            "VALUES('" + txtPositionID.Text + "','" +
                            txtPositionName.Text + "')", conn);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getposition();
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
                    cmd = new SqlCommand("DELETE  FROM tblPosition WHERE positionID = '" + txtPositionID.Text + "'", conn);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The information has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getposition();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            txtPositionID.Focus();
            gridPosition.ClearSelection();
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
                SqlDataAdapter da = new SqlDataAdapter("select * from tblPosition where positionID LIKE '%" + txtSearch.Text + "%' or  positionName LIKE '%" + txtSearch.Text + "%'", conn);
                da.Fill(dt);
                gridPosition.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
