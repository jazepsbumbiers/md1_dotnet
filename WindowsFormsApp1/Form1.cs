using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            LogToFile.LogWrite("Inicializeta forma...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double skaitlis1 = double.Parse(textBox1.Text);
            double skaitlis2 = double.Parse(textBox2.Text);
            double rezultats = (skaitlis1 / 100) * skaitlis2;

            label3.Visible = true;
            label3.Text = $"{skaitlis1} procenti no {skaitlis2} ir = {rezultats}!";
        
            LogToFile.LogWrite($"Veikta aprekinasana: {skaitlis1} procenti no {skaitlis2} ir = {rezultats}!");
        }
        
        private void textBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(this.textBox1, "Ievadi procentus");

        }

        private void textBox2_MouseClick_1(object sender, MouseEventArgs e)
        {
            ToolTip toolTip2 = new System.Windows.Forms.ToolTip();
            toolTip2.SetToolTip(this.textBox2, "Ievadi skaitli no kura gribi iegut procentus");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                
                MessageBox.Show("Ievadit var tikai skaitli!");                
                LogToFile.LogWrite($"Kludaina ievade, var ievadit tikai skaitlus, ievadita vertiba: {textBox1.Text}");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                
                MessageBox.Show("Ievadit var tikai skaitli!");
                LogToFile.LogWrite($"Kludaina ievade, var ievadit tikai skaitlus, ievadita vertiba: {textBox2.Text}");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);

            }
        }
    }

}