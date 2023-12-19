using Dbsys.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dbsys.Forms
{
    public partial class Approval : Form
    {
        DBSYSEntities db;
        public Approval()
        {
            InitializeComponent();
            db = new DBSYSEntities();
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
                    var tempRowToDelete = db.appointment_table.FirstOrDefault(temp => temp.CNo == tempNoToDelete);

                    if (tempRowToDelete != null)
                    {
                        // Delete the row from the database
                        db.appointment_table.Remove(tempRowToDelete);
                        db.SaveChanges();

                        // Refresh the dataGridView2 by re-fetching data from the database
                        var clients = db.appointment_table.ToList();
                        dataGridView2.Rows.Clear();

                        foreach (var client in clients)
                        {
                            dataGridView2.Rows.Add(
                                client.CNo,
                                client.ACName,
                                client.APName,
                                client.APetType,
                                client.APDOB,
                                client.AADate,
                                client.AATime,
                                client.ACComment,
                                client.ARemarks
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

        private void RetrieveAndStoreData()
        {
            try
            {
                var query = from c in db.ClientDashboarD
                            join a in db.appointment_table on c.CNo equals a.CNo
                            select new
                            {
                               
                                c.CNo,
                                a.ARemarks,
                                a.AATime,
                                a.AADate,
                                c.CName
                            };

                // Load the data into a collection
                var data = query.ToList();

                // Assuming you have a DataGridView control named "dataGridView1" on your form
                dataGridView2.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        //private void LoadDataToDataGridView2()
        //{
        //    try
        //    {

        //        var App = db.View_appointment_recs.ToList();



        //// Retrieve data from the ClientDashboard table
        //using (var db = new DBSYSEntities())
        //{
        //    var clients = db.appointment_table.ToList();

        //    // Clear existing columns and rows in dataGridView2
        //    dataGridView2.Columns.Clear();
        //    dataGridView2.Rows.Clear();

        //    // Add columns to dataGridView2
        //    dataGridView2.Columns.Add("ANo", "ANo");
        //    dataGridView2.Columns.Add("ACName", "ACName");
        //    dataGridView2.Columns.Add("APName", "APName");
        //    dataGridView2.Columns.Add("APetType", "APetType");
        //    dataGridView2.Columns.Add("APDOB", "APDOB");
        //    dataGridView2.Columns.Add("AADate", "AADate");
        //    dataGridView2.Columns.Add("AATime", "AATime");
        //    dataGridView2.Columns.Add("ACComment", "ACComment");
        //    dataGridView2.Columns.Add("ARemarks", "ARemarks");
        //    // Add rows to dataGridView2
        //    foreach (var client in clients)
        //    {
        //        dataGridView2.Rows.Add(
        //            client.ANo,
        //            client.ACName,
        //            client.APName,
        //            client.APetType,
        //            client.APDOB,
        //            client.AADate,
        //            client.AATime,
        //            client.ACComment,
        //            client.ARemarks
        //        ) ;
        //    }
        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        var innerException = ex.InnerException;
        //        MessageBox.Show($"Error: {ex.Message}\nInner Exception: {innerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void Approval_Load(object sender, EventArgs e)
        {
            RetrieveAndStoreData();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Admin_Dashboard admin_Dashboard = new Frm_Admin_Dashboard();
            admin_Dashboard.Show();
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
