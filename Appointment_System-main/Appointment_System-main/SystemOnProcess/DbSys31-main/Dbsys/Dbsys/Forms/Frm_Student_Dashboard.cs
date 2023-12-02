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
                    var NewClient = new ClientDashboarD();

                    NewClient.CNo = Convert.ToInt32(txtCNo.Text);
                    NewClient.CName = txtFname.Text;
                    NewClient.PName = txtPetName.Text;
                    NewClient.PetType = txtTypeofPet.Text;
                    NewClient.PDOB = dtpPDOB.Text;
                    NewClient.ADate = dtpADate.Text;
                    NewClient.ATime = mtbATIMe.Text;
                    NewClient.CComment = txtCComment.Text;

                    db.ClientDashboarD.Add(NewClient);
                    db.SaveChanges();
                    string sqlInsertCommand = "INSERT INTO ClientDashboarD(CNo,CName,PName,PetType,PDOB,ADate,ATime,CComment) VALUES (@CNo, @CName, @PName, @PetType, @PDOB, @ADate, @ATime, @CComment)";
                    dataGridView1.DataSource = db.ClientDashboarD.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
