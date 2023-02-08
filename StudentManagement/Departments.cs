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
    public partial class Departments : Form
    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments();
        }

        private void ShowDepartments()
        {
            string Query = "select * from DepartmentTbl";
            DepartmentsList.DataSource = Con.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(DepNameTb.Text == " " || DetailsTb.Text == " ")
            {
                MessageBox.Show("Missing Data!!");
            }else
            {
                 try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "insert into DepartmentTbl values('{0}','{1}')";
                    Query = string.Format(Query, DName, Details);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added!!!");
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void DepartmentsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(DepartmentsList);

            DepNameTb.Text = DepartmentsList.SelectedRows[0].Cells[1].Value.ToString();
            DetailsTb.Text = DepartmentsList.SelectedRows[0].Cells[2].Value.ToString();
            if (DepNameTb.Text == " ")
            {
               Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DepartmentsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text == " " || DetailsTb.Text == " ")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "update DepartmentTbl set DepName = '{0}',DepDetails = '{1}' where DepId = {2}";
                    Query = string.Format(Query, DName, Details, Key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Updated!!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Clear()
        {
            DepNameTb.Text = "";
            DetailsTb.Text = "";
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Department!!");
            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "delete from DepartmentTbl where DepId = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Deleted!!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }

        private void StudentsLbl_Click(object sender, EventArgs e)
        {
            Students Obj = new Students();
            Obj.Show();
            this.Close();
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
