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
    public partial class Room : UserControl
    {
        DataSet ds;
        SqlDataAdapter da;
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        public Room()
        {
            InitializeComponent();
            conn = new SqlConnection(frmLogin.con);
        }
        private void getRoom()
        {
            ds = new DataSet();
            if (ds.Tables.Contains("dtViewRoom "))
            {
                ds.Tables.Remove("dtViewRoom");
            }
            string sql = "SELECT * FROM ViewRoom";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtViewRoom");
            gridRoom.DataSource = ds.Tables["dtViewRoom"];
        }
        private void clearData()
        {

            txtRoomID.Text = "";
            cbbNameDormitory.Text = "Selcet Dormitory";
            txtFloor.Text = "";
            cbbNumStudent.Text = "Select Number";
           
        }
        private void Room_Load(object sender, EventArgs e)
        {
            getRoom();
            string sql = "Select * FROM tblDormitory";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtDormitory");
            cbbNameDormitory.DisplayMember = "d_name";
            cbbNameDormitory.ValueMember = "d_id";
            cbbNameDormitory.DataSource = ds.Tables["dtDormitory"];
            cbbNameDormitory.Text = "Select Dormitory";
            cbbNumStudent.Text = "Select Number";

            
        }

        private void gridRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else
            {
                txtRoomID.Text = gridRoom.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbNameDormitory.Text = gridRoom.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtFloor.Text = gridRoom.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbbNumStudent.Text = gridRoom.Rows[e.RowIndex].Cells[3].Value.ToString();
                gridRoom.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            txtRoomID.Focus();
            gridRoom.ClearSelection();
        }
        private bool checkFill()
        {
            if (txtRoomID.Text == "" || txtFloor.Text == "" ||  cbbNumStudent.Text == "Select Number" || cbbNameDormitory.Text == "Select Dormitory")
                          
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
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM tblRoom WHERE r_id = '" + txtRoomID.Text + "';", conn);
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
                        cmd = new SqlCommand("update tblRoom " +
                            "set  r_id = '" + txtRoomID.Text + "', " +
                            " d_id = '" + cbbNameDormitory.SelectedValue + "', " +
                            " r_floor = '" + txtFloor.Text + "' , " +
                            " num_people = '" + cbbNumStudent.SelectedItem + "'" +
                            " where r_id = '" + txtRoomID.Text + "' ; ", conn);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getRoom();
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
                        cmd = new SqlCommand("insert into tblRoom(r_id,d_id,r_floor,num_people) " +
                            "VALUES('" + txtRoomID.Text + "','" +
                            cbbNameDormitory.SelectedValue.ToString() + "','" +
                            txtFloor.Text + "','" +
                            cbbNumStudent.SelectedItem + "')" , conn);
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getRoom();
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
                    cmd = new SqlCommand("DELETE  FROM tblRoom WHERE r_id = '" + txtRoomID.Text + "'", conn);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The information has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getRoom();
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
                SqlDataAdapter da = new SqlDataAdapter("select * from ViewRoom where [Room number] LIKE '%" + txtSearch.Text + "%' or  DormitoryName LIKE '%" + txtSearch.Text + "%' or Status  like '%" + txtSearch.Text + "%'", conn);
                da.Fill(dt);
                gridRoom.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
