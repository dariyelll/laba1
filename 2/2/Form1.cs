using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double SummaRyada( double x, double e, out int n)
        {
            if (x <= -1 || x >= 1) throw new ArgumentException("Аргумент Х задан неверно");
            if (e<=0 || e>= 1) throw new ArgumentException("Точность задана неверно");
            double S=0, U=x, Up=0;
            n = 1;
            while (Math.Abs(U - Up) > e)
            {
                S += U;
                
                Up = U;
                U *= (x * x * (2 * n - 1)) / (2 * n * (2 * n + 1));
                n++;
            }

            return (Math.PI / 2 - S);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count;
            double X, eps;
            label3.Text = "";
            try {
                eps = Convert.ToDouble(textBoxEps.Text);
                X = Convert.ToDouble(textBoxX.Text);
                double Summ = SummaRyada(X, eps, out count);
                label3.Text = "Arccos(x) = " + Math.Acos(X) + "\nСумма ряда = " + Summ + "\nКоличество членов ряда " + count;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

       

        private void textBoxEps_TextChanged(object sender, EventArgs e)
        {
            label3.Text = ""; //очистка ответа при изменении значений
            if (textBoxX.Text != "" && textBoxEps.Text != "") button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void textBoxEps_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (e.KeyChar == '.') e.KeyChar=',';
            if (e.KeyChar >= '-' && text.IndexOf('-') == -1) return;
            if (e.KeyChar == ',' && text.IndexOf(',') == -1) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.KeyChar = '\0';
        }




        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.AntiqueWhite;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = this.BackColor;
        }
    }


}
