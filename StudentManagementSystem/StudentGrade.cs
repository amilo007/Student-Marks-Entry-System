using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class StudentGrade : Form
    {
        public StudentGrade()
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
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                stdidlbl.Text = dr["Student_ID"].ToString();
                stdnamelbl.Text = dr["Student_Name"].ToString();
                stdidlbl.Visible = true;
                stdnamelbl.Visible = true;
            }
            else
            {
                stdidlbl.Text = "";
                stdnamelbl.Text = "";
                stdidlbl.Visible = true;
                stdnamelbl.Visible = true;
            }
            Con.Close();
        }

        private void fetchmarkdata()
        {
            Con.Open();
            string query = "select * from Marks where Student_ID='" + StdIDTb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stdidlbl.Text = dr["Student_ID"].ToString();
                stdnamelbl.Text = dr["Student_Name"].ToString();
                smark.Text = dr["Sinhala"].ToString();
                emark.Text = dr["English"].ToString();
                mmark.Text = dr["Mathematics"].ToString();
                simark.Text = dr["Science"].ToString();
                hmark.Text = dr["History"].ToString();
                bmark.Text = dr["Buddhism"].ToString();
                ictmark.Text = dr["ICT"].ToString();
                gmark.Text = dr["Geography"].ToString();
                amark.Text = dr["Art"].ToString();
                stdidlbl.Visible = true;
                stdnamelbl.Visible = true;

            }
            Con.Close();
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (StdIDTb.Text == "") {
            
                stdidlbl.Visible=false;
                stdnamelbl.Visible=false;
                smark.Text = "";
                emark.Text = "";
                mmark.Text = "";
                simark.Text = "";
                hmark.Text = "";
                bmark.Text = "";
                ictmark.Text = "";
                gmark.Text = "";
                amark.Text = "";

            }
            else
            {
                fetchmarkdata();
            }
          
        }

        private void label11_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (smark.Text == "" || emark.Text == "" || mmark.Text == "" || simark.Text == "" || hmark.Text == "" || bmark.Text == "" || ictmark.Text == "" || gmark.Text == "" || amark.Text=="")
            {
                MessageBox.Show("Missing Student Marks");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Marks values('" + stdidlbl.Text + "','" + stdnamelbl.Text + "','" + smark.Text + "','" + emark.Text + "','" + mmark.Text + "','" + simark.Text + "','" + hmark.Text + "','" + bmark.Text + "','" + ictmark.Text + "', '" + gmark.Text + "', '"+amark.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Marks Successfully Added");
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void StdIDTb_OnValueChanged(object sender, EventArgs e)
        {
            fetchdata();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (smark.Text == "" || emark.Text == "" || mmark.Text == "" || simark.Text == "" || hmark.Text == "" || bmark.Text == "" || ictmark.Text == "" || gmark.Text == "" || amark.Text == "")
            {
                MessageBox.Show("Missing Student Marks");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Marks set Sinhala='" + smark.Text + "',English='" + emark.Text + "',Mathematics='" + mmark.Text + "',Science='" + simark.Text + "',History='" + hmark.Text + "',Buddhism='" + bmark.Text + "',ICT='" + ictmark.Text + "', Geography='" + gmark.Text + "', Art='" + amark.Text + "' where Student_ID='" + stdidlbl.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Marks Updated Successfully");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            if (StdIDTb.Text == "")
            {
                MessageBox.Show("Enter The Student Id");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Student Marks?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Con.Open();
                        string query = "delete from Marks where Student_ID='" + StdIDTb.Text + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student Marks Deleted Successfully", "Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Con.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }

                    StdIDTb.Text = "";
                    stdidlbl.Visible = false;
                    stdnamelbl.Visible = false;
                    smark.Text = "";
                    emark.Text = "";
                    mmark.Text = "";
                    simark.Text = "";
                    hmark.Text = "";
                    bmark.Text = "";
                    ictmark.Text = "";
                    gmark.Text = "";
                    amark.Text = "";
                }
            }
        }

        private void StudentGrade_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Color textColor = Color.FromArgb(0, 176, 80);
            SolidBrush brush = new SolidBrush(textColor);

            e.Graphics.DrawString("=======STUDENT MARKS=======", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Green, new Point(180));

            e.Graphics.DrawString("Student ID: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString(stdidlbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 100));

            e.Graphics.DrawString("Student Name: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 140));
            e.Graphics.DrawString(stdnamelbl.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 140));

            e.Graphics.DrawString("Sinhala: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 180));
            e.Graphics.DrawString(smark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 180));

            e.Graphics.DrawString("English: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 220));
            e.Graphics.DrawString(emark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 220));

            e.Graphics.DrawString("Mathematics: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 260));
            e.Graphics.DrawString(mmark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 260));

            e.Graphics.DrawString("Science: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 300));
            e.Graphics.DrawString(simark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 300));

            e.Graphics.DrawString("History: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 340));
            e.Graphics.DrawString(hmark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 340));

            e.Graphics.DrawString("Buddhism: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 380));
            e.Graphics.DrawString(bmark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 380));

            e.Graphics.DrawString("ICT: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 420));
            e.Graphics.DrawString(ictmark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 420));

            e.Graphics.DrawString("Geography: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 460));
            e.Graphics.DrawString(gmark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 460));

            e.Graphics.DrawString("Art: ", new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(10, 500));
            e.Graphics.DrawString(amark.Text, new Font("Century Gothic", 18, FontStyle.Regular), brush, new Point(230, 500));

            e.Graphics.DrawString("==========================", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Green, new Point(200, 540));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
