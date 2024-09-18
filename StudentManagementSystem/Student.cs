using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace StudentManagementSystem
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Amila Anushan\Desktop\SE.BSc(hons) NSBM\2nd Year\Semester 01\PUSL2021 Computing Group Project\Student Marks Entry System (Group-48)\Student.mdf"";Integrated Security=True;Connect Timeout=30");
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(StdIdTb.Text == "" || StdNameTb.Text == "" || StdAddTb.Text == "" || StdDob.Value.ToString() == ""||StdEmailTb.Text==""|| GNameTb.Text=="" || GPhoneNum.Text==""|| AddDate.Value.Date.ToString()=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Students values('"+StdIdTb.Text+"','"+StdNameTb.Text+"','"+StdAddTb.Text+"','"+StdGenCb.SelectedItem.ToString()+"','"+StdEmailTb.Text+"','"+StdDob.Text+"','"+GNameTb.Text+"','"+GPhoneNum.Text+"','"+AddDate.Text+"', '"+GradeTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Successfully Added");
                    Con.Close();
                    populate();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
private void populate()
        {
            Con.Open();
            string query = "select * from Students";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StdDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(StdIdTb.Text == "")
            {
                MessageBox.Show("Enter The Student Id");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Student?","Delete Student",MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Con.Open();
                        string query = "delete from Students where Student_ID='" + StdIdTb.Text + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student Deleted Successfully","Record Deleted",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Con.Close();
                        populate();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StdIdTb.Text = StdDGV.SelectedRows[0].Cells[0].Value.ToString();
            StdNameTb.Text = StdDGV.SelectedRows[0].Cells[1].Value.ToString();
            StdAddTb.Text = StdDGV.SelectedRows[0].Cells[2].Value.ToString();
            StdGenCb.Text = StdDGV.SelectedRows[0].Cells[3].Value.ToString();
            StdEmailTb.Text = StdDGV.SelectedRows[0].Cells[4].Value.ToString();   
            StdDob.Text = StdDGV.SelectedRows[0].Cells[5].Value.ToString();
            GNameTb.Text = StdDGV.SelectedRows[0].Cells[6].Value.ToString();
            GPhoneNum.Text = StdDGV.SelectedRows[0].Cells[7].Value.ToString();
            AddDate.Text= StdDGV.SelectedRows[0].Cells[8].Value.ToString();
            GradeTb.Text =StdDGV.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (StdIdTb.Text == "" || StdNameTb.Text == "" || StdAddTb.Text == "" || StdDob.Value.ToString() == "" || StdEmailTb.Text == "" || GNameTb.Text == "" || GPhoneNum.Text == "" || AddDate.Value.Date.ToString() == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Students set Student_Name='" + StdNameTb.Text + "',Address='" + StdAddTb.Text + "',Gender='" + StdGenCb.SelectedItem.ToString()+ "',Email='" + StdEmailTb.Text+ "',DOB='" + StdDob.Text+ "',Guardian_Name='" + GNameTb.Text+ "',Phone='" + GPhoneNum.Text+ "', Admission_Date='"+AddDate.Text+ "', Grade='"+GradeTb.Text+ "' where Student_ID='" + StdIdTb.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Updated Successfully");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
