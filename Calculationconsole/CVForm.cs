using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculationconsole
{
    public partial class CVForm : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
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
            if (!dataGridView2.Columns.Contains("EditColumn"))
            {
                var editCol = new DataGridViewButtonColumn
                {
                    Name = "EditColumn",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridView2.Columns.Add(editCol);
            }

            if (!dataGridView2.Columns.Contains("DeleteColumn"))
            {
                var deleteCol = new DataGridViewButtonColumn
                {
                    Name = "DeleteColumn",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridView2.Columns.Add(deleteCol);
            }
            string conString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "SELECT EMPID, Prefix, FullName, Title, DPT.DEPARTMENTNAME, CAST(Hiredate AS DATE) Hiredate, MobilePhone, Email, Address " +
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
            Button_save.Enabled = false;
            string DepartmentName = comboBox4.Text.Trim();
            int DeptID = GetDepartmentID(DepartmentName);
            if (string.IsNullOrWhiteSpace(textBox1.Text))
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

            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = @"INSERT INTO dbo.EMPLOYEE (FIRSTNAME, LASTNAME, FULLNAME, BIRTHDATE, TITLE, PREFIX,
                                ADDRESS, CITY, STATE, ZIPCODE, HOMEPHONE, MOBILEPHONE, EMAIL, SKYPE, HIREDATE, DPTID) 
                                VALUES
                                (@FirstName, @LastName, @FullName, @BirthDate, @Title, @prefix,
                                 @Address, @city, @state, @ZipCode, @HomePhone, @MobilePhone, @Email, @Skype, @HireDate, @DPTID)";

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
                    cmd.Parameters.AddWithValue("@DPTID", DeptID);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Record Inserted SuccessFully.");
                        CVForm_Load(sender, e);

                    }
                    catch (Exception ex)
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

        public int GetDepartmentID(string DepartmentName)
        {
            int departmentid = 0;
            string queryString = "SELECT DPTID FROM Department WHERE DepartmentName = @DepartmentName";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(queryString, con))
                {
                    command.Parameters.AddWithValue("@DepartmentName", DepartmentName);

                    try
                    {
                        var result = command.ExecuteScalar();

                        if (result != null)
                        {
                            departmentid = Convert.ToInt32(result.ToString());

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error retrieving department name: " + ex.Message);
                        // You might want to log the exception or throw it further up
                    }
                }
            }

            return departmentid;
        }

        private async Task OnDeleteEmployeeAsync(int employeeId)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this employee?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                await DeleteEmployeeAsync(employeeId);
                //   EnsureActionButtonsOnGrid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task DeleteEmployeeAsync(int employeeId)
        {
            const string sql = "DELETE FROM Employee WHERE EMPID = @EmployeeId;";

            using (var con = new SqlConnection(conString))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                MessageBox.Show("Employee removed successfully");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView2.AllowUserToAddRows = false;
            
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var grid = (DataGridView)sender;
            var column = grid.Columns[e.ColumnIndex];
            if (column.Name != "EditColumn" && column.Name != "DeleteColumn") return;

            var row = grid.Rows[e.RowIndex];
            if (row?.DataBoundItem == null) return;

            var employeeIdObj = row.Cells["EMPID"]?.Value;
            if (employeeIdObj == null || employeeIdObj == DBNull.Value) return;

            int employeeId = Convert.ToInt32(employeeIdObj);

            if (column.Name == "DeleteColumn")
            {
                _ = OnDeleteEmployeeAsync(employeeId);
                CVForm_Load(sender, e);
            }

            else if (column.Name == "EditColumn")
            {
                dataGridView2.EditMode = DataGridViewEditMode.EditOnEnter;
                row = dataGridView2.Rows[e.RowIndex];

                TextBox txt = new TextBox();
                txt.Text = row.Cells["EMPID"].Value.ToString();
                txt.Name = row.Cells["FULLNAME"].Value.ToString();

                const string sql = "UPDATE Employee SET FULLNAME = @FULLNAME WHERE EMPID = @EMPID;";

                using (var con = new SqlConnection(conString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@FULLNAME", txt.Name);
                    cmd.Parameters.AddWithValue("@EMPID", txt.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Employee Record Updated Successfully");
                    CVForm_Load(sender, e);
                }

            }

        }

    }
}
