using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeGenerator_UI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
       
        }

        // sequential button
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        // parallel button
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_list.Items.Add(new KeyValuePair<string, string>("1-1.000.000", "0"));
            comboBox_list.Items.Add(new KeyValuePair<string, string>("1-10.000.000", "1"));
            comboBox_list.Items.Add(new KeyValuePair<string, string>("1.000.000-2.000.000", "2"));
            comboBox_list.Items.Add(new KeyValuePair<string, string>("10.000.000-20.000.000", "3"));

            comboBox_list.DisplayMember = "key";
            comboBox_list.ValueMember = "value";
        }

        public List<long> GetPrimesSequential(long first, long last)
        {
            return null;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
