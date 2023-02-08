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
    public partial class Students : Form
    {
        Functions Con;

        public Students()
        {
            InitializeComponent();
            Con = new Functions();
            ShowStudents();
            GetDepartment();
        }

        private void ShowStudents()
        {
            string Query = "select * from StudentTbl";
            StudentsList.DataSource = Con.GetData(Query);
        }

        private void GetDepartment()
        {
            string Query = "select * from DepartmentTbl";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            StNameTb.Text = "";
            GenCb.SelectedIndex = -1;
            StPhoneTb.Text = "";
            StParentTb.Text = "";
            StAddTb.Text = "";
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {

            if (StNameTb.Text == " " || GenCb.SelectedIndex == -1 || StPhoneTb.Text == " " || StParentTb.Text == " " || StAddTb.Text == " " || DepCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string StName = StNameTb.Text;
                    string StGen = GenCb.SelectedItem.ToString();
                    string StPhone = StPhoneTb.Text;
                    string StParent = StParentTb.Text;
                    string StAdd = StAddTb.Text;
                    int StDepartment = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "insert into StudentTbl values('{0}','{1}', '{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, StName, StGen, StPhone,StParent,StAdd, StDepartment);
                    Con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Added!!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void StudentsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // MessageBox.Show(DepartmentsList);

            StNameTb.Text = StudentsList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = StudentsList.SelectedRows[0].Cells[2].Value.ToString();
            StPhoneTb.Text = StudentsList.SelectedRows[0].Cells[3].Value.ToString();
            StParentTb.Text = StudentsList.SelectedRows[0].Cells[4].Value.ToString();
            StAddTb.Text = StudentsList.SelectedRows[0].Cells[5].Value.ToString();
            DepCb.SelectedValue = StudentsList.SelectedRows[0].Cells[6].Value.ToString();

            if (StNameTb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(StudentsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == " " || GenCb.SelectedIndex == -1 || StPhoneTb.Text == " " || StParentTb.Text == " " || StAddTb.Text == " " || DepCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string StName = StNameTb.Text;
                    string StGen = GenCb.SelectedItem.ToString();
                    string StPhone = StPhoneTb.Text;
                    string StParent = StParentTb.Text;
                    string StAdd = StAddTb.Text;
                    int StDepartment = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "update StudentTbl set StName = '{0}', StGen = '{1}', StPhone = '{2}', StParent = '{3}', StAdd = '{4}', StDepartment = {5} where StCode = {6}";
                    Query = string.Format(Query, StName, StGen, StPhone, StParent, StAdd, StDepartment,Key);
                    Con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Updated!!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string StName = StNameTb.Text;
                    string StGen = GenCb.SelectedItem.ToString();
                    string StPhone = StPhoneTb.Text;
                    string StParent = StParentTb.Text;
                    string StAdd = StAddTb.Text;
                    int StDepartment = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "delete from StudentTbl where StCode = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Deleted!!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DepLbl_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }

        private void DashboardLbl_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Close();
        }

        private void Logout_Paint(object sender, PaintEventArgs e)
        {
           
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
