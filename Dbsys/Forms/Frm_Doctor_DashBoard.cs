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
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.ComponentModel;


namespace Dbsys.Forms
{
    public partial class Frm_Doctor_DashBoard : Form
    {
        


        public Frm_Doctor_DashBoard(Frm_Student_Dashboard clientDashboardForm)
        {
            InitializeComponent();
            //LoadClientData();
            LoadRecentClientData();
            LoadDataToDataGridView2();

        }

        private void Frm_Teacher_DashBoard_Load(object sender, EventArgs e)
        {
            //if (clientData != null)
            //{
            //    clientData.Clear(); // Clear the data from the clientData object if it's not null
            //}
            //else
            //{
            //    clientData = new BindingList<ClientDashboarD>(); // Initialize the clientData object if it's null
            //}

            ////LoadDataToDataGridView2();
            //LoadClientData();
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
                    dataGridView2.Columns.Add("CNo", "Number");
                    dataGridView2.Columns.Add("CName", "Name");
                    dataGridView2.Columns.Add("PName", "Pet Name");
                    dataGridView2.Columns.Add("PetType", "Pet Type");
                    dataGridView2.Columns.Add("PDOB", "Pet DOB");
                    dataGridView2.Columns.Add("ADate", "Date");
                    dataGridView2.Columns.Add("ATime", "Time");
                    dataGridView2.Columns.Add("CComment", "Comment");

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
        public void LoadRecentClientData()
        {
            using (var db = new DBSYSEntities())
            {
                var recentClient = db.ClientDashboarD
                    .OrderByDescending(client => client.CNo)
                    .FirstOrDefault();

                if (recentClient != null)
                {
                    dataGridView2.DataSource = new List<ClientDashboarD> { recentClient };
                }
                else
                {
                    dataGridView2.DataSource = null;
                }
            }
        }
        private void clientAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

           

        }
       

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtANo.Text = dataGridView2[0, e.RowIndex].Value.ToString();
                txtAFname.Text = dataGridView2[1, e.RowIndex].Value.ToString();
                txtAPetName.Text = dataGridView2[2, e.RowIndex].Value.ToString();
                txtATypeofPet.Text = dataGridView2[3, e.RowIndex].Value.ToString();
                txtdob.Text = dataGridView2[4, e.RowIndex].Value.ToString();
                txtADate.Text = dataGridView2[5, e.RowIndex].Value.ToString();
                mtbAATIMe.Text = dataGridView2[6, e.RowIndex].Value.ToString();
                txtACComment.Text = dataGridView2[7, e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void logourtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login frm_Login = new Frm_Login();
            frm_Login.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBSYSEntities())
                {

                    var newApp = new appointment_table();



                    newApp.CNo = Convert.ToInt32(txtANo.Text);
                    newApp.ACName = txtAFname.Text;
                    newApp.APName = txtAPetName.Text;
                    newApp.APetType = txtATypeofPet.Text;
                    newApp.APDOB = txtdob.Text;
                    newApp.AADate = txtADate.Text;
                    newApp.AATime = mtbAATIMe.Text;
                    newApp.ACComment = txtACComment.Text;
                    newApp.ARemarks = txtARemarks.Text;
                    db.appointment_table.Add(newApp);
                    db.SaveChanges();

                    //Add the new client to the database
                    dataGridView1.Columns.Clear();

                    // Add columns to dataGridView1
                   

                   


                   


                    dataGridView1.DataSource = db.appointment_table.ToList();
                    txtAPetName.Clear();
                    txtATypeofPet.Clear();
                    txtdob.Clear();
                    txtADate.Clear();
                    mtbAATIMe.Clear();
                    txtACComment.Clear();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void DeleteSelectedRow()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                // Remove the row from the DataGridView display
                dataGridView2.Rows.Remove(selectedRow);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void Frm_Doctor_DashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
           

        }
    }
}
