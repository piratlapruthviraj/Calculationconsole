using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculationconsole
{
    public partial class CVForm : Form
    {
        public CVForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void CVForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            string conString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "SELECT Prefix, FullName, Title, DPT.DEPARTMENTNAME, CAST(Hiredate AS DATE) Hiredate, MobilePhone, Email, Address " +
                    "FROM dbo.EMPLOYEE EMP(NOLOCK), dbo.DEPARTMENT DPT(NOLOCK) " +
                    "WHERE EMP.DPTID = DPT.DPTID";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "SELECT DEPARTMENTNAME, DEPARTMENTSTATUS AS STATUS FROM dbo.Department";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                comboBox4.DisplayMember = "DEPARTMENTNAME";
                comboBox4.ValueMember = "DPTID";
                comboBox4.DataSource = dt;
            }
            dataGridView1.Columns[0].Width = 300;
            dataGridView1.Columns[1].Width = 260;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[6].Width = 300;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Button_save_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("First Name is Required");
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Last Name is Required");
                textBox2.Focus();
                return;
            }

            string conString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = @"INSERT INTO dbo.EMPLOYEE (FIRSTNAME, LASTNAME, FULLNAME, BIRTHDATE, TITLE, PREFIX,
                                ADDRESS, CITY, STATE, ZIPCODE, HOMEPHONE, MOBILEPHONE, EMAIL, SKYPE, HIREDATE, DPTID) 
                                VALUES
                                (@FirstName, @LastName, @FullName, @BirthDate, @Title, @prefix,
                                 @Address, @city, @state, @ZipCode, @HomePhone, @MobilePhone, @Email, @Skype, @HireDate, DPTID)";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@FullName", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Title", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@prefix", comboBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@city", textBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@state", comboBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@ZipCode", textBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@HomePhone", textBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@MobilePhone", textBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", textBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@Skype", textBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@HireDate", dateTimePicker2.Value.Date);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Record Inserted SuccessFully.");
                        CVForm_Load(sender, e);

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


    }
}
