using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLSelectInsertAndUpdate
{
    public partial class FrmUpdateMember : Form 
    {
        private ClubRegistrationQuery clubQuery;
        public long StudentID => Convert.ToInt64(cmbStudentId.SelectedItem);
        public string FirstName => txtFirstName.Text;
        public string MiddleName => txtMiddleName.Text;
        public string LastName => txtLastName.Text;
        public int Age => int.Parse(txtAge.Text);
        public string Gender => cmbGender.Text;
        public string Program => cmbProgram.Text;
        public FrmUpdateMember()
        {
            InitializeComponent();
            clubQuery = new ClubRegistrationQuery();
        }
        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {

            clubQuery = new ClubRegistrationQuery();
            var studentIDs = clubQuery.GetAllStudentIDs();

            cmbStudentId.DataSource = studentIDs;

            if (studentIDs.Count > 0)
                cmbStudentId.SelectedIndex = 0;

            cmbStudentId.SelectionChangeCommitted += cmbStudentId_SelectionChangeCommitted;
        }


        private void cmbStudentId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbStudentId.SelectedItem == null)
                return;

            long selectedID = Convert.ToInt64(cmbStudentId.SelectedItem);
            DataRow member = clubQuery.GetMemberByID(selectedID);

            if (member != null)
            {
                txtFirstName.Text = member["FirstName"].ToString();
                txtMiddleName.Text = member["MiddleName"].ToString();
                txtLastName.Text = member["LastName"].ToString();
                txtAge.Text = member["Age"].ToString();
                cmbGender.Text = member["Gender"].ToString();
                cmbProgram.Text = member["Program"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbStudenId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudentId.SelectedItem == null)
                return;

            long selectedID = Convert.ToInt64(cmbStudentId.SelectedItem);
            DataRow member = clubQuery.GetMemberByID(selectedID);

            if (member != null)
            {
                txtFirstName.Text = member["FirstName"].ToString();
                txtMiddleName.Text = member["MiddleName"].ToString();
                txtLastName.Text = member["LastName"].ToString();
                txtAge.Text = member["Age"].ToString();
                cmbGender.Text = member["Gender"].ToString();
                cmbProgram.Text = member["Program"].ToString();
            }


        }

        public void RefreshStudentIds()
        {
            var studentIDs = clubQuery.GetAllStudentIDs();
            cmbStudentId.DataSource = null;
            cmbStudentId.DataSource = studentIDs;
            if (studentIDs.Count > 0)
                cmbStudentId.SelectedIndex = 0;
        }

    }
}
