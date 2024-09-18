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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Amila Anushan\Desktop\SE.BSc(hons) NSBM\2nd Year\Semester 01\PUSL2021 Computing Group Project\Student Marks Entry System (Group-48)\Student.mdf"";Integrated Security=True;Connect Timeout=30");
        private void fetchdata()
        {
            Con.Open();
            string query = "select * from Students where Student_ID='" + StdIDTb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                stdidlbl.Text = dr["Student_ID"].ToString();
                stdnamelbl.Text = dr["Student_Name"].ToString();
                stdaddlbl.Text = dr["Address"].ToString();
                stdgenlbl.Text = dr["Gender"].ToString();
                emaillbl.Text = dr["Email"].ToString();
                stddoblbl.Text = dr["DOB"].ToString();
                gnamelbl.Text = dr["Guardian_Name"].ToString();
                gphonelbl.Text = dr["Phone"].ToString();
                adddatelbl.Text = dr["Admission_Date"].ToString();
                gradelbl.Text = dr["Grade"].ToString();
                stdidlbl.Visible = true;
                stdnamelbl.Visible = true;
                stdaddlbl.Visible = true;
                stdgenlbl.Visible = true;
                emaillbl.Visible = true;
                stddoblbl.Visible = true;
                gnamelbl.Visible = true;
                gphonelbl.Visible = true;
                adddatelbl.Visible = true;
                gradelbl.Visible = true;

            }
            Con.Close();
        }
        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            fetchdata();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Color textColor = Color.FromArgb(0, 176, 80);
            SolidBrush brush = new SolidBrush(textColor);

            e.Graphics.DrawString("=======STUDENT DETAILS=======", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Green, new Point(180));

            e.Graphics.DrawString("Student ID: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString(stdidlbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 100));

            e.Graphics.DrawString("Student Name: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 140));
            e.Graphics.DrawString(stdnamelbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 140));

            e.Graphics.DrawString("Student Address: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 180));
            e.Graphics.DrawString(stdaddlbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 180));

            e.Graphics.DrawString("Gender: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 220));
            e.Graphics.DrawString(stdgenlbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 220));

            e.Graphics.DrawString("Student Email: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 260));
            e.Graphics.DrawString(emaillbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 260));

            e.Graphics.DrawString("Student DOB: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 300));
            e.Graphics.DrawString(stddoblbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 300));

            e.Graphics.DrawString("Guardian Name: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 340));
            e.Graphics.DrawString(gnamelbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 340));

            e.Graphics.DrawString("Guardian Phone: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 380));
            e.Graphics.DrawString(gphonelbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 380));

            e.Graphics.DrawString("Admission Date: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 420));
            e.Graphics.DrawString(adddatelbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 420));

            e.Graphics.DrawString("Grade: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 460));
            e.Graphics.DrawString(gradelbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 460));

            e.Graphics.DrawString("==========================", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Green, new Point(200, 500));
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void empdoblbl_Click(object sender, EventArgs e)
        {

        }

        private void Empgenlbl_Click(object sender, EventArgs e)
        {

        }

        private void empedulbl_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void empnamelbl_Click(object sender, EventArgs e)
        {

        }

        private void empphonelbl_Click(object sender, EventArgs e)
        {

        }

        private void empposlbl_Click(object sender, EventArgs e)
        {

        }

        private void empaddlbl_Click(object sender, EventArgs e)
        {

        }

        private void Empidlbl_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void StdIDTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
