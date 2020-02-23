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
using System.IO;
using System.Diagnostics;

namespace Diploma_Final
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label18.Text = "";
            label21.Text = "";



            radioButton1.Checked = true;
            listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_DoubleClick);


            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Start Time", typeof(string));
            dt.Columns.Add("End Time", typeof(string));
            dt.Columns.Add("Physiotherapist", typeof(string));
            dt.Columns.Add("Version", typeof(string));
            dataGridView1.DataSource = dt;

            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select * from physiotherapists";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
                comboBox1.Items.Add(mySqlDataReader[0].ToString());

            mySqlDataReader.Close();
            mySqlConnection.Close();



            SqlConnection mySqlConnection3 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand3 = mySqlConnection3.CreateCommand();
            mySqlCommand3.CommandText = " Select distinct  kind from exercise";
            mySqlConnection3.Open();
            SqlDataReader mySqlDataReader3 = mySqlCommand3.ExecuteReader();
            while (mySqlDataReader3.Read())
            { 
            listBox3.Items.Add(mySqlDataReader3[0].ToString());
         }
            mySqlDataReader3.Close();
           
            mySqlConnection3.Close();

           

        }
        Class1 c1 = new Class1();
        string data = "";
        string passport = "";
        string[] data2 = new string[10];
        DateTime startDate = new DateTime();
        DateTime endDate=new DateTime();
        string startDate3 = "";
        string startDate4 = "";

        string endDate4 = "";
        string endDate3 = "";
        int flag = 0;
        int flag2 = 0;
        string kind = "";
        DateTime d111 = new DateTime();
        string d123 = "";
        DateTime d222 = new DateTime();
        string d789 = "";
        DateTime today1 = DateTime.Today;
        string today2 = ""; 
        private DataTable ShowAppointments(DataTable app3,string startDate4,string endDate4)

        {

            today2=today1.ToString("yyyy-MM-dd");

            int i;
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Start Time", typeof(string));
            dt.Columns.Add("End Time", typeof(string));
            dt.Columns.Add("Physiotherapist", typeof(string));
            dt.Columns.Add("Version", typeof(string));
            SqlConnection mySqlConnection1 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand1 = mySqlConnection1.CreateCommand();
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            if (flag == 0)
                mySqlCommand.CommandText = " Select date,time_start,time_end,physiotherapist,app_version from appointments where passport=" + int.Parse(label3.Text) + " order by date desc,time_start desc ";
               mySqlCommand1.CommandText = " Select date from appointments where date=(select MAX(date) from appointments where passport=" + int.Parse(label3.Text) + ")";
           
            if (flag == 1)
                mySqlCommand.CommandText = " Select date,time_start,time_end,physiotherapist,app_version from appointments where passport=" + int.Parse(label3.Text) + " and date between  '" + startDate4 + "'  and  '" + endDate4 + "' order by date desc,time_start desc ";
            mySqlCommand1.CommandText = " Select date from appointments where date=(select MAX(date) from appointments where passport=" + int.Parse(label3.Text) + " and date between  '" + startDate4 + "'  and  '" + endDate4 + "')";

            if (flag == 2)
                mySqlCommand.CommandText = " Select date,time_start,time_end,physiotherapist,app_version from appointments where passport=" + int.Parse(label3.Text) + " and date<=  '" + today2 + "'   order by date desc,time_start desc ";
            mySqlCommand1.CommandText = " Select date from appointments where date=(select MAX(date) from appointments where passport=" + int.Parse(label3.Text) + " and date<=  '" + today2 + "')";

            if (flag == 3)
                mySqlCommand.CommandText = " Select date,time_start,time_end,physiotherapist,app_version from appointments where passport=" + int.Parse(label3.Text) + " and date>=  '" + today2 + "'   order by date desc,time_start desc ";
            mySqlCommand1.CommandText = " Select date from appointments where date=(select MAX(date) from appointments where passport=" + int.Parse(label3.Text) + " and date>=  '" + today2 + "')";

            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            DataRow dr = dt.NewRow();



            
            while (mySqlDataReader.Read())
            {


                for (i = 0; i < 5; i++)
                {
                    if (flag == 0 || flag == 2)
                    {
                        d123 = mySqlDataReader[0].ToString();
                    }
                    data2[i] = mySqlDataReader[i].ToString() + "\n";
                    if (i == 0)
                        data2[0] = data2[0].Substring(0, data2[0].IndexOf(" "));

                    dr[i] = data2[i];
                }

                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
            mySqlDataReader.Close();
            mySqlConnection.Close();

            
                         mySqlConnection1.Open();
                         SqlDataReader mySqlDataReader1 = mySqlCommand1.ExecuteReader();
                         while (mySqlDataReader1.Read())
                         {
                             if (flag == 0 || flag==3)
                                 d789 = mySqlDataReader1[0].ToString();
                             
                         }
                         mySqlDataReader1.Close();
                         mySqlConnection1.Close();
            dataGridView1.DataSource = dt;


            if (flag == 0)
             {
                 d111 = DateTime.Parse(d123);
                 d222 = DateTime.Parse(d789);
             }
            if (flag == 1)
            {
                d111 =startDate;
                d222 = endDate;
            }
            if (flag==2)
             {
                d111=  DateTime.Parse(d123);
                d222 = DateTime.Today;
             }
             if (flag == 3)
             {
                 d111 = DateTime.Today;
                 d222 = DateTime.Parse(d789);
             }
              if (flag == 2)
              {
                  startDate = DateTime.Parse(d123);

                  endDate = today1;

              }
              if (flag == 3)
              {
                  startDate = today1;
                  endDate = DateTime.Parse(d789);

              }
             if (flag == 0)
             {
                  startDate = DateTime.Parse(d123);
                  endDate = DateTime.Parse(d789);
              }
            
            return dt;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach (var listBoxItem in listBox1.SelectedItems)
            {
                data = listBoxItem.ToString();
                passport = data.Substring(0, data.IndexOf("-"));
            }
        }
        private void Statistics()
        {
               
            int sum = 0;
            double num2 = 0;
            double num = 0;
            double avr=0;

            sum = dataGridView1.RowCount-1;
             label18.Text = sum.ToString();
            TimeSpan t = new TimeSpan();

            int i;
            int dayindex, day9 = 0, day10 = 0;
            string[] days = new string[7];
            days[6] = "Sunday";
            days[5] = "Monday";
            days[4] = "Tuesday";
            days[3] = "Wednesday";
            days[2] = "Thursday";
            days[1] = "Friday";
            days[0] = "Saturday";
            string day2 = "";
            string day3 = "";
            if (flag == 0 || flag==2 || flag==3) { 
             day2 = d111.DayOfWeek.ToString();
             day3 = d222.DayOfWeek.ToString();
            }
            if (flag == 1)
            {
                day2 = startDate.DayOfWeek.ToString();
                day3 = endDate.DayOfWeek.ToString();
            }
            for (i = 0; i < 7; i++)
            {
                if (days[i] == day2)
                {
                    dayindex = i+1 ;
                    day9 = 7 - dayindex;
                }
            }

            string[] days2 = new string[7];
            days2[0] = "Sunday";
            days2[1] = "Monday";
            days2[2] = "Tuesday";
            days2[3] = "Wednesday";
            days2[4] = "Thursday";
            days2[5] = "Friday";
            days2[6] = "Saturday";
            

            for (i = 0; i < 7; i++)
            {
                if (days2[i] == day3)
                {
                    dayindex = i+1;
                    day10 = 7 - dayindex;
                }
            }

            t = d222 - d111;
            num = t.TotalDays+day9+day10+1;
            num2 = sum / num* 7;
            
       
            string num3 = "";
            label18.Text = sum.ToString();
            num3 = num2.ToString();
            if (num2.ToString().Length > 7)
            {
                
                num3 = num3.Substring(0, 5);
            }
            label21.Text = num3;
        }
        private void listBox1_DoubleClick(object sender, MouseEventArgs e)
        {
            DateTime d = new DateTime();            
            DateTime t = DateTime.Today;
           
            int birthday = 0;                   
           
           
            int i, j;

            string date2 = "";
            string d11 = "";
            DateTime d12 = new DateTime();
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select * from patients where passport like " + passport + "";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
                for (i = 0; i < 9; i++)
                    data2[i] = mySqlDataReader[i].ToString() + "\n";


            mySqlDataReader.Close();
            mySqlConnection.Close();

            textBox2.Text = data2[0];
            textBox3.Text = data2[1];
            maskedTextBox1.Text = data2[2];
            textBox4.Text = data2[4];
            textBox5.Text = data2[5];
            textBox6.Text = data2[6];
            textBox7.Text = data2[7];
            comboBox1.Text = data2[8];

            label2.Text = data2[0] + data2[1];
            label3.Text = data2[2];

            SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
            mySqlCommand2.CommandText = " Select arrival from arr_check where arrival=(select MAX(arrival) from arr_check where passport like " + passport + ")";

            mySqlConnection2.Open();
            SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();

            while (mySqlDataReader2.Read())
            {
                data2[9] = mySqlDataReader2[0].ToString() + "\n";
                

            }
            mySqlDataReader2.Close();
            mySqlConnection2.Close();

            d12 = DateTime.Parse(data2[3]);
            d11 = d12.ToString("dd/MM/yyyy");
            maskedTextBox2.Text = d11;
            d12 = DateTime.Parse(data2[9]);
            d11 = d12.ToString("dd/MM/yyyy");
            maskedTextBox3.Text = d11;
            d = DateTime.Parse(maskedTextBox2.Text.ToString());
            birthday = t.Year - d.Year;

            label1.Text = birthday.ToString() + " years";
            flag = 0;
           

            

        }

        private void MaskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void MaskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            startDate = monthCalendar1.SelectionRange.Start.Date;
            startDate4 = startDate.ToString("yyyy-MM-dd");
            startDate3 = startDate.ToShortDateString();
            textBox8.Text = startDate3;
        }

        private void MaskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            endDate = monthCalendar1.SelectionRange.Start.Date;
            endDate4 = endDate.ToString("yyyy-MM-dd");
            endDate3 = endDate.ToShortDateString();
            textBox9.Text = endDate3;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            flag = 0;
            DataTable dt = new DataTable();
           
             ShowAppointments(dt, startDate4, endDate4);
            Statistics();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            flag = 1;
            DataTable dt = new DataTable();
              ShowAppointments(dt, startDate4, endDate4);
           Statistics();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

           flag = 2;
            DataTable dt = new DataTable();
             ShowAppointments(dt, startDate4, endDate4);
               Statistics();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            flag = 3;
            DataTable dt = new DataTable();
             ShowAppointments(dt, startDate4, endDate4);
            Statistics();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
           
           

            DateTime d = new DateTime();
            DateTime t = DateTime.Today;
         
            int birthday = 0;
            int n = 0;

            string d11 = "";
            DateTime d12 = new DateTime();

            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();            

            try
            {
                d12 = DateTime.Parse(maskedTextBox2.Text);
                d11 = d12.ToString("yyyy-MM-dd");
                d = DateTime.Parse(maskedTextBox2.Text);
                birthday = t.Year - d.Year;
                label1.Text = birthday.ToString() + " years";
                if (birthday > 130 || birthday<=0 || maskedTextBox1.Text.Length<7 || textBox4.Text.Length<6)
                    throw new Exception ("no");
                else
                {
                    mySqlCommand.CommandText = "INSERT INTO patients Values('" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + d11 + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
                    n = mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show(n.ToString() + " new account was created");

                    var path = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\";
                    var fileName = String.Format("{0}{1}",
                    Path.GetFileNameWithoutExtension(path), maskedTextBox1.Text);
                    Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(path), fileName));

                    passport = maskedTextBox1.Text;
                }
            }
            catch
            {
                MessageBox.Show("Please, check your input");
            }
            mySqlConnection.Close();
            

        }

        private void Button7_Click(object sender, EventArgs e)
        {
     
            DateTime d = new DateTime();
            DateTime arr = new DateTime();
            DateTime t = DateTime.Today;

            DateTime d12 = new DateTime();
            string d11 = "";
            int birthday = 0;
            int arr2 = 0;
           
            int n;
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            try
            {
                d12 =DateTime.Parse(maskedTextBox2.Text);
                d11 = d12.ToString("yyyy-MM-dd");
                d = DateTime.Parse(maskedTextBox2.Text);
                arr = DateTime.Parse(maskedTextBox2.Text);
                birthday = t.Year - d.Year;
                arr2 = t.Year - arr.Year;
                label1.Text = birthday.ToString() + " years";
                if (birthday > 130 || birthday <= 0 || maskedTextBox1.Text.Length < 7 || textBox4.Text.Length < 6 )
                    throw new Exception("no");

                else
                {
                    mySqlCommand.CommandText = "UPDATE patients SET fname = @fn, lname=@ln, passport=@pass, date_of_birth=@date_b, phone_1=@ph1, phone_2=@ph2, address=@addr, email=@em,  physiotherapist=@phyth Where passport = @pass2";
                    mySqlCommand.Parameters.AddWithValue("@fn", textBox2.Text);
                    mySqlCommand.Parameters.AddWithValue("@ln", textBox3.Text);
                    mySqlCommand.Parameters.AddWithValue("@pass", maskedTextBox1.Text);
                    mySqlCommand.Parameters.AddWithValue("@date_b", d11);
                    mySqlCommand.Parameters.AddWithValue("@ph1", textBox4.Text);
                    mySqlCommand.Parameters.AddWithValue("@ph2", textBox5.Text);
                    mySqlCommand.Parameters.AddWithValue("@addr", textBox6.Text);
                    mySqlCommand.Parameters.AddWithValue("@em", textBox7.Text);
                    mySqlCommand.Parameters.AddWithValue("@phyth", comboBox1.Text.ToString());
                    mySqlCommand.Parameters.AddWithValue("@pass2", passport);

                    mySqlCommand.ExecuteNonQuery();
                    n = mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show("" + n + " account was updated!");
                }
            }
            catch
            {
                MessageBox.Show("Please, check your input");
            }
            mySqlConnection.Close();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
   
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            c1.Search(listBox1, textBox1, radioButton1, radioButton2, radioButton3);
        
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile(@"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\Home_exercises.rtf");
            Process.Start(@"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\Home_exercises.rtf");



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            flag = 1;
            Statistics();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            string d11 = "";
            DateTime d12 = new DateTime();
            d12 = DateTime.Parse(maskedTextBox4.Text);
            d11 = d12.ToString("yyyy-MM-dd");
            int n = 0;
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();

            mySqlCommand.CommandText = "UPDATE arr_check SET checkout=@ch where arrival=(select MAX(arrival) from arr_check where passport=@pass)";
            mySqlCommand.Parameters.AddWithValue("@ch", d11);
            mySqlCommand.Parameters.AddWithValue("@pass", passport);
            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show(n.ToString() + " row was inserted");
            mySqlConnection.Close();
        }
        string datenew = "";
       
        private void Button13_Click(object sender, EventArgs e)
        {
          
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            int i;
            int y = 1;
                
                 foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Index!=dataGridView1.Rows.Count-1)
                richTextBox1.Text += y.ToString() + "."+"\n";
                for (i = 1; i < 4; i++)
                    if (row.Cells[i].Value != null) {
                        
                   richTextBox1.Text += row.Cells[i].Value.ToString() ;
                        richTextBox1.Text += "\n";
                        
                    }
                    y++;
                
            } 
        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button15_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText += comboBox3.Text;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            int n;
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "INSERT INTO exercise Values('" + textBox10.Text + "','"+listBox3.SelectedItem.ToString()+"')";
            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show(n.ToString() + " row was inserted");
            mySqlConnection.Close();
        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button17_Click(object sender, EventArgs e)
        {
            int n;
            int sel;
            string del = comboBox3.SelectedItem.ToString();
            sel = comboBox3.SelectedIndex;
            comboBox3.Items.RemoveAt(sel);
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "Delete from exercise where name like '" + del + "'";
            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show(n.ToString() + " row was deleted");
            mySqlConnection.Close();

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button18_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show(this);
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show(this);
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show(this);
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show(this);
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show(this);
        }

        private void Panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button23_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string kind2 = "";
            foreach (var listBoxItem in listBox3.SelectedItems)

              {
                 kind2 = listBoxItem.ToString();
                 
                  
              }  
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

            mySqlConnection.Open();
            mySqlCommand.CommandText = " Select name from exercise where kind='"+kind2+"'";
            SqlDataReader mySqlDataReader= mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                comboBox3.Items.Add(mySqlDataReader[0].ToString());

            }
           
            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button24_Click(object sender, EventArgs e)
        {

            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text ="";
            comboBox1.Text = "";
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

        }

        private void Button25_Click(object sender, EventArgs e)
        {
            string pass1="";
            string pass2="";
            foreach (var listBoxItem in listBox1.SelectedItems)
            {

                 pass1 = listBoxItem.ToString();
                 pass2 = pass1.Substring(0, pass1.IndexOf("-"));              
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this account and all it's containts?", "Cancel", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
             SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();

            SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
            mySqlConnection2.Open();

            mySqlCommand.CommandText = "Delete from patients where passport like '" +pass2 + "'";
            mySqlCommand2.CommandText = "Delete from arr_check where passport like '" + pass2 + "'";

            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            mySqlCommand2.ExecuteNonQuery();
            mySqlConnection2.Close();

            }
            

        }
        private void listBox3_DoubleClick(object sender, MouseEventArgs e)
        {
           
           
        }

            private void PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

      
        private void Button26_Click(object sender, EventArgs e)
        {
            int n;
        
            string checks = "";
            DateTime d12 = new DateTime();
            string d11 = "";
            d12 = DateTime.Parse(maskedTextBox3.Text);
            d11 = d12.ToString("yyyy-MM-dd");
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "INSERT INTO arr_check (passport,arrival) Values('"+ maskedTextBox1.Text + "','" + d11 + "')";
            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show(n.ToString() + " row was inserted");
            mySqlConnection.Close();
           
            var path2 = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\";

            DateTime datef = DateTime.Parse(maskedTextBox3.Text.ToString());

            string valuenew = datef.ToString("dd-MM-yyyy");
            string help = @"\";
            var fileName2 = String.Format("{0}{1}{2}{3}",
            Path.GetFileNameWithoutExtension(path2), maskedTextBox1.Text, help, valuenew);
            var result = Path.Combine(Path.GetDirectoryName(path2), fileName2);
            Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(path2), fileName2));

            checks = "check" + maskedTextBox1.Text + "(" + datef + ")";

            SqlConnection mySqlConnection4 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand4 = mySqlConnection4.CreateCommand();
            mySqlConnection4.Open();
            mySqlCommand4.CommandText = "create table " + checks + "(date date, pain int, sensitivity int, control int, movement int, flexibility int)";
            mySqlCommand4.ExecuteNonQuery();
            mySqlConnection4.Close();


        }

        private void Button27_Click(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void Label27_Click(object sender, EventArgs e)
        {

        }
    }
}
