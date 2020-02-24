using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Diploma_Final
{
    class Class1
    {

        public void Search(ListBox listBox1, TextBox textBox1, RadioButton radioButton1, RadioButton radioButton2, RadioButton radioButton3)
        {

            
            int flag = 0;
            string strname = "";


            if (radioButton1.Checked == true)
            {
                flag = 0;
                strname = "fname";
            }
            if (radioButton2.Checked == true)
                flag = 1;
            strname = "lname";
            if (radioButton3.Checked == true)
                flag = 2;
            strname = "passport";
            {
                listBox1.Items.Clear();
                SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                if (flag == 0)
                    strname = "fname";
                if (flag == 1)
                    strname = "lname";
                if (flag == 2)
                    strname = "passport";
                mySqlCommand.CommandText = " Select passport,fname,lname,physiotherapist from patients where " + strname + " like '" + textBox1.Text + "%'";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    strname = mySqlDataReader[0].ToString() + "-" + mySqlDataReader[1].ToString() + mySqlDataReader[2].ToString() + "(" + mySqlDataReader[3].ToString() + ")" + "\n";
                 
                    listBox1.Items.Add(strname);

                    if (textBox1.Text == "")
                        listBox1.Items.Clear();
                }
                mySqlDataReader.Close();
                mySqlConnection.Close();
            }

        }

        public string Addapps(string g2, ListBox listBox2, string passport)
        {
            string datenew="";
            DateTime g = new DateTime();
            g2 = "";
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select arrival from arr_check where passport like " + passport + "";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();


            while (mySqlDataReader.Read())
            {
                datenew = mySqlDataReader[0].ToString();
                g = DateTime.Parse(datenew);
                g2 = g.ToString("dd-MM-yyyy");
                datenew = datenew.Substring(0, 10);
                listBox2.Items.Add(g2);

            }
            mySqlDataReader.Close();
            mySqlConnection.Close();
            return g2;
        }
        public void Searchby(ComboBox comboBox2, TextBox textBox1, DataGridView dataGridView1, string s1, string s2)
        {
            
            string r = "";
            DateTime r1 = new DateTime();
            int i;
            DataTable dt = new DataTable();
            dt.Columns.Add("Fname", typeof(string));
            dt.Columns.Add("Lname", typeof(string));
            dt.Columns.Add("Passport", typeof(int));
            dt.Columns.Add("Date of birth", typeof(string));
            dt.Columns.Add("Phone_1", typeof(string));
            dt.Columns.Add("Phone_2", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("Physiotherapist", typeof(string));

            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select * from patients where " + s1 + " like '%" + s2 + "%'";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            string[] strdata = new string[9];
            DataRow dr = dt.NewRow();
            while (mySqlDataReader.Read())
            {
                for (i = 0; i < 9; i++)
                {

                    strdata[i] = mySqlDataReader[i].ToString() + "\n";
                    if (i == 3) { 
                       r1=DateTime.Parse( strdata[3]) ;
                    r = r1.ToString("dd/MM/yyyy");
                        strdata[3] = r;
                    }
                    dr[i] = strdata[i];
                }
                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
            mySqlDataReader.Close();
            mySqlConnection.Close();
            dataGridView1.DataSource = dt;
        }



        public void Calendar(DataGridView dataGridView1, DateTime startDate, DateTime startDate2, DateTime startDate7, string startDate5, string startDate8, int dayindex, int day9, int flag, ComboBox comboBox1)
        {
            int t;
            int y;
            for (t = 1; t < 51; t++)
            {
                for (y = 1; y < 8; y++)
                {
                    dataGridView1.Rows[t].Cells[y].Value = "";
                }
            }
            int i;
            int l;
            DateTime c = new DateTime();

            string sub = "";
            string day2 = "";

            string[] days = new string[7];
            days[0] = "Sunday";
            days[1] = "Monday";
            days[2] = "Tuesday";
            days[3] = "Wednesday";
            days[4] = "Thursday";
            days[5] = "Friday";
            days[6] = "Saturday";

            day2 = startDate.DayOfWeek.ToString();

            for (i = 0; i < 7; i++)
            {

                if (days[i] == day2)
                {
                    dayindex = i + 1;
                    day9 = 7 - dayindex;
                }
            }

            c = startDate;

            for (l = dayindex; l < 8; l++)
            {
                sub = c.ToString();
                sub = sub.Substring(0, 10);
                dataGridView1.Rows[0].Cells[l].Value = sub;
                c = c.AddDays(1);
            }
            c = startDate;
            for (l = dayindex; l > 0; l--)
            {
                sub = c.ToString();
                sub = sub.Substring(0, 10);
                dataGridView1.Rows[0].Cells[l].Value = sub;
                c = c.AddDays(-1);
            }
            c = startDate;
            int[,] array = new int[100, 9];
           
            int j = 0;
            int m =0;
            for (j = 0; j < 100; j++)
                for (m = 0; m < 9; m++)
                    array[j, m] = 0;
                    DateTime k = new DateTime();
            string pass = "";
            int ind = 0;

            startDate2 = startDate.AddDays(-dayindex);
            startDate5 = startDate2.ToString("yyyy-MM-dd");

            startDate7 = startDate.AddDays(day9);
            startDate8 = startDate7.ToString("yyyy-MM-dd");
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();

            mySqlConnection.Open();
            mySqlConnection2.Open();
            mySqlCommand2.CommandText = " Select date,time_start,passport,time_end,app_version from appointments where physiotherapist='" + comboBox1.SelectedItem.ToString() + "' and date between '" + startDate5 + "' and '" + startDate8 + "' ";

            Font style = new Font("Arial", 24, FontStyle.Bold);
           
            string app = "private";
            app = app.Substring(0, 1);
            string app2 = "";
            string day3 = "";
            int pass2 = 0;
           
            SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();

            while (mySqlDataReader2.Read())
            {
                app2 = mySqlDataReader2[4].ToString();
                app2 = app2.Substring(0, 1);
                if (app == app2)
                    flag = 1;
                else
                    flag = 0;
                day2 = mySqlDataReader2[1].ToString();
                day2 = day2.Substring(0, 5);
                pass = mySqlDataReader2[2].ToString();
                day3 = mySqlDataReader2[0].ToString();
                k = DateTime.Parse(day3);
                day3 = k.DayOfWeek.ToString();
                pass2 = int.Parse(pass);

                mySqlCommand.CommandText = " Select passport,fname,lname from patients where passport=" + pass2 + " ";
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (i = 0; i < 7; i++)
                    {
                        if (days[i] == day3)
                        {
                            dayindex = i + 1;
                            day9 = 7 - dayindex;
                        }
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                            if (day2 == row.Cells[0].Value.ToString())
                            {

                                
                                
                                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                  row.Cells[dayindex].Style.Font = new Font("Verdana", 8, FontStyle.Regular);
                                if (array[row.Index, dayindex] == 1)
                                    row.Cells[dayindex].Style.ForeColor = Color.Red;
                                else
                                    row.Cells[dayindex].Style.ForeColor = Color.Green;
                                row.Cells[dayindex].Value += mySqlDataReader[0].ToString() + "-" + mySqlDataReader[1].ToString() + " " + mySqlDataReader[2].ToString();

                                array[row.Index,dayindex]=1;

                                ind = row.Index;
                                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                                dataGridView1.Rows[ind + 1].Cells[dayindex].Style.Font = new Font("Verdana", 8, FontStyle.Regular);
                                if (array[row.Index+1, dayindex] == 1)
                                    dataGridView1.Rows[ind + 1].Cells[dayindex].Style.ForeColor = Color.Red;
                                else
                                    dataGridView1.Rows[ind + 1].Cells[dayindex].Style.ForeColor = Color.Blue;
                              
                                dataGridView1.Rows[ind + 1].Cells[dayindex].Value += mySqlDataReader[0].ToString() + "-" + mySqlDataReader[1].ToString() + " " + mySqlDataReader[2].ToString() + "\n";
                                array[row.Index+1, dayindex] = 1;
                                if (flag == 1)
                                {

                                    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                    dataGridView1.Rows[ind + 2].Cells[dayindex].Style.Font = new Font("Verdana", 8,FontStyle.Regular);
                                    if (array[row.Index + 2, dayindex] == 1)
                                        dataGridView1.Rows[ind + 2].Cells[dayindex].Style.ForeColor = Color.Red;
                                    else
                                        dataGridView1.Rows[ind + 2].Cells[dayindex].Style.ForeColor = Color.Blue;
                                  
                                    dataGridView1.Rows[ind + 2].Cells[dayindex].Value += mySqlDataReader[0].ToString() + "-" + mySqlDataReader[1].ToString() + " " + mySqlDataReader[2].ToString();
                                    array[row.Index + 2, dayindex] = 1;
                                }
                            }
                    }
                }
                mySqlDataReader.Close();
            }
            mySqlDataReader2.Close();
            mySqlConnection.Close();
        }
        public void Week(DataGridView dataGridView1, DateTime c)
        {
            int l;
            string sub = "";

            string[] days = new string[7];
            days[0] = "Sunday";
            days[1] = "Monday";
            days[2] = "Tuesday";
            days[3] = "Wednesday";
            days[4] = "Thursday";
            days[5] = "Friday";
            days[6] = "Saturday";
            int i;
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Time", typeof(string));
            for (i = 0; i < 7; i++)
                dt1.Columns.Add(days[i], typeof(string));

            DataRow dr3 = dt1.NewRow();

            dt1.Rows.Add(dr3);
            dataGridView1.DataSource = dt1;
            int dayindex = 0;
            string day2 = c.DayOfWeek.ToString();
            DateTime b = new DateTime();
            b = c;

            for (i = 0; i < 7; i++)
            {
                if (days[i] == day2)
                    dayindex = i + 1;
            }

            for (l = dayindex; l > 0; l--)
            {
                sub = b.ToString();
                sub = sub.Substring(0, 10);
                dataGridView1.Rows[0].Cells[l].Value = sub;
                b = b.AddDays(-1);
            }

            b = c;
            for (l = dayindex; l < 8; l++)
            {
                sub = b.ToString();
                sub = sub.Substring(0, 10);
                dataGridView1.Rows[0].Cells[l].Value = sub;
                b = b.AddDays(1);
            }

            int j;
            int k = 0;
            string time = "";
            string[] minutes = new string[4];
            minutes[0] = ":00";
            minutes[1] = ":15";
            minutes[2] = ":30";
            minutes[3] = ":45";

            for (i = 0; i < 51; i++)
            {
                DataRow dr1 = dt1.NewRow();
                dt1.Rows.Add(dr1);
            }

            dataGridView1.DataSource = dt1;
            int sh = 7;

            for (j = 1; j < 52; j++)
            {
                time = "";
                if (sh < 10 && sh > 6)
                    time = "0";
                time += sh.ToString();
                time += minutes[k];
                k++;

                if (k == 4)
                {
                    k = 0;
                    sh++;
                }

                dataGridView1.Rows[j].Cells[0].Value = time;
            }

            int m;
            for (m = 0; m < 7; m++)
                dataGridView1.Columns[m].Width = 250;
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 60;
        }
    }
}


