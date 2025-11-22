using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SQLSelectInsertAndUpdate
{
    public partial class Form1 : Form
    {
        ClubRegistrationQuery query = new ClubRegistrationQuery();
        public Form1()
        {
            InitializeComponent();


            query = new ClubRegistrationQuery();
            clubRegistrationQuery = new ClubRegistrationQuery();


            query.DisplayList();
            dataGridView1.DataSource = query.bindingSource;
        }


        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;


        private void button2_Click(object sender, EventArgs e)
        {
            using (FrmUpdateMember frmUpdateMember = new FrmUpdateMember())
            {
                if (frmUpdateMember.ShowDialog() == DialogResult.OK)
                {
                    query.UpdateStudent(
                        frmUpdateMember.StudentID,
                        frmUpdateMember.FirstName,
                        frmUpdateMember.MiddleName,
                        frmUpdateMember.LastName,
                        frmUpdateMember.Age,
                        frmUpdateMember.Gender,
                        frmUpdateMember.Program
                    );

                    MessageBox.Show("Update successful!");
                }
            }
        }

        private void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtStudentId.Text, out StudentId))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }

            if (clubRegistrationQuery.StudentIdExists(StudentId))
            {
                MessageBox.Show("This Student ID already exists. Please enter a unique Student ID.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out Age))
            {
                MessageBox.Show("Please enter a valid Age.");
                return;
            }

            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;
            Gender = cmbGender.SelectedItem?.ToString();
            Program = cmbProgram.SelectedItem?.ToString();

            bool result = clubRegistrationQuery.RegisterStudent(0, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);

            MessageBox.Show("Student registered successfully!");
            RefreshListOfClubMembers();
        }
    }
}
