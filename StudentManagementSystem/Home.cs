﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Student emp = new Student();
            emp.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Student emp = new Student();
            emp.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if(dialogResult == DialogResult.Yes)
            {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.Yes)
            {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ViewStudent Vemp = new ViewStudent();
            Vemp.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            StudentGrade stdg = new StudentGrade();
            stdg.Show();
            this.Hide();

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

            ViewStudent Vemp = new ViewStudent();
            Vemp.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            StudentGrade stdg = new StudentGrade();
            stdg.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
