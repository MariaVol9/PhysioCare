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

namespace Diploma_Final
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
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
            dt.Columns.Add("Arrival", typeof(string));
            DataRow dr = dt.NewRow();
            dr = dt.NewRow();
            dataGridView1.DataSource = dt;

        }
        Class1 c3 = new Class1();
        private DataTable ShowAll(DataTable a)
        {
            DateTime r1 = new DateTime();
            string r = "";
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
            mySqlCommand.CommandText = "Select * from patients;";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            int i;
            string[] strdata = new string[9];
            DataRow dr = dt.NewRow();

            while (mySqlDataReader.Read())
            {
                for (i = 0; i < 9; i++)
                {
                    strdata[i] = mySqlDataReader[i].ToString() + "\n";
                    if (i == 3)
                    {
                        r1 = DateTime.Parse(strdata[3]);
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
            return dt;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            ShowAll(dt);
        }
        string passport = "";
        private void Button2_Click(object sender, EventArgs e)
        {
            DateTime d12 = new DateTime();
            string d11 = "";

            int place;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string ph = "";
                ph = comboBox1.Text.ToString();
                int n;
                int i;
                place = row.Index;
                string[] values = new string[9];

                for (i = 0; i < 9; i++)
                {
                    values[i] = dataGridView1.Rows[place].Cells[i].Value.ToString();
                    if (i == 3)
                    {
                        d12 = DateTime.Parse(values[3]);
                        values[3] = d12.ToString("yyyy-MM-dd");
                    }
                }

                var path = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\";
                var fileName = String.Format("{0}{1}",
                Path.GetFileNameWithoutExtension(path), values[0]);
                Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(path), fileName));

                passport = values[0];

                SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = "INSERT INTO patients Values('" + values[0] + "','" + values[1] + "','" + values[2] + "','" + d11 + "','" + values[4] + "','" + values[5] + "','" + values[6] + "','" + values[7] + "','" + comboBox1.SelectedItem.ToString() + "')";
                n = mySqlCommand.ExecuteNonQuery();
                MessageBox.Show(n.ToString() + " row was inserted");
                mySqlConnection.Close();
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string s1 = "physiotherapist";
            string s2 = comboBox1.SelectedItem.ToString();
            c3.Searchby(comboBox2, textBox1, dataGridView1, s1, s2);
        }



        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            /*  int i;
              string[] features = new string[9];
              features[0] = "Fname";
              features[1] = "Lname";
              features[2] = "Passport";
              features[3] = "Date of birth";
              features[4] = "Phone_1";
              features[5] = "Phone_2";
              features[6] = "Address";
              features[7] = "email";
              features[8] = "Physiotherapist";

              i = comboBox2.SelectedIndex;
              string s1 = features[i];
              string s2 = textBox1.Text;
              c3.Searchby(comboBox2, textBox1, dataGridView1, s1, s2);*/

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int n;
            int i;
            int place;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {

                place = row.Index;
                string[] values = new string[9];

                for (i = 0; i < 9; i++)
                {
                    values[i] = dataGridView1.Rows[place].Cells[i].Value.ToString();

                }
                SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = "UPDATE patients SET fname = '" + values[0] + "', lname = '" + values[1] + "',passport=" + values[2] + ",date_of_birth='" + values[3] + "',phone_1='" + values[4] + "', phone_2= '" + values[5] + "', address = '" + values[6] + "', email = '" + values[7] + "', physiotherapist = '" + values[8] + "' where passport='" + values[2] + "'";
                n = mySqlCommand.ExecuteNonQuery();
                MessageBox.Show(n.ToString() + " row was updated");
                mySqlConnection.Close();

            }
        }


        private void Button6_Click(object sender, EventArgs e)

        {         

            DateTime arrival = monthCalendar1.SelectionRange.Start.Date;
            string arrival2 = arrival.ToString("yyyy-MM-dd");

            string[] values = new string[9];
            string passport = "";
            int n;
            int place;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                place = row.Index;
                passport = dataGridView1.Rows[place].Cells[2].Value.ToString();

            }
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "INSERT INTO arr_check (passport,arrival) Values(" + passport + ",'" + arrival + "')";
            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show(n.ToString() + " row was inserted");
            mySqlConnection.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(this);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show(this);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show(this);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show(this);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show(this);
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            DateTime arrival = monthCalendar1.SelectionRange.Start.Date;
            string arrival2 = arrival.ToString("yyyy-MM-dd");

            string[] values = new string[9];
            string passport = "";
            int n;
            int place;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                place = row.Index;
                passport = dataGridView1.Rows[place].Cells[2].Value.ToString();

            }
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "INSERT INTO arr_check (passport,arrival) Values(" + passport + ",'" + arrival2 + "')";
            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show(n.ToString() + " row was inserted");
            mySqlConnection.Close();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button10_Click_1(object sender, EventArgs e)
        {

        }

        private void Button11_Click_1(object sender, EventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            string s1 = "physiotherapist";
            string s2 = comboBox1.SelectedItem.ToString();
            c3.Searchby(comboBox2, textBox1, dataGridView1, s1, s2);

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string d11 = "";
            DateTime d12 = new DateTime();
            int i;
            string[] features = new string[9];
            features[0] = "Fname";
            features[1] = "Lname";
            features[2] = "Passport";
            features[3] = "Date of birth";
            features[4] = "Phone_1";
            features[5] = "Phone_2";
            features[6] = "Address";
            features[7] = "email";
            features[8] = "Physiotherapist";

            i = comboBox2.SelectedIndex;
            string s1 = features[i];
            string s2 = textBox1.Text;
            if (i == 3)
            {
                d12 = DateTime.Parse(textBox1.Text);
                d11 = d12.ToString("yyyy-MM-dd");
                s2 = d11;
            }
            c3.Searchby(comboBox2, textBox1, dataGridView1, s1, s2);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            int n;
            int i;
            int place;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {

                place = row.Index;
                string[] values = new string[9];

                for (i = 0; i < 9; i++)
                {
                    values[i] = dataGridView1.Rows[place].Cells[i].Value.ToString();

                }
                SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = "UPDATE patients SET fname = '" + values[0] + "', lname = '" + values[1] + "',passport=" + values[2] + ",date_of_birth='" + values[3] + "',phone_1='" + values[4] + "', phone_2= '" + values[5] + "', address = '" + values[6] + "', email = '" + values[7] + "', physiotherapist = '" +comboBox1.SelectedItem.ToString() + "' where passport='" + values[2] + "'";
                n = mySqlCommand.ExecuteNonQuery();
                MessageBox.Show(n.ToString() + " row was updated");
                mySqlConnection.Close();
            }
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {
            int n = 0;
            
                SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "INSERT INTO physiotherapists Values('" +textBox2.Text + "')";
            n = mySqlCommand.ExecuteNonQuery();
            MessageBox.Show(n.ToString() + " row was inserted");
            mySqlConnection.Close();
        }

        private void TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
