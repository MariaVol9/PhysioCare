using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diploma_Final
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select * from docs ";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
                comboBox1.Items.Add(mySqlDataReader[0].ToString());
            mySqlDataReader.Close();
            mySqlConnection.Close();
            listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_DoubleClick);
            listBox2.MouseDoubleClick += new MouseEventHandler(listBox2_DoubleClick);
            listBox3.MouseDoubleClick += new MouseEventHandler(listBox3_DoubleClick);
            if (radioButton4.Checked == true)
                richTextBox1.SelectionColor = Color.Black;
            if (radioButton5.Checked == true)
                richTextBox1.SelectionColor = Color.Green;
            if (radioButton6.Checked == true)
                richTextBox1.SelectionColor = Color.Red;
            if (radioButton6.Checked == true)
                richTextBox1.SelectionColor = Color.Blue;
            if(comboBox2.SelectedItem!=null)
            richTextBox1.SelectionFont = new Font("Verdana", int.Parse(comboBox2.SelectedItem.ToString()), FontStyle.Regular);
            else
                richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Regular);
           
         
           
        }


        Class1 c2 = new Class1();
        string path2 = @".rtf";
        string help = @"\";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int flag = 0;
        int flag2 = 0;
        string result2 = "";
        private void button1_Click(object sender, EventArgs e)
        {
          
            var path2 = @".rtf";
            string date99 = "";
            date99 = listBox3.SelectedItem.ToString();
            comboBox1.SelectedIndex = flag;
           string value4 = comboBox1.SelectedItem.ToString();
            string value = label2.Text;
           comboBox1.SelectedIndex = flag;
            string value3 = comboBox1.SelectedItem.ToString();
           var path = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\";           
           var fileName = String.Format("{0}{1}{2}{3}{4}{5}{6}",
            Path.GetFileNameWithoutExtension(path), Path.GetFileNameWithoutExtension(value), help, Path.GetFileNameWithoutExtension(date99), help, value4, Path.GetExtension(path2));
            var result3 = Path.Combine(Path.GetDirectoryName(path), fileName);
            DialogResult dialogResult = MessageBox.Show("Save?", "Cancel", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (flag2==0)
                richTextBox1.SaveFile(result3);
                if (flag2 == 1)
                    richTextBox1.SaveFile(result2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {




            var path = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\";
            string value = comboBox1.SelectedItem.ToString();
            // 

            var fileName = String.Format("{0}{1}{2}",
            Path.GetFileNameWithoutExtension(path), Path.GetFileNameWithoutExtension(value), Path.GetExtension(path2));
            var result = Path.Combine(Path.GetDirectoryName(path), fileName);

            richTextBox1.LoadFile(Path.Combine(Path.GetDirectoryName(path), fileName));
            flag = comboBox1.SelectedIndex;
            flag2 = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {


            richTextBox1.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string val = textBox2.Text;
       
         var path = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\";
            //var path2 = @".rtf";

            var fileName = String.Format("{0}{1}{2}",
                     Path.GetFileNameWithoutExtension(path), val, Path.GetExtension(path2));
            var result = Path.Combine(Path.GetDirectoryName(path), fileName);
            DialogResult dialogResult = MessageBox.Show("Save?", "Cancel", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                richTextBox1.SaveFile(Path.Combine(Path.GetDirectoryName(path), fileName));
                comboBox1.Items.Add(val);
            }
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();

            mySqlCommand.CommandText = "INSERT INTO docs Values('" + textBox2.Text + "')";
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sel;
            string del = comboBox1.SelectedItem.ToString();
            sel = comboBox1.SelectedIndex;
            comboBox1.Items.RemoveAt(sel);
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();

            mySqlCommand.CommandText = "Delete from docs where documents like '" + del + "'";
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        string strfile = "";
        string value3 = "";
        string value4 = "";
        string passport = "";
        DateTime apps = new DateTime();
        private void listBox2_DoubleClick(object sender, MouseEventArgs e)
        {
            flag2 = 1;
            string help=@"\";
            string value3 = strfile;
            string value4 = listBox2.SelectedItem.ToString();
            var fileName = String.Format("{0}{1}{2}",
            Path.GetFileNameWithoutExtension(value3), help,value4);
             var result = Path.Combine(Path.GetDirectoryName(value3), fileName);
            richTextBox1.LoadFile(Path.Combine(Path.GetDirectoryName(value3), fileName));
            result2 = result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            c2.Search(listBox1, textBox1, radioButton1, radioButton2, radioButton3);

        }
        string datenew = "";

        private void listBox1_DoubleClick(object sender, MouseEventArgs e)
        {
            listBox3.Items.Clear();
            foreach (var listBoxItem in listBox1.SelectedItems)

            {

                value3 = listBoxItem.ToString();
                value4 = value3.Substring(0, value3.IndexOf("-"));
                passport = value4;

            }
         
          c2.Addapps(datenew, listBox3, passport);
            label2.Text = value4;
           
            
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }
       

        private void button6_Click(object sender, EventArgs e)
        {





        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                richTextBox1.SelectionColor = Color.Black;
            if (radioButton5.Checked == true)
                richTextBox1.SelectionColor = Color.Green;
            if (radioButton6.Checked == true)
                richTextBox1.SelectionColor = Color.Red;
            if (radioButton7.Checked == true)
                richTextBox1.SelectionColor = Color.Blue;
            if (comboBox2.SelectedItem != null)
                richTextBox1.SelectionFont = new Font("Verdana", int.Parse(comboBox2.SelectedItem.ToString()), FontStyle.Regular);
            else
                richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Regular);
        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string datenew2 = "";
        private void listBox3_DoubleClick(object sender, MouseEventArgs e)
        {
            listBox2.Items.Clear();
            string h2 = "";
            foreach (var listBoxItem in listBox3.SelectedItems)

            {
                h2 = listBoxItem.ToString();
            }
            var path = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\";
            string path3 = passport;
            string help = @"\";

            var fileName = String.Format("{0}{1}{2}{3}",
             Path.GetFileNameWithoutExtension(path), path3, help, h2);
            var result = Path.Combine(Path.GetDirectoryName(path), fileName);
            strfile = result;
            DirectoryInfo d = new DirectoryInfo(result);
            FileInfo[] Files = d.GetFiles("*.rtf");

            var filtered = Files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
            foreach (var f in filtered)
            {

                listBox2.Items.Add(f.Name);

            }

       
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        string checkpass = "";
        private void Button7_Click(object sender, EventArgs e)
        {

            DateTime datecheck = new DateTime();

            string datecheck2 = "";


            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            try
            {
                datecheck = monthCalendar1.SelectionRange.Start.Date;
                datecheck2 = datecheck.ToString("yyyy-MM-dd");
                checkpass = "check" + passport;
                if (int.Parse(textBox3.Text) < 0 || int.Parse(textBox3.Text) > 10 || int.Parse(textBox4.Text) < 0 || int.Parse(textBox4.Text) > 10 || int.Parse(textBox5.Text) < 0 || int.Parse(textBox5.Text) > 10 || int.Parse(textBox6.Text) < 0 || int.Parse(textBox6.Text) > 10 || int.Parse(textBox7.Text) < 0 || int.Parse(textBox7.Text) > 10)
                    throw new Exception("no");
                else
                {
                    mySqlCommand.CommandText = "INSERT INTO " + checkpass + " Values('" + datecheck2 + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                    mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show("The check was updated");
                }
            }
            catch
            {
                MessageBox.Show("Please, check your input");

            }


        }



        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Chart2_Click(object sender, EventArgs e)
        {

        }
        private void CheckChart()
        {
            DateTime d12 = new DateTime();
            string d11 = "";                 

            foreach (var listBoxItem in listBox3.SelectedItems)

            {
                d11 = listBoxItem.ToString();
            }
            d12 = DateTime.Parse(d11);
            d11 = d12.ToString("dd-MM-yyyy");
            DateTime t1 = new DateTime();
            string t2 = "";

            string checkpass = "check" + passport+"("+d11+")";
            this.chart1.Series.Clear();
            
            this.chart1.Titles.Add("Patient check");
            Series series = this.chart1.Series.Add("Pain");
            series.ChartType = SeriesChartType.Spline;
            Series series2 = this.chart1.Series.Add("Sensitivity");
            series2.ChartType = SeriesChartType.Spline;
            Series series3 = this.chart1.Series.Add("Control");
            series3.ChartType = SeriesChartType.Spline;
            Series series4 = this.chart1.Series.Add("Movements");
            series4.ChartType = SeriesChartType.Spline;
            Series series5 = this.chart1.Series.Add("Flexibility");
            series5.ChartType = SeriesChartType.Spline;
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = " Select * from " + checkpass + "";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                t1 = DateTime.Parse(mySqlDataReader[0].ToString());
                t2 = t1.ToString("yyyy-MM-dd");
                pain = int.Parse(mySqlDataReader[1].ToString());
                sensitivity = int.Parse(mySqlDataReader[2].ToString());
                control = int.Parse(mySqlDataReader[3].ToString());
                movement = int.Parse(mySqlDataReader[4].ToString());
                flexibility = int.Parse(mySqlDataReader[5].ToString());
                series.Points.AddXY(t2, pain);
                series2.Points.AddXY(t2, sensitivity);
                series3.Points.AddXY(t2, control);
                series4.Points.AddXY(t2, movement);
                series5.Points.AddXY(t2, flexibility);
            }
            mySqlDataReader.Close();
            mySqlConnection.Close();


        }
        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        int pain = 0;
        int sensitivity = 0;
        int control = 0;
        int movement = 0;
        int flexibility = 0;

        private void Button8_Click(object sender, EventArgs e)
        {
            
        }

        private void TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                richTextBox1.SelectionColor = Color.Black;
            if (radioButton5.Checked == true)
                richTextBox1.SelectionColor = Color.Green;
            if (radioButton6.Checked == true)
                richTextBox1.SelectionColor = Color.Red;
            if (radioButton6.Checked == true)
                richTextBox1.SelectionColor = Color.Blue;
            if (comboBox2.SelectedItem != null)
                richTextBox1.SelectionFont = new Font("Verdana", int.Parse(comboBox2.SelectedItem.ToString()), FontStyle.Regular);
            else
                richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Regular);
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click_1(object sender, EventArgs e)
        {

        }

        private void Button6_Click_2(object sender, EventArgs e)
        {

        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click_1(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show(this);
        }

        private void Button6_Click_3(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
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

        private void Button12_Click(object sender, EventArgs e)
        {
            SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
            mySqlCommand2.CommandText = " Select arrival from arr_check where arrival=(select MAX(arrival) from arr_check where passport like " + passport + ")";
            mySqlConnection2.Open();

            SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
            while (mySqlDataReader2.Read())
            {
                datenew = mySqlDataReader2[0].ToString() + "\n";
                datenew2 = datenew2.Substring(0, 10);

            }
            mySqlDataReader2.Close();
            mySqlConnection2.Close();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                richTextBox1.SelectionColor = Color.Black;
            if (radioButton5.Checked == true)
                richTextBox1.SelectionColor = Color.Green;
            if (radioButton6.Checked == true)
                richTextBox1.SelectionColor = Color.Red;
            if (radioButton7.Checked == true)
                richTextBox1.SelectionColor = Color.Blue;
            if (comboBox2.SelectedItem != null)
                richTextBox1.SelectionFont = new Font("Verdana", int.Parse(comboBox2.SelectedItem.ToString()), FontStyle.Regular);
            else
                richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Regular);
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                richTextBox1.SelectionColor = Color.Black;
            if (radioButton5.Checked == true)
                richTextBox1.SelectionColor = Color.Green;
            if (radioButton6.Checked == true)
                richTextBox1.SelectionColor = Color.Red;
            if (radioButton7.Checked == true)
                richTextBox1.SelectionColor = Color.Blue;
            if (comboBox2.SelectedItem != null)
                richTextBox1.SelectionFont = new Font("Verdana", int.Parse(comboBox2.SelectedItem.ToString()), FontStyle.Regular);
            else
                richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Regular);
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                richTextBox1.SelectionColor = Color.Black;
            if (radioButton5.Checked == true)
                richTextBox1.SelectionColor = Color.Green;
            if (radioButton6.Checked == true)
                richTextBox1.SelectionColor = Color.Red;
            if (radioButton7.Checked == true)
                richTextBox1.SelectionColor = Color.Blue;
            if (comboBox2.SelectedItem != null)
                richTextBox1.SelectionFont = new Font("Verdana", int.Parse(comboBox2.SelectedItem.ToString()), FontStyle.Regular);
            else
                richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Regular);
        }

        private void Button13_Click_1(object sender, EventArgs e)
        {
            CheckChart();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button14_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";

            textBox5.Text = "";

            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void TextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Button15_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
                richTextBox1.SelectionFont = new Font("Verdana", int.Parse(comboBox2.SelectedItem.ToString()), FontStyle.Bold);
            else
                richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
                richTextBox1.SelectionFont = new Font("Verdana", int.Parse(comboBox2.SelectedItem.ToString()), FontStyle.Regular);
            else
                richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Regular);
        }
    }
}
