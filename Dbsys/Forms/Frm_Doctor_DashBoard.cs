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
    public partial class Frm_Doctor_DashBoard : Form
    {
        public int AppointmentID { get; set; }
        public string Status { get; set; }
        public Frm_Doctor_DashBoard()
        {
            InitializeComponent();
        }

        private void Frm_Teacher_DashBoard_Load(object sender, EventArgs e)
        {

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
        // Assuming this code is inside a method or event handler in the Doctor_Dashboard form

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

        private void clientAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView2();
        }
    }
}
