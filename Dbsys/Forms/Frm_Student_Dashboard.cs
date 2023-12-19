using Dbsys.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dbsys.Forms
{
    public partial class Frm_Student_Dashboard : Form
    {
       

        public Frm_Student_Dashboard()
        {
            InitializeComponent();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
      
       


        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBSYSEntities())
                {
                   
                        var newClient = new ClientDashboarD();



                        //newClient.CNo = Convert.ToInt32(txtCNo.Text);
                        newClient.CName = txtFname.Text;
                        newClient.PName = txtPetName.Text;
                        newClient.PetType = txtTypeofPet.Text;
                        newClient.PDOB = DateTime.Parse(dtpPDOB.Text);
                        newClient.ADate = DateTime.Parse(dtpADate.Text);
                        newClient.ATime = mtbATIMe.Text;
                        newClient.CComment = txtCComment.Text;
                         db.ClientDashboarD.Add(newClient);
                         db.SaveChanges();



                    dataGridView2.DataSource = db.ClientDashboarD
                                           .Where(client => client.CName == txtFname.Text)
                                           .ToList();
                    txtPetName.Clear();
                        txtTypeofPet.Clear();
                        dtpPDOB.Text = DateTime.Now.ToShortDateString();
                        dtpADate.Text= DateTime.Now.ToShortDateString();
                        mtbATIMe.Clear();
                        txtCComment.Clear();

                    Frm_Doctor_DashBoard doctorDashboardForm = new Frm_Doctor_DashBoard(this);
                    doctorDashboardForm.LoadRecentClientData();


                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCNo.Text = dataGridView2[0, e.RowIndex].Value.ToString();
            txtFname.Text = dataGridView2[1, e.RowIndex].Value.ToString();
            txtPetName.Text = dataGridView2[2, e.RowIndex].Value.ToString();
            txtTypeofPet.Text = dataGridView2[3, e.RowIndex].Value.ToString();
            dtpPDOB.Text = dataGridView2[4, e.RowIndex].Value.ToString();
            dtpADate.Text = dataGridView2[5, e.RowIndex].Value.ToString();
            mtbATIMe.Text = dataGridView2[6, e.RowIndex].Value.ToString();
            txtCComment.Text = dataGridView2[7, e.RowIndex].Value.ToString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
       

      
        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                txtCNo.Text = dataGridView2[0, e.RowIndex].Value.ToString();
                txtFname.Text = dataGridView2[1, e.RowIndex].Value.ToString();
                txtPetName.Text = dataGridView2[2, e.RowIndex].Value.ToString();
                txtTypeofPet.Text = dataGridView2[3, e.RowIndex].Value.ToString();
                dtpPDOB.Text = dataGridView2[4, e.RowIndex].Value.ToString();
                dtpADate.Text = dataGridView2[5, e.RowIndex].Value.ToString();
                mtbATIMe.Text = dataGridView2[6, e.RowIndex].Value.ToString();
                txtCComment.Text = dataGridView2[7, e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Student_Dashboard_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView2();



            txtFname.Text = Frm_Login.sendtext;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login frm_Login = new Frm_Login();
            frm_Login.ShowDialog();
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void appointmentStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataToDataGridView2()
        {
            try
            {
                using (var db = new DBSYSEntities())
                {
                    string acName = Frm_Login.sendtext;// Replace txtACName with the appropriate control name

                    var appointments = db.appointment_table.Where(a => a.ACName == acName).ToList();

                    // Clear existing columns
                    dataGridView3.Columns.Clear();

                    // Define columns for the DataGridView
                   // dataGridView3.Columns.Add("ANo", "Appointment No");
                   // dataGridView3.Columns.Add("ACName", "Client Name");
                   // dataGridView3.Columns.Add("APName", "Pet Name");
                   // dataGridView3.Columns.Add("APetType", "Pet Type");
                   // dataGridView3.Columns.Add("APDOB", "Pet DOB");
                    dataGridView3.Columns.Add("AADate", "Appointment Date");
                    dataGridView3.Columns.Add("AATime", "Appointment Time");
                    //dataGridView3.Columns.Add("ACComment", "Comments");
                    dataGridView3.Columns.Add("ARemarks", "Remarks");

                    // Bind the appointments to the DataGridView
                    foreach (var appointment in appointments)
                    {
                        dataGridView3.Rows.Add(
                           // appointment.ANo,
                        //    appointment.ACName,
                         //   appointment.APName,
                        //    appointment.APetType,
                        //    appointment.APDOB,
                            appointment.AADate,
                            appointment.AATime,
                       //     appointment.ACComment,
                            appointment.ARemarks
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void DeleteSelectedRow()
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

                // Remove the row from the DataGridView display
                dataGridView3.Rows.Remove(selectedRow);
            }
        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }
    }
    
}
