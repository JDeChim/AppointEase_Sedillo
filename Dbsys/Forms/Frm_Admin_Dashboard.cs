using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dbsys.AppData;

namespace Dbsys.Forms
{
    public partial class Frm_Admin_Dashboard : Form
    {
        UserRepository userRepo;
        public Frm_Admin_Dashboard()
        {
            InitializeComponent();
            //
            userRepo = new UserRepository();
        }

        private void Frm_Admin_Dashboard_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = userRepo.AllUserRole();
            toolStripStatusUser.Text = UserLogged.GetInstance().UserAccount.userName;
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new Frm_UserEntry())
            { 
                frm.ShowDialog();
            }
        }
       

        private void clientAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientApp Cp = new ClientApp();
            Cp.ShowDialog();
            this.Close();
            
        }

        private void approvalHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Approval ap = new Approval();
            ap.ShowDialog();
            this.Close();
        }
    }
}
