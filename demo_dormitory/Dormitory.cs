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
using System.IO;

namespace demo_dormitory
{
    public partial class Dormitory : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt;
        DataSet ds = new DataSet();
        public Dormitory()
        {
            InitializeComponent();
            conn = new SqlConnection(frmLogin.con);
        }
        private void getDormitory()
        {
            // ถ้ามีให้ลบออกไปก่อน
            if (ds.Tables.Contains("dtDormitory"))
            {
                ds.Tables.Remove("dtDormitory");
            }
            // เรียกตาราง student
            string sql = "SELECT * FROM  ViewDormitory";
            SqlDataAdapter da = new SqlDataAdapter(sql, frmLogin.con);
            da.Fill(ds, "dtDormitory");
            //  gridStudent.RowTemplate.Height = 75;
            gridDormitory.DataSource = ds.Tables["dtDormitory"];
        }

        private void Dormitory_Load(object sender, EventArgs e)
        {
            getDormitory();
        }
        private void clearData()
        {
            txtDormitoryID.Text = "";
            txtDomitorytName.Text = "";
            txtPhoneNumber.Text = "";
            txtDormitoryAddress.Text = "";
            pictureBox1.Image = null;
            rdoMale.Checked = false;
            rdoFeMale.Checked = false;
            txtCost.Text = "";
        }

        private void gridDormitory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            else
            {
                txtDormitoryID.Text = gridDormitory.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDomitorytName.Text = gridDormitory.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (gridDormitory.Rows[e.RowIndex].Cells[2].Value.Equals("หญิง"))
                    rdoFeMale.Checked = true;
                else
                    rdoMale.Checked = true;
                txtCost.Text = gridDormitory.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhoneNumber.Text = gridDormitory.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDormitoryAddress.Text = gridDormitory.Rows[e.RowIndex].Cells[5].Value.ToString();
                pictureBox1.Image = null;
                SqlDataAdapter dAdapter = new SqlDataAdapter(new SqlCommand("SELECT picture FROM tblDormitory " +
                        "where d_id = '" + gridDormitory.Rows[e.RowIndex].Cells[0].Value.ToString() + "' and picture IS NOT NULL", conn));
                DataSet dSet = new DataSet();
                dAdapter.Fill(dSet);
                if (dSet.Tables[0].Rows.Count == 1)
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(dSet.Tables[0].Rows[0]["picture"]);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);
                }
                gridDormitory.Rows[e.RowIndex].Selected = true;
            }
        }
        private bool checkFill()
        {
            if (txtDormitoryID.Text == "" || txtDomitorytName.Text == "" || txtPhoneNumber.Text == "" || txtDormitoryAddress.Text == "" || pictureBox1.Image == null || txtCost.Text == ""
                           || (!rdoFeMale.Checked && !rdoMale.Checked))
            {
                return true;
            }
            return false;
        }
        string g;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM tblDormitory WHERE d_id = '" + txtDormitoryID.Text + "';", conn);
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
                        cmd = new SqlCommand("update tblDormitory " +
                            "set  d_id = '" + txtDormitoryID.Text + "', " +
                            " d_name = '" + txtDomitorytName.Text + "', " +
                            " gender = '" + g + "' , " +
                            " d_phone = '" + txtPhoneNumber.Text + "' , " +
                            " cost = '" + txtCost.Text + "' ," +
                            " d_address = '" + txtDormitoryAddress.Text + "' , picture = @image1" +
                            " where d_id = '" + txtDormitoryID.Text + "' ; ", conn);
                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("image1", memstr.ToArray());
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getDormitory();
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
                        cmd = new SqlCommand("insert into tblDormitory(d_id,d_name,gender,cost,d_phone,d_address,picture) " +
                            "VALUES('" + txtDormitoryID.Text + "','" +
                            txtDomitorytName.Text + "','" +
                            g + "','" +
                            int.Parse(txtCost.Text) +  "','" +
                            txtPhoneNumber.Text + "','" +
                            txtDormitoryAddress.Text + "', @image1) ", conn);
                        MemoryStream memstr = new MemoryStream();
                        pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
                        cmd.Parameters.AddWithValue("image1", memstr.ToArray());
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("The information has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getDormitory();
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
                    cmd = new SqlCommand("DELETE FROM tblDormitory WHERE d_id = '" + txtDormitoryID.Text + "'", conn);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("The information has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getDormitory();
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
           txtDormitoryID.Focus();
            gridDormitory.ClearSelection();
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
                SqlDataAdapter da = new SqlDataAdapter("select * from ViewDormitory where  [Dormitory ID] LIKE '%" + txtSearch.Text + "%' or  Name LIKE '%" + txtSearch.Text + "%' or gender  like '%" + txtSearch.Text + "%'", conn);
                da.Fill(dt);
                gridDormitory.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
