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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculationconsole
{
    public partial class supplier : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        public supplier()
        {
            InitializeComponent();
        }

        private void Page_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (!dataGridView1.Columns.Contains("EditColumn"))
            {
                var editCol = new DataGridViewButtonColumn
                {
                    Name = "EditColumn",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridView1.Columns.Add(editCol);
            }

            if (!dataGridView1.Columns.Contains("DeleteColumn"))
            {
                var deleteCol = new DataGridViewButtonColumn
                {
                    Name = "DeleteColumn",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridView1.Columns.Add(deleteCol);
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "SELECT SupplierID, SupplierName, ContactNumber, Email FROM dbo.SUPPLIERS";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SupName.Text))
            {
                MessageBox.Show("Please enter Supplier Name.");
                SupName.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(SupContact.Text))
            {
                MessageBox.Show("Please enter Supplier Contact Number");
                SupContact.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(SupEmail.Text))
            {
                MessageBox.Show("Please enter Supplier Email");
                SupEmail.Focus();
                return;
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = @"INSERT INTO dbo.SUPPLIERS (SupplierName, ContactNumber, Email) 
                                VALUES
                                (@SupplierName, @ContactNumber, @Email)";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@SupplierName", SupName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNumber", SupContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", SupEmail.Text.Trim());

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier Record Inserted SuccessFully.");
                        Page_Load(sender, e);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var grid = (DataGridView)sender;
            var column = grid.Columns[e.ColumnIndex];
            if (column.Name != "EditColumn" && column.Name != "DeleteColumn") return;

            var row = grid.Rows[e.RowIndex];
            if (row?.DataBoundItem == null) return;

            var employeeIdObj = row.Cells["SupplierID"]?.Value;
            if (employeeIdObj == null || employeeIdObj == DBNull.Value) return;

            int employeeId = Convert.ToInt32(employeeIdObj);

            //if (column.Name == "DeleteColumn")
            //{
            //    _ = OnDeleteEmployeeAsync(employeeId);
            //    CVForm_Load(sender, e);
            //}

            //else
            if (column.Name == "EditColumn")
            {
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                row = dataGridView1.Rows[e.RowIndex];

                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                txt.Text = row.Cells["SupplierID"].Value.ToString();
                txt.Name = row.Cells["ContactNumber"].Value.ToString();

                const string sql = "UPDATE SUPPLIERS SET ContactNumber = @ContactNumber WHERE SupplierID = @SupplierID;";

                using (var con = new SqlConnection(conString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ContactNumber", txt.Name);
                    cmd.Parameters.AddWithValue("@SupplierID", txt.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Supplier Record Updated Successfully");
                    Page_Load(sender, e);
                }

            }
        }
    }
}