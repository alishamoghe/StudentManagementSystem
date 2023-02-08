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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }else if(UNameTb.Text == "Admin" && PasswordTb.Text == "Password")
            {
                //Students Obj = new Students();
                Dashboard Obj = new Dashboard();
                Obj.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong User Name Or Password!!!");
                UNameTb.Text = "";
                PasswordTb.Text = "";
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Clear()
        {
            UNameTb.Text = "";
            PasswordTb.Text = "";
        }


        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
