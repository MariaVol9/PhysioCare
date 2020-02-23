using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diploma_Final
{
    public partial class Form5 : Form
    {

        public Form5()
        {
            InitializeComponent();
            label2.Text = "";
            label4.Text = "";
            radioButton1.Checked = true;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Image", typeof(byte[]));
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "Select * from inv_main;";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            string stra2 = "";
         var path = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\images\";
            var path2 = @".jpg";
            string help = @"\";
            DataRow dr = dt.NewRow();
            while (mySqlDataReader.Read())
            {
                stra2 = mySqlDataReader[0].ToString();
                dr[0] = stra2;
                var fileName = String.Format("{0}{1}{2}{3}",
             Path.GetFileNameWithoutExtension(path), Path.GetFileNameWithoutExtension(help), Path.GetFileNameWithoutExtension(stra2), Path.GetExtension(path2));
                var result = Path.Combine(Path.GetDirectoryName(path), fileName);
                if (File.Exists(result))
                {
                    Image img = Image.FromFile(result);
                    img = resizeImage(img, new Size(70, 70));
                    dr["Image"] = imageToByteArray(img);
                }

                dt.Rows.Add(dr);
                dr = dt.NewRow();
            }
            mySqlDataReader.Close();
            mySqlConnection.Close();
            dataGridView1.DataSource = dt;
            string index1;
            int index2;
            string pathnew = "";
            SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
            mySqlCommand2.CommandText = "Select * from paths;";
            mySqlConnection2.Open();
            SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();

            while (mySqlDataReader2.Read())
            {
                index1 = mySqlDataReader2[0].ToString();
                index2 = int.Parse(index1);
                pathnew = mySqlDataReader2[1].ToString();

                Image img2 = Image.FromFile(pathnew);
                img2 = resizeImage(img2, new Size(70, 70));
                dataGridView1.Rows[index2].Cells[1].Value = imageToByteArray(img2);
            }
            mySqlDataReader2.Close();
            mySqlConnection2.Close();

            SqlConnection mySqlConnection3 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand3 = mySqlConnection3.CreateCommand();
            mySqlCommand3.CommandText = "Select * from paths;";
            mySqlConnection3.Open();
            SqlDataReader mySqlDataReader3 = mySqlCommand3.ExecuteReader();

            while (mySqlDataReader3.Read())
            {
                index1 = mySqlDataReader3[0].ToString();
                index2 = int.Parse(index1);
                pathnew = mySqlDataReader3[1].ToString();

                Image img2 = Image.FromFile(pathnew);
                img2 = resizeImage(img2, new Size(70, 70));
                dataGridView1.Rows[index2].Cells[1].Value = imageToByteArray(img2);
            }
            mySqlDataReader3.Close();
            mySqlConnection3.Close();


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Code", typeof(int));
            dt2.Columns.Add("Name", typeof(string));
            dt2.Columns.Add("Company", typeof(string));
            dt2.Columns.Add("Size", typeof(string));
            dt2.Columns.Add("Price", typeof(string));
            dt2.Columns.Add("Number", typeof(int));
            dt2.Columns.Add("Comments", typeof(string));
            dt2.Columns.Add("Purchase Date", typeof(string));
            dt2.Columns.Add("Category", typeof(string));
            DataRow dr2 = dt.NewRow();
            dr2 = dt.NewRow();
            dataGridView2.DataSource = dt2;
            dataGridView1.MouseDoubleClick += new MouseEventHandler(dataGridView1_DoubleClick);

            SqlConnection mySqlConnection4 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand4 = mySqlConnection4.CreateCommand();
            mySqlCommand4.CommandText = " Select * from inv_main ";
            mySqlConnection4.Open();
            SqlDataReader mySqlDataReader4 = mySqlCommand4.ExecuteReader();
            while (mySqlDataReader4.Read())
                comboBox1.Items.Add(mySqlDataReader4[0].ToString());
            mySqlDataReader4.Close();
            mySqlConnection4.Close();
        }
        Class1 c3 = new Class1();
        string table_inv = "";
        string newst = "";
        int strn;
        string value = "";
        string strpath = "";
        string category2 = "";
        int flag = 0;
        DateTime pur_date = DateTime.Today;
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void Inventory(DataTable a)
        {
            int num=0;
            int num2 = 0;
            int sum = 0;
            int sum2 = 0;
            int sum3 = 0;
            int j = 6;
            int i = 0;
            DateTime d12 = new DateTime();
            string d11 = "";
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Code", typeof(int));
            dt2.Columns.Add("Name", typeof(string));
            dt2.Columns.Add("Company", typeof(string));
            dt2.Columns.Add("Size", typeof(int));
            dt2.Columns.Add("Price", typeof(int));
            dt2.Columns.Add("Number", typeof(int));
            dt2.Columns.Add("Comments", typeof(string));
            dt2.Columns.Add("Purchase Date", typeof(string));
            dt2.Columns.Add("Category", typeof(string));

            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            if (flag == 0)
            {
                j = 7;
                //  mySqlCommand.CommandText = "Select * from inventory ";
                  mySqlCommand.CommandText = "Select * from "+table_inv+" ";
            }
            if (flag == 1)
            {
                j = 9;
                mySqlCommand.CommandText = "Select * from  inventory";
            }
            
               
            
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            string[] table1 = new string[10];

            DataRow dr2 = dt2.NewRow();

            while (mySqlDataReader.Read())
            {
                for (i = 0; i < j; i++)
                {

                    table1[i] = mySqlDataReader[i].ToString() + "\n";
                    dr2[i] = table1[i];
                    if (i == 7)
                    {
                        d12 = DateTime.Parse(table1[7]);
                        d11 = d12.ToString("dd/MM/yyyy");
                        table1[7] = d11;
                    }

                }
               
                dt2.Rows.Add(dr2);
                dr2 = dt2.NewRow();
            }
        
            mySqlDataReader.Close();
            SqlDataReader mySqlDataReader2 = mySqlCommand.ExecuteReader();

            while (mySqlDataReader2.Read())
            {
                num = int.Parse(mySqlDataReader2[5].ToString());
                num2 += num;
                sum = int.Parse(mySqlDataReader2[4].ToString());
                sum2 = num * sum;
                sum3 += sum2;
            }
            mySqlDataReader2.Close();
            mySqlConnection.Close();
            dataGridView2.DataSource = dt2;
            label2.Text = num2.ToString();
            label4.Text = sum3.ToString();
           // return table_inv;
        }


        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int place;
            //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //{
                int n;
                //place = row.Index;

               // string category = dataGridView1.Rows[place].Cells[0].Value.ToString();
               string category = textBox1.Text;

                SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = "INSERT INTO inv_main Values('" + textBox1.Text + "')";
                n = mySqlCommand.ExecuteNonQuery();
                comboBox1.Items.Add(category);
                MessageBox.Show("Inserted  " + n.ToString() + " row");
                mySqlConnection.Close();
            SqlConnection mySqlConnection3 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand3 = mySqlConnection3.CreateCommand();
            mySqlConnection3.Open();
           // mySqlCommand3.CommandText = "create table " + tablename + "(docs varchar(50))";

            mySqlCommand3.CommandText = "create table " + textBox1.Text + "(Code int,Name varchar(50),Company varchar(50),Size int,Price int,Number int,Comments varchar(50))";
            mySqlCommand3.ExecuteNonQuery();
            mySqlConnection3.Close();
            //}

        }
        private void dataGridView1_DoubleClick(object sender, MouseEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {

                    table_inv = cell.Value.ToString();
                    DataTable dt = new DataTable();
                    flag = 0;
                    Inventory(dt);
                    newst = cell.Value.ToString();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int i;
            string strcode = "";
            string[] values77 = new string[10];
            DateTime datenew5 = DateTime.Today;
            string datenew7 = datenew5.ToString("yyyy-MM-dd");
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                strcode = row.Cells[0].Value.ToString();
                strn = int.Parse(strcode);
            }
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {

                int n;
                
                int place = row.Index;
                

                for (i = 0; i < 7; i++)
                {
                    values77[i] = dataGridView2.Rows[place].Cells[i].Value.ToString();

                }
            }
            int numnew = int.Parse(textBox3.Text);
                SqlConnection mySqlConnection3 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand3 = mySqlConnection3.CreateCommand();

            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

            SqlConnection mySqlConnection4 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand4 = mySqlConnection4.CreateCommand();

            /*mySqlCommand.CommandText = " select Code from inventory where Code=" + strn + "";
            mySqlConnection.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
          
            while (mySqlDataReader.Read())
            {
            */
                mySqlCommand3.CommandText = " insert into inventory  values('" + values77[0] + "','" + values77[1] + "','" + values77[2] + "','" + values77[3] + "','" + values77[4] + "','" + textBox3.Text + "','" + values77[6] + "','" + datenew7 + "','" + values77[8] + "'," + value + ")";
                
                mySqlConnection3.Open(); 
                mySqlCommand3.ExecuteNonQuery();
                mySqlConnection3.Close();

                mySqlCommand4.CommandText = " update " + newst + "  set Number=Number-"+numnew+" where Code= " + strn + "";
                mySqlConnection4.Open();
                mySqlCommand4.ExecuteNonQuery();
                mySqlConnection4.Close();
          //  }
          //  mySqlDataReader.Close();
           // mySqlConnection.Close();
        }
        string passport;

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            c3.Search(listBox1, textBox2, radioButton1, radioButton2, radioButton3);
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int place2 = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\Users\ivanf\Desktop\Diploma Final3\Diploma Final\bin\Debug\images";
            openFileDialog1.Filter = "Image Files  (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strpath = openFileDialog1.FileName;
            }
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                place2 = row.Index;
                Image img = Image.FromFile(strpath);
                img = resizeImage(img, new Size(100, 100));
                dataGridView1.Rows[place2].Cells[1].Value = imageToByteArray(img);

            }
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = "INSERT INTO paths Values(" + place2 + ",'" + strpath + "')";
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

        }

        private void Statistics_purch()
        {
            int num = 0;
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {               
                
                    num += int.Parse(row.Cells[5].Value.ToString());
                    sum += int.Parse(row.Cells[4].Value.ToString());                
            }
            label2.Text = num.ToString();
            label4.Text = sum.ToString();
            }
        private void Button4_Click(object sender, EventArgs e)
        {   int code_random = 0;
            Random rnd = new Random();
            code_random = rnd.Next(10000, 99999);
            SqlConnection mySqlConnection3 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand3 = mySqlConnection3.CreateCommand();
            mySqlConnection3.Open();
            mySqlCommand3.CommandText = " select Code from inventory ";
       
            SqlDataReader mySqlDataReader3 = mySqlCommand3.ExecuteReader();
            while (mySqlDataReader3.Read())
            {

                if (code_random == int.Parse(mySqlDataReader3[0].ToString()))
                {                  
                    code_random = rnd.Next(10000, 99999);
                }
            }
            mySqlDataReader3.Close();
            mySqlConnection3.Close();
                int place;
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
               
                int n;
                int i;
                place = row.Index;
                string[] values = new string[7];
                
                for (i = 0; i < 7; i++)
                {
                    values[i] = dataGridView2.Rows[place].Cells[i].Value.ToString();
                    
                }
                SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();



                mySqlCommand.CommandText = "INSERT INTO " + newst + " Values(" + code_random + ",'" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] + "','" + values[6] + "')";
                n = mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted  " + n.ToString() + " row");
                mySqlConnection.Close();

              /*  SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
                SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
                mySqlConnection2.Open();
                mySqlCommand2.CommandText = "INSERT INTO inventory  (Code,Name,Company,Size,Price,Number,Comments,type) Values(" +code_random+ ",'" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "',0,'" + values[6] + "','"+newst+"')";
              
                mySqlCommand2.ExecuteNonQuery();
                
                mySqlConnection2.Close();*/
               
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var listBoxItem in listBox1.SelectedItems)
            {
                value = listBoxItem.ToString();
                value = value.Substring(0, value.IndexOf("-"));
               
            }
        }

        

        private void Button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            flag = 1;
            Inventory(dt);
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            flag = 1;
            Inventory(dt);
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            int i;
            int num;
            int num2 = 0;
            int sum;
            int sum2;
            int sum3 = 0;
            int j = 7;
            DateTime d12 = new DateTime();
            string d11 = "";
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Code", typeof(int));
            dt2.Columns.Add("Name", typeof(string));
            dt2.Columns.Add("Company", typeof(string));
            dt2.Columns.Add("Size", typeof(int));
            dt2.Columns.Add("Price", typeof(int));
            dt2.Columns.Add("Number", typeof(int));
            dt2.Columns.Add("Comments", typeof(string));
            dt2.Columns.Add("Purchase Date", typeof(string));
            dt2.Columns.Add("Category", typeof(string));

            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlConnection mySqlConnection2 = new SqlConnection("server=(local)\\SQLEXPRESS;database=1;Integrated Security=SSPI;");
            SqlCommand mySqlCommand2 = mySqlConnection2.CreateCommand();
            category2 = comboBox1.SelectedItem.ToString();
            mySqlCommand.CommandText = "select * from " + category2 + "";
            mySqlCommand2.CommandText = "select * from inventory";
            mySqlConnection.Open();
            mySqlConnection2.Open();
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            string[] table1 = new string[10];

            DataRow dr2 = dt2.NewRow();

            while (mySqlDataReader.Read())
            {
                SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                while (mySqlDataReader2.Read())
                {
                    if (int.Parse(mySqlDataReader[0].ToString()) == int.Parse(mySqlDataReader2[0].ToString()))
                    {
                        for (i = 0; i < 9; i++)
                        {

                            table1[i] = mySqlDataReader2[i].ToString() + "\n";
                            if (i == 7) { 
                                d12 = DateTime.Parse(table1[7]);
                                d11 = d12.ToString("dd/MM/yyyy");
                                table1[7] = d11;
                                }
                            dr2[i] = table1[i];


                        }
                        dt2.Rows.Add(dr2);
                   dr2 = dt2.NewRow();
                    }

                    

                }
                
                mySqlDataReader2.Close();
            }
                mySqlDataReader.Close();
                /* SqlDataReader mySqlDataReader3 = mySqlCommand.ExecuteReader();

                 while (mySqlDataReader3.Read())
                 {
                     num = int.Parse(mySqlDataReader3[5].ToString());
                     num2 += num;
                     sum = int.Parse(mySqlDataReader3[4].ToString());
                     sum2 = num * sum;
                     sum3 += sum2;
                 }
                 mySqlDataReader3.Close();*/
                mySqlConnection.Close();
                dataGridView2.DataSource = dt2;
                label2.Text = num2.ToString();
                label4.Text = sum3.ToString();
                // Statistics_purch();
            
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(this);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show(this);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show(this);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show(this);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show(this);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}