using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToXML;

namespace ToXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var xmlConfigurations = new XmlConfiguration();
                bool flag = false;
                var studentList = xmlConfigurations.GetConfigurations();

                var student = studentList.Student.Where(w => w.FirstName == txtfirstname.Text).FirstOrDefault();

                if (student == null)
                {
                    student = new Student { College = new List<College>() };
                    flag = true;
                }

                student.FirstName = txtfirstname.Text;
                student.LastName = txtlastname.Text;
                student.Age = txtage.Text;

                student.College.Add(new College() { CollegeName = txtclgname.Text, Branch = txtbranch.Text, IdNumber = txtID.Text, Stream = txtclgstream.Text });

                if (flag)
                    studentList.Student.Add(student);

                xmlConfigurations.saveConfig(studentList);
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BindGrid()
        {
            try
            {
                var xmlConfigurations = new XmlConfiguration();

                var studentList = xmlConfigurations.GetConfigurations();

                var GridDataSource = new List<Datadridview>();
                foreach (var student in studentList.Student)
                {
                    foreach (var college in student.College)
                    {
                        GridDataSource.Add(new Datadridview { Firstname = student.FirstName, Lastname = student.LastName, Age = student.Age, Branch = college.Branch, Collegename = college.CollegeName, Idnumber = college.IdNumber,Stream=college.Stream });
                    }
                }

                dataGridView.DataSource = GridDataSource;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
