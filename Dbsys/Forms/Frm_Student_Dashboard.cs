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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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



                        newClient.CNo = Convert.ToInt32(txtCNo.Text);
                        newClient.CName = txtFname.Text;
                        newClient.PName = txtPetName.Text;
                        newClient.PetType = txtTypeofPet.Text;
                        newClient.PDOB = DateTime.Parse(dtpPDOB.Text);
                        newClient.ADate = DateTime.Parse(dtpADate.Text);
                        newClient.ATime = mtbATIMe.Text;
                        newClient.CComment = txtCComment.Text;
                         db.ClientDashboarD.Add(newClient);
                         db.SaveChanges();

                     //Add the new client to the database
                    dataGridView1.Columns.Clear();

                        // Add columns to dataGridView1
                        dataGridView1.Columns.Add("CNo", "CNo");
                        dataGridView1.Columns.Add("CName", "CName");
                        dataGridView1.Columns.Add("PName", "PName");
                        dataGridView1.Columns.Add("PetType", "PetType");
                        dataGridView1.Columns.Add("PDOB", "PDOB");
                        dataGridView1.Columns.Add("ADate", "ADate");
                        dataGridView1.Columns.Add("ATime", "ATime");
                        dataGridView1.Columns.Add("CComment", "CComment");

                        // Add the "Delete" column as a DataGridViewButtonColumn
                        DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                        deleteColumn.Name = "Appoint";
                        deleteColumn.HeaderText = "Appoint";
                        deleteColumn.Text = "Appoint";
                        deleteColumn.DefaultCellStyle.ForeColor = Color.Black; 
                        deleteColumn.DefaultCellStyle.BackColor = Color.GreenYellow; 
                        deleteColumn.FlatStyle = FlatStyle.Popup; 
                        deleteColumn.UseColumnTextForButtonValue = true;
                       
                        dataGridView1.Columns.Add(deleteColumn);

                        dataGridView1.Rows.Add(newClient.CNo, newClient.CName, newClient.PName, newClient.PetType, newClient.PDOB, newClient.ADate, newClient.ATime, newClient.CComment, "Appoint");
                        

                    string sqlInsertCommand = "INSERT INTO ClientDashboarD(CNo,CName,PName,PetType,PDOB,ADate,ATime,CComment) VALUES (@CNo, @CName, @PName, @PetType, @PDOB, @ADate, @ATime, @CComment)";
                        //string targetCName = newClient.CName; // Get the inputted CName from the textbox
                        //string sqlSelectCommand = "SELECT CNo, CName, PName, PetType, PDOB, ADate, ATime, CComment INTO #TempTable FROM ClientDashboarD";



                        dataGridView2.DataSource = db.ClientDashboarD.ToList();
                        txtPetName.Clear();
                        txtTypeofPet.Clear();
                        dtpPDOB.Text = DateTime.Now.ToShortDateString();
                        dtpADate.Text= DateTime.Now.ToShortDateString();
                        mtbATIMe.Clear();
                        txtCComment.Clear();


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
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Appoint"].Index && e.RowIndex >= 0)
                {
                    // Get the CNo value of the client to be deleted
                    int cNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CNo"].Value);

                    // Delete the client from the database
                    using (var db = new DBSYSEntities())
                    {
                        var clientToDelete = db.ClientDashboarD.FirstOrDefault(c => c.CNo == cNo);
                        if (clientToDelete != null)
                        {
                            db.ClientDashboarD.Remove(clientToDelete);
                            db.SaveChanges();
                        }
                    }

                    // Remove the row from dataGridView1
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

      
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                    // Get the primary key or unique identifier of the selected row
                    int clientId = Convert.ToInt32(selectedRow.Cells["CNo"].Value);

                    // Delete the corresponding record from the database
                    using (var db = new DBSYSEntities())
                    {
                        var clientToDelete = db.ClientDashboarD.FirstOrDefault(c => c.CNo == clientId);
                        if (clientToDelete != null)
                        {
                            db.ClientDashboarD.Remove(clientToDelete);
                            db.SaveChanges();

                            // Rebind the DataGridView to the updated data source
                            dataGridView2.DataSource = db.ClientDashboarD.ToList();
                        }
                        else
                        {
                            // Handle the case where the record is not found in the database
                            MessageBox.Show("Record not found in the database.");
                        }
                    }
                }
                else
                {
                    // Inform the user that no row is selected
                    MessageBox.Show("No row selected.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Student_Dashboard_Load(object sender, EventArgs e)
        {
            // Assuming you load your data from the database on form load
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
                //using (var db = new DBSYSEntities())
                //{
                //    var newAppointment = new appointment_table();

                //    newAppointment.ANo = Convert.ToInt32(txtCNo.Text);
                //    newAppointment.ACName = txtFname.Text;
                //    newAppointment.APName = txtPetName.Text;
                //    newAppointment.APetType = txtTypeofPet.Text;
                //    newAppointment.APDOB = DateTime.Parse(dtpPDOB.Text);
                //    newAppointment.AADate = DateTime.Parse(dtpADate.Text);
                //    newAppointment.AATime = mtbATIMe.Text;
                //    newAppointment.ACComment = txtCComment.Text;

                //    db.appointment_table.Add(newAppointment);
                //    db.SaveChanges();

                //    // Refresh dataGridView2 with the updated data

                //    dataGridView1.Columns.Clear();

                //    // Add columns to dataGridView1
                //    dataGridView1.Columns.Add("ANo", "ANo");
                //    dataGridView1.Columns.Add("ACName", "ACName");
                //    dataGridView1.Columns.Add("APName", "APName");
                //    dataGridView1.Columns.Add("APetType", "APetType");
                //    dataGridView1.Columns.Add("APDOB", "APDOB");
                //    dataGridView1.Columns.Add("AADate", "AADate");
                //    dataGridView1.Columns.Add("AATime", "AATime");
                //    dataGridView1.Columns.Add("ACComment", "ACComment");

                //    // Add the "Delete" column as a DataGridViewButtonColumn
                //    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                //    deleteColumn.Name = "Appoint";
                //    deleteColumn.HeaderText = "Appoint";
                //    deleteColumn.Text = "Appoint";
                //    deleteColumn.DefaultCellStyle.ForeColor = Color.Black;
                //    deleteColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
                //    deleteColumn.FlatStyle = FlatStyle.Popup;
                //    deleteColumn.UseColumnTextForButtonValue = true;
                //    dataGridView1.Columns.Add(deleteColumn);
                //    string sqlInsertCommand = "INSERT INTO appointment_table(ANo,ACName,APName,APetType,APDOB,AADate,AATime,ACComment) VALUES (@ANo, @ACName, @APName, @APetType, @APDOB, @AADate, @AATime, @ACComment)";

                //    dataGridView1.Rows.Add(newAppointment.ANo, newAppointment.ACName, newAppointment.APName, newAppointment.APetType, newAppointment.APDOB, newAppointment.AADate, newAppointment.AATime, newAppointment.ACComment, "Appoint");

                //    db.Database.ExecuteSqlCommand(sqlInsertCommand,
                //    new SqlParameter("@ANo", newAppointment.ANo),
                //    new SqlParameter("@ACName", newAppointment.ACName),
                //    new SqlParameter("@APName", newAppointment.APName),
                //    new SqlParameter("@APetType", newAppointment.APetType),
                //    new SqlParameter("@APDOB", newAppointment.APDOB),
                //    new SqlParameter("@AADate", newAppointment.AADate),
                //    new SqlParameter("@AATime", newAppointment.AATime),
                //    new SqlParameter("@ACComment", newAppointment.ACComment));

                //    dataGridView1.DataSource = db.appointment_table.ToList();
                //    // Clear input fields
                //    // dataGridView1.DataSource = db.appointment_table.ToList();
                //    txtPetName.Clear();
                //    txtTypeofPet.Clear();
                //    dtpPDOB.Text = DateTime.Now.ToShortDateString();
                //    dtpADate.Text = DateTime.Now.ToShortDateString();
                //    mtbATIMe.Clear();
                //    txtCComment.Clear();
                //}
        //        using (var db = new DBSYSEntities())
        //        {
        //            var newAppointment = new appointment_table();

        //            newAppointment.ANo = Convert.ToInt32(txtCNo.Text);
        //            newAppointment.ACName = txtFname.Text;
        //            newAppointment.APName = txtPetName.Text;
        //            newAppointment.APetType = txtTypeofPet.Text;
        //            newAppointment.APDOB = DateTime.Parse(dtpPDOB.Text);
        //            newAppointment.AADate = DateTime.Parse(dtpADate.Text);
        //            newAppointment.AATime = mtbATIMe.Text;
        //            newAppointment.ACComment = txtCComment.Text;

        //            db.appointment_table.Add(newAppointment);
        //            db.SaveChanges();

        //            // Refresh dataGridView1 with the updated data
        //            dataGridView1.DataSource = db.appointment_table.ToList();

        //            // Clear input fields
        //            txtPetName.Clear();
        //            txtTypeofPet.Clear();
        //            dtpPDOB.Text = DateTime.Now.ToShortDateString();
        //            dtpADate.Text = DateTime.Now.ToShortDateString();
        //            mtbATIMe.Clear();
        //            txtCComment.Clear();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }
    }
}
