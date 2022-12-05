using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeList
{
    

    public partial class Form1 : Form
    {
        static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=DESKTOP-183SD6J\\SQLEXPRESS01";
        SqlConnection connection= new SqlConnection(connectionString);
        Hashtable employeeList = new Hashtable();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            employeeList.Clear();
            using (connection)
            {
                string queryString = "select EmployeeID, FirstName, LastName from Employees";
                SqlConnection connection = new SqlConnection(connectionString);
                //Adapter
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                //Reader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employeeList.Add(reader.GetInt32(0),reader.GetString(1) + " "+reader.GetString(2));
                    }
                }

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            textBox2.Text = (string)employeeList[Convert.ToInt32(str)];
        }
    }
}
