using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Dashboard : Form
    {
        Functions Con;
        public Dashboard()
        {
            InitializeComponent();
            Con = new Functions();
            CountStudents();
            CountDepartments();
            CountMale();
        }
        private void CountStudents()
        {
            string Query = "select Count(*) as Stud from StudentTbl";
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                StudNumLbl.Text = dr["Stud"].ToString();
            }
          
        }

        private void CountDepartments()
        {
            string Query = "select Count(*) as Dep from DepartmentTbl";
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                DepNumLbl.Text = dr["Dep"].ToString();
            }
           
        }

        private void CountMale()
        {
           string StGen = "Male";
           string Query = "select Count(*) as Male from StudentTbl where StGen = '{0}'";
           Query = String.Format(Query, StGen);
           foreach (DataRow dr in Con.GetData(Query).Rows)
           {
              MaleStudLbl.Text = dr["Male"].ToString();
           }
          
        }

        private void StudentLbl_Click(object sender, EventArgs e)
        {
            Students Obj = new Students();
            Obj.Show();
            this.Close();
        }

        private void DepLbl_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
