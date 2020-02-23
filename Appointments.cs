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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select * from physiotherapists ";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())

                comboBox1.Items.Add(mySqlDataReader[0].ToString());


            mySqlDataReader.Close();
            mySqlConnection.Close();
            DataTable dt = new DataTable();
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("Passport", typeof(int));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Start Time", typeof(string));
            dt.Columns.Add("End Time", typeof(string));
            dt.Columns.Add("Physiotherapist", typeof(string));
            dt.Columns.Add("Version", typeof(string));
            dataGridView1.DataSource = dt;
        }

        Class1 c7 = new Class1();
        int flag = 0;
        DateTime startDate = new DateTime();
        DateTime endDate = new DateTime();
        DateTime today1 = DateTime.Today;
        string today2 = "";
        string startDate4 = "";
        string startDate3 = "";
        string endDate4 = "";
        string endDate3 = "";
        string n1 = "";
        int pass = 0;

        private void apps()
        {
            string[] stra2 = new string[8];
            today2 = today1.ToString("yyyy-MM-dd");
            int i, j, l, n;

            string d15 = "";
            DateTime d17 = new DateTime();
            string name = "";
            DataTable dt = new DataTable();
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("Passport", typeof(int));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Start Time", typeof(string));
            dt.Columns.Add("End Time", typeof(string));
            dt.Columns.Add("Physiotherapist", typeof(string));
            dt.Columns.Add("Version", typeof(string));
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

            SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
            if (flag == 0)
                mySqlCommand.CommandText = " Select * from appointments  order by date desc,time_start desc";
            if (flag == 1)
                mySqlCommand.CommandText = " Select * from appointments where physiotherapist='" + comboBox1.SelectedItem.ToString() + "' order by date desc,time_start desc";
            if (flag == 2)
                mySqlCommand.CommandText = " Select * from appointments where date between  '" + startDate4 + "' and  '" + endDate4 + "'   order by date desc,time_start desc";
            if (flag == 3)
                mySqlCommand.CommandText = " Select * from appointments where physiotherapist='" + comboBox1.SelectedItem.ToString() + "' and date between  '" + startDate4 + "' and  '" + endDate4 + "'   order by date desc,time_start desc";
            if (flag == 4)
                mySqlCommand.CommandText = " Select * from appointments where date='" + today2 + "'  order by time_start desc";
            if (flag == 5)
                mySqlCommand.CommandText = " Select * from appointments where  physiotherapist='" + comboBox1.SelectedItem.ToString() + "' and date ='" + today2 + "'  order by time_start desc";

            mySqlConnection.Open();

            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            DataRow dr2 = dt.NewRow();
            while (mySqlDataReader.Read())
            {
                for (i = 0, j = 2; i < 6; i++, j++)
                {

                    stra2[j] = mySqlDataReader[i].ToString() + "\n";
                    if (i == 1)
                        stra2[3] = stra2[3].Substring(0, 10);
                    if (i == 2)
                        stra2[4] = stra2[4].Substring(0, 5);
                    if (i == 3)
                        stra2[5] = stra2[5].Substring(0, 5);

                    dr2[j] = stra2[j];

                    name = mySqlDataReader[0].ToString();
                    pass = int.Parse(name);
                }

                mySqlCommand2.CommandText = " Select fname,lname from patients where passport=" + pass + " ";

                mySqlConnection2.Open();
                SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                while (mySqlDataReader2.Read())
                {
                    for (l = 0; l < 2; l++)
                    {
                        stra2[l] = mySqlDataReader2[l].ToString() + "\n";
                        dr2[l] = stra2[l];
                    }
                }
                mySqlDataReader2.Close();
                mySqlConnection2.Close();
                dt.Rows.Add(dr2);
                dr2 = dt.NewRow();
            }
            mySqlDataReader.Close();
            mySqlConnection.Close();
            dataGridView1.DataSource = dt;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            flag = 0;
            apps();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            flag = 1;
            apps();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            flag = 2;
            apps();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            startDate = monthCalendar1.SelectionRange.Start.Date;
            startDate4 = startDate.ToString("yyyy-MM-dd");
            startDate3 = startDate.ToShortDateString();
            textBox1.Text = startDate3;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            endDate = monthCalendar1.SelectionRange.Start.Date;
            endDate4 = endDate.ToString("yyyy-MM-dd");
            endDate3 = endDate.ToShortDateString();
            textBox2.Text = endDate3;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            flag = 3;
            apps();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            flag = 4;
            apps();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            flag = 5;
            apps();
        }
        DateTime d155 = new DateTime();
        int flag2 = 0;
        private void Button9_Click(object sender, EventArgs e)
        {
            TimeSpan t = new TimeSpan();
            TimeSpan t1 = new TimeSpan();
            TimeSpan t2 = new TimeSpan();
            int num = 0;
            
            string date_app1 = "";
            string date_app2 = "";
           

            int n = 0;
            int i;
            string d11 = "";
            DateTime d12 = new DateTime();

            DateTime date7 = new DateTime();
            string value4 = "";
            DateTime date8 = new DateTime();
            string value5 = "";
            string[] values = new string[8];
            int place;
            d12 = d155;
            d11 = d12.ToString("yyyy-MM-dd");
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                place = row.Index;
                for (i = 2; i <8; i++)
                {
                    values[i] = dataGridView1.Rows[place].Cells[i].Value.ToString();
                   
                       
                    
                    if (i == 4)
                    {
                        date7 = DateTime.Parse(values[4]);
                        value4=date7.ToString("HH:mm:ss");                
                    }
                    if (i == 5)
                    {
                        date8 = DateTime.Parse(values[5]);
                        value5 = date8.ToString("HH:mm:ss");
                    }
                    t = date8 - date7;
                    if (t.TotalMinutes == 30)
                        values[7] = "clinic";
                    if (t.TotalMinutes == 45)
                        values[7] = "private";
                }
            }
           
        SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
        SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
        mySqlCommand2.CommandText = "INSERT INTO appointments Values('" + values[2] + "','" +values[3] + "','" + value4 + "','" + value5 + "','" + values[6] + "','" + values[7] + "')";

            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select time_start,time_end from appointments where physiotherapist='"+comboBox1.SelectedItem.ToString()+"' and date='"+d157+"'";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            if(mySqlDataReader==null)
                flag2 = 0;
            while (mySqlDataReader.Read())
            {


                date_app1 = mySqlDataReader[0].ToString();
                date_app2 = mySqlDataReader[1].ToString();
                label5.Text += d157 + " " + date_app1 + " " + date_app2 + " ";
                t1 = DateTime.Parse(date_app2) - date7;
                t2 = date8 - DateTime.Parse(date_app1);
                if (t1.TotalMinutes > 0 && t2.TotalMinutes > 0)
                
                      flag2 = 1;
                

            }
            mySqlDataReader.Close();
            mySqlConnection.Close();
            if (flag2 == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this appointment?", "Cancel", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    mySqlConnection2.Open();
                    n = mySqlCommand2.ExecuteNonQuery();
                    MessageBox.Show("Inserted  " + n.ToString() + " appointment");
                    mySqlConnection2.Close();
                    flag2 = 0;
                }
            }
          else   
                {
                    mySqlConnection2.Open();
                    n = mySqlCommand2.ExecuteNonQuery();
                    MessageBox.Show("Inserted  " + n.ToString() + " appointment");
                    mySqlConnection2.Close();          
            }       
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            c7.Search(listBox1, textBox3, radioButton1, radioButton2, radioButton3);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(this);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show(this);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show(this);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show(this);
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show(this);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            int n;
            int i = 0;
            int place = 0;
            int passport2 = 0;
            DateTime d12 = new DateTime();
            string d11 = "";
            DateTime d14 = new DateTime();
            string d15 = "";
            string[] values = new string[6];

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                place = row.Index;

                for (i = 0; i < 6; i++)
                {
                    values[i] = dataGridView1.Rows[place].Cells[i + 2].Value.ToString();
                }
            }
            passport2 = int.Parse(values[0]);
            d12 = DateTime.Parse(values[1]);
            d11 = d12.ToString("yyyy-MM-dd");
            d14 = DateTime.Parse(values[2]);
            d15 = d14.ToString("HH:mm:ss");
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();

            mySqlCommand.CommandText = "Delete from appointments where passport =" + passport2 + " and date='" + d11 + "' ";                     
            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show( n.ToString() + " appointment was deleted");
            mySqlConnection.Close();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
        string data = "";
        string passport = "";
        string fname = "";
        string lname = "";
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
            foreach (var listBoxItem in listBox1.SelectedItems)
            {
                data = listBoxItem.ToString();
                passport = data.Substring(0, data.IndexOf("-"));
            }     

        }
        int place2 = 0;
        string d157 = "";
        private void Button16_Click(object sender, EventArgs e)
        {
            place2 = 0;
            DateTime d12 = new DateTime();
            string d11 = "";
            int i = 0;
            int place = 0;

            d12 = monthCalendar1.SelectionRange.Start.Date;
            d11 = d12.ToString("yyyy-MM-dd");

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                place = row.Index;
               
                dataGridView1.Rows[place].Cells[2].Value = passport;

                dataGridView1.Rows[place ].Cells[3].Value = d11;

                dataGridView1.Rows[place ].Cells[6].Value = comboBox1.SelectedItem.ToString();
             
            }
            d155= monthCalendar1.SelectionRange.Start.Date;
                d157 = d155.ToString("yyyy-MM-dd");
        }
    }
}
