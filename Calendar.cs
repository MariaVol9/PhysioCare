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

namespace Diploma_Final
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            label6.Text = "-";
            label6.ForeColor = Color.Green;
            label6.Font= new Font("Verdana", 40, FontStyle.Bold);
            label7.Text = "-";
            label7.ForeColor = Color.Blue;
            label7.Font = new Font("Verdana", 40, FontStyle.Bold);
            label8.Text = "-";
            label8.ForeColor = Color.Red;
            label8.Font = new Font("Verdana", 40, FontStyle.Bold);
            label9.Text = "Appointment start";
            label10.Text = "Appointment end";
            label11.Text = "Appointment intersection";
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select * from physiotherapists ";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
              
                    comboBox1.Items.Add(mySqlDataReader[0].ToString());


            mySqlDataReader.Close();
            mySqlConnection.Close();


            Class1 c4 = new Class1();

            DateTime c = DateTime.Today;
            c4.Week(dataGridView1, c);
            listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_DoubleClick);
            radioButton1.Checked = true;
            radioButton4.Checked = true;
           
        }
        Class1 c4 = new Class1();
        DateTime startDate = new DateTime();
        DateTime startDate2 = new DateTime();
        DateTime startDate7 = new DateTime();
        string startDate5 = "";
        string startDate4 = "";
        string startDate3 = "";
        string startDate8 = "";
        int day9 = 0;
        int day8 = 0;
        int dayindex = 0;
        int flag = 0;
        DateTime date2 = DateTime.Today;
        string value1 = "";
        string value2 = "";
        int passport1;
        DateTime date1 = new DateTime();

        private void Button1_Click(object sender, EventArgs e)
        {
            startDate = monthCalendar1.SelectionRange.Start.Date;
            startDate4 = startDate.ToString("yyyy-MM-dd");
            startDate3 = startDate.ToShortDateString();
            textBox1.Text = startDate4;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            c4.Calendar(dataGridView1, startDate, startDate2, startDate7, startDate5, startDate8, dayindex, day9, flag, comboBox1);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            date2 = date2.AddDays(-7);
            c4.Week(dataGridView1, date2);
            startDate = startDate.AddDays(-7);
            c4.Calendar(dataGridView1, startDate, startDate2, startDate7, startDate5, startDate8, dayindex, day9, flag, comboBox1);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            date2 = date2.AddDays(7);
            c4.Week(dataGridView1, date2);
            startDate = startDate.AddDays(7);
            c4.Calendar(dataGridView1, startDate, startDate2, startDate7, startDate5, startDate8, dayindex, day9, flag, comboBox1);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DateTime date3 = DateTime.Today;
            startDate = date3;
            c4.Calendar(dataGridView1, startDate, startDate2, startDate7, startDate5, startDate8, dayindex, day9, flag, comboBox1);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int n = 0;
            string value3 = "";
            string value4 = "";
            string value5 = "";
            string value7 = "";
            DateTime date4 = new DateTime();
            DateTime date5 = new DateTime();
            DateTime date7 = new DateTime();
            string type = "";
            int t, y = 0;
            for (t = 1; t < 51; t++)
            {
                for (y = 1; y < 8; y++)
                {
                    if (dataGridView1.Rows[t].Cells[y].Selected == true)
                    {
                        value3 = dataGridView1.Rows[0].Cells[y].Value.ToString();
                        date4 = DateTime.Parse(value3);
                        value3 = date4.ToString("yyyy-MM-dd");

                        value4 = dataGridView1.Rows[t].Cells[0].Value.ToString();
                       date7 = DateTime.Parse(value4);
                        value4 = date7.ToString("hh:mm:ss");
                    }
                }
            }
         
            if (radioButton4.Checked == true)
            {
                type = "clinic";
                date5 = DateTime.Parse(value4).AddMinutes(30);
                value5 = date5.ToString("hh:mm:ss");
            }
            if (radioButton5.Checked == true)
            {
                type = "private";
                date5 = DateTime.Parse(value4).AddMinutes(45);
                value5 = date5.ToString("hh:mm:ss");

            }
            label2.Text = passport1 + " " + date4.ToShortDateString() + " " + " " + value4 + " " + "value5" + " " + type;
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "INSERT INTO  appointments Values(" + passport1 + ",'" +value3 + "','" + value4 + "','"+value5+"','"+ comboBox1.SelectedItem.ToString() + "','"+type+"')";

            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show(n.ToString() + " row was inserted");
            mySqlConnection.Close();

        }
        private void listBox1_DoubleClick(object sender, MouseEventArgs e)
        {
            foreach (var listBoxItem in listBox1.SelectedItems)

            {
                value1 = listBoxItem.ToString();
                value2 = value1.Substring(0, value1.IndexOf("-"));
                passport1 = int.Parse(value2);
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            c4.Search(listBox1, textBox2, radioButton1, radioButton2, radioButton3);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int pass = 0;
        string dateapps3 = "";
        private void Button7_Click(object sender, EventArgs e)
        {
            string tt = "";
            listBox2.Items.Clear();
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
            string dateapps="";
           // string dateapps = date1.ToString("yyyy-MM-dd");
            string dateapps2 = "";
            
            int t, y = 0;
            for (t = 1; t < 51; t++)
            {
                for (y = 1; y < 8; y++)
                {
                    if (dataGridView1.Rows[t].Cells[y].Selected == true)
                    {
                        dateapps = dataGridView1.Rows[0].Cells[y].Value.ToString();
                        date1 = DateTime.Parse(dateapps);
                        dateapps = date1.ToString("yyyy-MM-dd");
                         dateapps3 = dateapps;
                        mySqlCommand.CommandText = " Select * from appointments where date='" + dateapps + "' and physiotherapist='"+comboBox1.SelectedItem.ToString()+"' ";
                        mySqlConnection.Open();
                       
                        SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                       
                       
                        while (mySqlDataReader.Read())
                        {
                            dateapps2 = mySqlDataReader[0].ToString();
                            pass = int.Parse(dateapps2);
                             mySqlCommand2.CommandText = " Select * from patients where passport=" + pass + " ";
                             mySqlConnection2.Open();

                            SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                            while (mySqlDataReader2.Read())
                            {
                                tt = mySqlDataReader[2].ToString() + "-" + mySqlDataReader[3].ToString() + " "+mySqlDataReader2[0].ToString() +" "+ mySqlDataReader2[1].ToString();
                                
                                listBox2.Items.Add(tt);
                            }
                           
                             mySqlDataReader2.Close();
                            mySqlConnection2.Close();
                        }
                                                
                        mySqlDataReader.Close();
                        mySqlConnection.Close();

                    }
                }
            }

                }

        private void Button8_Click(object sender, EventArgs e)
        {
            string value6 = "";
            string value7 = "";
            int pass2 = 0;
            DateTime d12 = new DateTime();
            string d14 = "";
            foreach (var listBoxItem in listBox2.SelectedItems)
            {

                value6 = listBoxItem.ToString();
                value7 = value6.Substring(0, value6.IndexOf("-"));
                
                d12 = DateTime.Parse(value7);
                d14 = d12.ToString("HH:mm:ss");
            }
            label2.Text = d14+" "+pass+" "+dateapps3;
            
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();

            mySqlCommand.CommandText = "Delete from appointments where passport =" + pass + " and date='" + dateapps3 + "'";
            mySqlCommand.ExecuteNonQuery();
            
            mySqlConnection.Close();
            
            MessageBox.Show("The appointment was removed successfully");     
        }

      
        private void Button9_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(this);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show(this);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show(this);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show(this);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show(this);
        }
    }
}
