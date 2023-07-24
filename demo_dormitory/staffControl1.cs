using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_dormitory
{
    public partial class staffControl1 : UserControl
    {
        DataSet ds;
        SqlDataAdapter da;
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        public staffControl1()
        {
            InitializeComponent();
            conn = new SqlConnection(frmLogin.con);
        }
        private void getStaff()
        {
            ds = new DataSet();
            if (ds.Tables.Contains("ViewStaff"))
            {
                ds.Tables.Remove("ViewStaff");
            }
            string sql = "SELECT * FROM ViewStaff";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "ViewStaff");
            gridStaff.DataSource = ds.Tables["ViewStaff"];
        }

        private void clearData()
        {

            txtStaffID.Text = "";
            txtStaffName.Text = "";
            txtPhoneNumber.Text = "";
            txtStaffAddress.Text = "";
            pictureBox1.Image = null;
            rdoMale.Checked = false;
            rdoFeMale.Checked = false;
            cbbPosition.Text = "Select position";
        }
        private bool checkFill()
        {
            if (txtStaffID.Text == "" || txtStaffName.Text == "" || txtPhoneNumber.Text == "" || txtStaffAddress.Text == "" || pictureBox1.Image == null || cbbPosition.Text == "Select position"
                           || (!rdoFeMale.Checked && !rdoMale.Checked))
            {
                return true;
            }
            return false;
        }

        private void staffControl1_Load(object sender, EventArgs e)
        {
            getStaff();
            string sql = "Select * FROM tblPosition";
            da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtPosition");
            cbbPosition.DisplayMember = "positionName";
            cbbPosition.ValueMember = "positionID";
            cbbPosition.DataSource = ds.Tables["dtPosition"];
            cbbPosition.Text = "Select position";
            
            

        }

        private void gridStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else
            {
                txtStaffID.Text = gridStaff.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtStaffName.Text = gridStaff.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (gridStaff.Rows[e.RowIndex].Cells[2].Value.Equals("หญิง"))
                    rdoFeMale.Checked = true;
                else
                    rdoMale.Checked = true;
                cbbPosition.Text = gridStaff.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhoneNumber.Text = gridStaff.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtStaffAddress.Text = gridStaff.Rows[e.RowIndex].Cells[5].Value.ToString();
                pictureBox1.Image = null;
                SqlDataAdapter sda = new SqlDataAdapter(new SqlCommand("SELECT picture FROM tblStaff " +
                        "where sf_id = '" + gridStaff.Rows[e.RowIndex].Cells[0].Value.ToString() + "' and picture IS NOT NULL", conn));
                DataSet dSet = new DataSet();
                sda.Fill(dSet);
                if (dSet.Tables[0].Rows.Count == 1)
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dSet.Tables[0].Rows[0]["picture"]);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);

                }
                gridStaff.Rows[e.RowIndex].Selected = true;
            }
        }
        string g = "";
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM tblStaff WHERE sf_id = '" + txtStaffID.Text + "';", conn);
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
                        if (rdoMale.Checked == true)
                        {
                            g = "ชาย";
                        }
                        else
                        {
                            g = "หญิง";
                        }
                        cmd = new SqlCommand("update tblStaff " +
                            "set  sf_id = '" + txtStaffID.Text + "', " +
                            " sf_name = '" + txtStaffName.Text + "', " +
                            " gender = '" + g + "' , " +
                            " sf_tel = '" + txtPhoneNumber.Text + "' , " +
                            " positionID = '"+ cbbPosition.SelectedValue + "', " +
                            " sf_address = '" + txtStaffAddress.Text + "' , " +
                            "picture = @image1" +
                            " where sf_id = '" + txtStaffID.Text + "' ; ", conn);
                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("image1", memstr.ToArray());
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getStaff();
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
                        if (rdoMale.Checked == true)
                        {
                            g = "ชาย";
                        }
                        else
                        {
                            g = "หญิง";
                        }
                        cmd = new SqlCommand("insert into tblStaff(sf_id,sf_name,gender,positionID,sf_tel,sf_address,picture) " +
                            "VALUES('" + txtStaffID.Text + "','" +
                            txtStaffName.Text + "','" +
                            g + "','" +
                            cbbPosition.SelectedValue.ToString() + "','" +
                            txtPhoneNumber.Text + "','" +
                            txtStaffAddress.Text + "', @image1) ", conn);
                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("image1", memstr.ToArray());
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getStaff();
                        clearData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        string imageLocation = "";
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG | *.jpg; *jpeg; *jpe; *jfif | PNG | *.png | BMP | *.bmp | all files | *.* ";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                pictureBox1.ImageLocation = imageLocation;
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
                    cmd = new SqlCommand("DELETE  FROM tblStaff WHERE sf_id = '" + txtStaffID.Text + "'", conn);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The information has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getStaff();
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
            txtStaffID.Focus();
            gridStaff.ClearSelection();
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
                SqlDataAdapter da = new SqlDataAdapter("select * from ViewStaff where  [Staff ID] LIKE '%" + txtSearch.Text + "%' or  Name LIKE '%" + txtSearch.Text + "%' or gender  like '%" + txtSearch.Text + "%' or Position  like '%" + txtSearch.Text + "%'", conn);
                da.Fill(dt);
                gridStaff.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
    
