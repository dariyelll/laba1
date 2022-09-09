using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b; //переменный углов для ввода
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            if (radioButton1.Checked) //если в градусах
            {
                a *= Math.PI / 180; //преобразуем в радианы
                b *= Math.PI / 180;
            }

            if (a >= 0 && a <= 2 * Math.PI && b >= 0 && b <= 2 * Math.PI) //проверка на допустимые значения
            {

                double Z1, Z2; //перем енные результата
                Z1 = Math.Cos(a) + Math.Sin(a) + Math.Cos(3 * a) + Math.Sin(3 * a);
                Z2 = 2 * Math.Sqrt(2) * Math.Cos(a) * Math.Sin((Math.PI / 4) + 2 * a);
                label3.Text = "Z1 = " + Z1 + "\nZ2 = " + Z2; //вывод результата
            }
            else //при ошибки выводить сообщение
            {
                MessageBox.Show("Углы введены неправильно!", "Ошибка");
            }
        }

        private void Form1_TextChanged(object sender, EventArgs e) //блокирование кнопки "вычислить" при пустых значениях a, b
        {
            label3.Text = ""; //очистка ответа при изменении значений
            if (textBox1.Text != "" && textBox2.Text != "") button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //ограничение на ввод (только цифры, запятая и клавиша BackSpasce)
        {
            string text = ((TextBox)sender).Text;
            if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (e.KeyChar == ',' && text.IndexOf(',') == -1) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.KeyChar = '\0';
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //очистка ответа при изменении кнопок выбора
        {
            label3.Text = "";
        }

        private void label3_MouseEnter(object sender, EventArgs e) //установка цвета при наведении мыши
        {
            label3.BackColor = Color.LightCoral;
        }

        private void label3_MouseLeave(object sender, EventArgs e)  //снятие цвета без наведения мыши
        {
            label3.BackColor = this.BackColor;
        }

      
    }
}
