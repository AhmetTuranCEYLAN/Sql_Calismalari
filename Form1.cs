using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql_Calismalari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Sql Çalışmaları\Sql_Calismalari\Ticari1.mdf;Integrated Security=True");
            con.Open();

            SqlCommand man = new SqlCommand("select * from department ", con);
            SqlDataReader sr = man.ExecuteReader();
            
            while (sr.Read())
            {

                listBox1.Items.Add(sr["id"].ToString() + "  " + sr["name"].ToString() + "  " + sr["description"].ToString());

                TreeNode tn = treeView1.Nodes.Add(sr["id"].ToString());
                TreeNode tr= tn.Nodes.Add(sr["name"].ToString());
                tr.Nodes.Add(sr["description"].ToString());
            }
            
            sr.Close();
        }


      
        private void button2_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Sql Çalışmaları\Sql_Calismalari\Ticari1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();



            SqlCommand cmd = new SqlCommand("select * from department", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

           
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Sql Çalışmaları\Sql_Calismalari\Ticari1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();



            SqlCommand cmd = new SqlCommand("select id, name from department where description like 'Er%'", con);
            
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }


      
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Sql Çalışmaları\Sql_Calismalari\Ticari1.mdf;Integrated Security=True");
            con.Open();

            SqlCommand com = new SqlCommand("select name from department where name like 'V%' ", con);
            SqlDataReader sr= com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sr);
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "Name"; 
            
            

        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            
            if (c.ShowDialog()==DialogResult.OK)
            {
                dataGridView1.ForeColor = c.Color;
                treeView1.ForeColor = c.Color;
                comboBox1.ForeColor = c.Color;
            }
        }


        
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\Sql Çalışmaları\Sql_Calismalari\Ticari1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand("select name,description from department where name like 'V%'", con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Description";
            
        }
    }
}
