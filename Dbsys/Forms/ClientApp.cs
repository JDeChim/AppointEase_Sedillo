using Dbsys.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dbsys.Forms
{
    public partial class ClientApp : Form
    {
        public ClientApp()
        {
            InitializeComponent();
        }
        public void RetrieveData(string cname, string pname, string petType, DateTime pDOB, DateTime aDate, string aTime, string cComment)
        {
            using (var db = new DBSYSEntities())
            {
                // Query the ClientDashboarD table based on the input values
                var query = from client in db.ClientDashboarD
                            where client.CName == cname &&
                                  client.PName == pname &&
                                  client.PetType == petType &&
                                  client.PDOB == pDOB &&
                                  client.ADate == aDate &&
                                  client.ATime == aTime &&
                                  client.CComment == cComment
                            select client;

                // Bind the query results to dataGridView2
                dataGridView2.DataSource = query.ToList();
            }
        }
        private void LoadDataToDataGridView2()
        {
            try
            {

                // Retrieve data from the ClientDashboard table
                using (var db = new DBSYSEntities())
                {
                    var clients = db.ClientDashboarD.ToList();

                    // Clear existing columns and rows in dataGridView2
                    dataGridView2.Columns.Clear();
                    dataGridView2.Rows.Clear();

                    // Add columns to dataGridView2
                    dataGridView2.Columns.Add("CNo", "CNo");
                    dataGridView2.Columns.Add("CName", "CName");
                    dataGridView2.Columns.Add("PName", "PName");
                    dataGridView2.Columns.Add("PetType", "PetType");
                    dataGridView2.Columns.Add("PDOB", "PDOB");
                    dataGridView2.Columns.Add("ADate", "ADate");
                    dataGridView2.Columns.Add("ATime", "ATime");
                    dataGridView2.Columns.Add("CComment", "CComment");

                    // Add rows to dataGridView2
                    foreach (var client in clients)
                    {
                        dataGridView2.Rows.Add(
                            client.CNo,
                            client.CName,
                            client.PName,
                            client.PetType,
                            client.PDOB,
                            client.ADate,
                            client.ATime,
                            client.CComment
                        );
                    }
                }

            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                MessageBox.Show($"Error: {ex.Message}\nInner Exception: {innerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected row index
                int selectedRowIndex = dataGridView2.SelectedCells[0].RowIndex;

                // Retrieve data from the Temp_Table
                using (var db = new DBSYSEntities())
                {
                    // Get the corresponding TempNo from the selected row
                    int tempNoToDelete = Convert.ToInt32(dataGridView2.Rows[selectedRowIndex].Cells["CNo"].Value);

                    // Find the row to delete
                    var tempRowToDelete = db.ClientDashboarD.FirstOrDefault(temp => temp.CNo == tempNoToDelete);

                    if (tempRowToDelete != null)
                    {
                        // Delete the row from the database
                        db.ClientDashboarD.Remove(tempRowToDelete);
                        db.SaveChanges();

                        // Refresh the dataGridView2 by re-fetching data from the database
                        var clients = db.ClientDashboarD.ToList();
                        dataGridView2.Rows.Clear();

                        foreach (var client in clients)
                        {
                            dataGridView2.Rows.Add(
                                client.CNo,
                                client.CName,
                                client.PName,
                                client.PetType,
                                client.PDOB,
                                client.ADate,
                                client.ATime,
                                client.CComment
                               
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                MessageBox.Show($"Error: {ex.Message}\nInner Exception: {innerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientApp_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected PDOB and ADate from the DateTimePicker
               // DateTime selectedPDOB = dateTimePicker1.Value;
                DateTime selectedADate = dateTimePicker2.Value;

                // Get the corresponding values for cname, pname, and petType from dataGridView2
                string cname = dataGridView2.CurrentRow.Cells["CName"].Value.ToString();
                string pname = dataGridView2.CurrentRow.Cells["PName"].Value.ToString();
                string petType = dataGridView2.CurrentRow.Cells["PetType"].Value.ToString();

                // Update the PDOB and ADate fields in the SQL table
                UpdateData(cname, pname, petType, selectedADate);

                // Refresh the data in dataGridView2
                LoadDataToDataGridView2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateData(string cname, string pname, string petType, DateTime aDate)
        {
            using (var db = new DBSYSEntities())
            {
                // Query the ClientDashboard table based on the input values
                var query = from client in db.ClientDashboarD
                            where client.CName == cname &&
                                  client.PName == pname &&
                                  client.PetType == petType
                            select client;

                // Update the PDOB and ADate fields for the matching records
                foreach (var client in query)
                {
                    //client.PDOB = pDOB;
                    client.ADate = aDate;
                }

                // Save the changes to the database
                db.SaveChanges();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Admin_Dashboard admin_Dashboard = new Frm_Admin_Dashboard();
            admin_Dashboard.Show();
            this.Close();
        }
    }
}
