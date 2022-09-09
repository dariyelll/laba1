using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n; //переменная для количества элементов массива

        private void button1_Click(object sender, EventArgs e)
        {
            // Выделение памяти под динамический массив.
            string[] arr = new string[n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    // Если одна или несколько ячеек таблицы пустые, выводим сообщение об ошибке.
                    if (dataGridView1.Rows[0].Cells[i].Value == null) throw new Exception("Заполните все ячейки!");
                    // Значения из таблицы помещаем в массив.
                    arr[i] = Convert.ToString(dataGridView1.Rows[0].Cells[i].Value);
                }
                string[] aNew = new string[n]; //создание нового массива для изменения
                for (int i = 0; i < n; i++) //заполнение массива 
                {
                    aNew[i]=arr[i];
                }
                aNew = DopClass.Ras(arr); //прибавление 1 к пятеричным числам

                
                for (int i = 0; i < aNew.Length; i++)
                {
                    // Заполняем таблицу новым массивом.
                    dataGridView1.Rows[0].Cells[i].Value = aNew[i];
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.RowCount = 1;
            // Устанавливаем количество колонок.
            dataGridView1.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                    dataGridView1.Rows[0].Cells[i].Value = 0;
            }

        }

       
        
        private void myKeyPress(object sender, KeyPressEventArgs e)
        {
            // Допустимыми являются только цифры, можно стирать символы в поле ввода, используя клавишу BackSpace.
            if (e.KeyChar >= '0' && e.KeyChar <= '9' ||  e.KeyChar == (char)Keys.Back) e.Handled = false;
            else e.Handled = true;
        }

        private void dataGridView1_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(myKeyPress);

        }
    }
}
