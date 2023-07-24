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
    public partial class studentControl : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        public studentControl()
        {
            InitializeComponent();
            conn = new SqlConnection(frmLogin.con);
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        DataSet ds = new DataSet();
        private void getStudent() 
        {
            // ถ้ามีให้ลบออกไปก่อน
             if (ds.Tables.Contains("View")) {
                ds.Tables.Remove("View");
            }
            // เรียกตาราง student
            string sql = "SELECT * FROM ViewStudent";
            SqlDataAdapter da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "View");
            gridStudent.DataSource = ds.Tables["View"];   
        }
        /*
        public void upDateDB(string tblName, DataTable dt) 
        {
            string sql = "SELECT * FROM " + tblName;
            SqlDataAdapter da = new SqlDataAdapter(sql,frmLogin.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
        }*/
        private void studentControl_Load(object sender, EventArgs e)
        {
            getStudent();
            

        }

        private void clearData() {

            txtStudentID.Text = "";
            txtStudentName.Text = "";
            txtPhoneNumber.Text = "";
            txtStudentAddress.Text = "";
            pictureBox1.Image = null;
            rdoMale.Checked = false;
            rdoFeMale.Checked = false;
        }

        private void gridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) 
                return; 
            else
            { 
                    txtStudentID.Text = gridStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtStudentName.Text = gridStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (gridStudent.Rows[e.RowIndex].Cells[2].Value.Equals("หญิง"))
                    rdoFeMale.Checked = true;
                else
                    rdoMale.Checked = true;
                txtPhoneNumber.Text = gridStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtStudentAddress.Text = gridStudent.Rows[e.RowIndex].Cells[4].Value.ToString();

                pictureBox1.Image = null;
                SqlDataAdapter dAdapter = new SqlDataAdapter(new SqlCommand("SELECT s_picture FROM tblStudent " +
                        "where s_id = '"+ gridStudent.Rows[e.RowIndex].Cells[0].Value.ToString() + "' and s_picture IS NOT NULL", conn));
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet);
                if (dSet.Tables[0].Rows.Count == 1)
                {
                        Byte[] data = new Byte[0];
                        data = (Byte[])(dSet.Tables[0].Rows[0]["s_picture"]);
                        MemoryStream mem = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(mem);
                    
                }
                gridStudent.Rows[e.RowIndex].Selected = true;
            }
        }
        private bool checkFill() {
            if (txtStudentID.Text == "" || txtStudentName.Text == "" || txtPhoneNumber.Text == "" || txtStudentAddress.Text == "" || pictureBox1.Image == null
                           || (!rdoFeMale.Checked && !rdoMale.Checked))
            {
                return true;
            }
            return false;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        string g;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM tblStudent WHERE s_id = '"+txtStudentID.Text+"';", conn);
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
                //User Exists
                try
                {
                    if (checkFill())
                    {
                        MessageBox.Show("Please fill in the blanks.","error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
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
                        cmd = new SqlCommand("update tblStudent " +
                            "set  s_id = '" + txtStudentID.Text + "', " +
                            " s_name = '" + txtStudentName.Text + "', " +
                            " gender = '" + g + "' , " +
                            " s_tel = '" + txtPhoneNumber.Text + "' , " +
                            " s_address = '" + txtStudentAddress.Text + "' , s_picture = @image1" +
                            " where s_id = '" + txtStudentID.Text + "' ; ", conn);
                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("image1", memstr.ToArray());
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getStudent();
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
                    if (checkFill()) {
                        MessageBox.Show("Please fill in the blanks.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        cmd = new SqlCommand("insert into tblStudent(s_id,s_name,gender,s_tel,s_address,s_picture) " +
                            "VALUES('" + txtStudentID.Text + "','" +
                            txtStudentName.Text + "','" +
                            g + "','" +
                            txtPhoneNumber.Text + "','" +
                            txtStudentAddress.Text + "', @image1) ", conn);
                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("image1", memstr.ToArray());
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getStudent();
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
            DialogResult dialogResult = MessageBox.Show("Do you want to delete data?", "Delete Data",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    cmd = new SqlCommand("DELETE  FROM tblStudent WHERE s_id = '" + txtStudentID.Text + "'", conn);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The information has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getStudent();
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
                SqlDataAdapter da = new SqlDataAdapter("select * from ViewStudent where [Student ID] LIKE '%" + txtSearch.Text + "%' or  Name LIKE '%" + txtSearch.Text + "%' or gender  like '%" + txtSearch.Text + "%'", conn);
                da.Fill(dt);
                gridStudent.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
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

        private void gridStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            txtStudentID.Focus();
            gridStudent.ClearSelection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
/*
 * 
 * try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd = new SqlCommand("DELETE  FROM tblStudent WHERE s_id = '" + txtStudentID.Text + "'",conn);
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("The information has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getStudent();
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 */