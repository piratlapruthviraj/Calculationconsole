using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculationconsole
{
    public partial class Products : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        public Products()
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
                string sql = "SELECT PRODUCTID, PRODUCTNAME, SKU, Quantity, PRICE FROM dbo.PRODUCTMASTER";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductName.Text))
            {
                MessageBox.Show("Please enter Product Name.");
                ProductName.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(SKU.Text))
            {
                MessageBox.Show("Please enter Product SKU Number");
                SKU.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(Price.Text))
            {
                MessageBox.Show("Please enter Product Price");
                Price.Focus();
                return;
            }

            else if (string.IsNullOrWhiteSpace(Quantity.Text))
            {
                MessageBox.Show("Please enter Product Quantity");
                Quantity.Focus();
                return;
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = @"INSERT INTO dbo.PRODUCTMASTER (PRODUCTNAME, SKU, PRICE, Quantity) 
                                VALUES
                                (@PRODUCTNAME, @SKU, @PRICE, @Quantity)";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@PRODUCTNAME", ProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SKU", SKU.Text.Trim());
                    cmd.Parameters.AddWithValue("@PRICE", Price.Text.Trim());
                    cmd.Parameters.AddWithValue("@Quantity", Quantity.Text.Trim());

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product Record Inserted SuccessFully.");
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

            var employeeIdObj = row.Cells["PRODUCTID"]?.Value;
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
                txt.Text = row.Cells["PRODUCTID"].Value.ToString();
                txt.Name = row.Cells["PRICE"].Value.ToString();

                const string sql = "UPDATE PRODUCTMASTER SET PRICE = @PRICE WHERE PRODUCTID = @PRODUCTID;";

                using (var con = new SqlConnection(conString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@PRICE", txt.Name);
                    cmd.Parameters.AddWithValue("@PRODUCTID", txt.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Product Record Updated Successfully");
                    Page_Load(sender, e);
                }

            }
        }
    }
}
