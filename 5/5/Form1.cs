using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n; //переменная для количества элементов массива
        Random r = new Random();

        /// <summary>
        /// Метод поиска элементов, кратных своему порядковому номеру.
        /// </summary>   
        /// <param name="a">массив для поиска кратных</param>
        /// <returns>произведение элементов, кратных своему порядковому номеру</returns>
        List<int> Multiplication(int[] a)
        {
            List<int> multi = new List<int>();
            // Первый элемент массива всегда будет кратен своему порядковому номеру, тк любое число делится на 1, поэтому начинаем со второго
            multi.Add(a[0]);
            multi.Add(1);
            
            for (int i = 1; i < a.Length; i++)
            {
                // Если элемент кратен своему порядковому номеру, добавить в список и посчитать общее количество.
                if (a[i] % (i + 1) == 0)
                {
                    multi[0] *= a[i];
                    multi[1] += 1;
                }
            }
            return multi;
        }

        /// <summary>
        /// Кнопка "Вычислить" - метод удаления элементов, кратных своему порядковому номеру.
        /// </summary>
        /// <param name="sender">указатель на button1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Очистка поля результата.
            label2.Text = "";
            // Выделение памяти под динамический массив.
            int[] a = new int[n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    // Если одна или несколько ячеек таблицы пустые, выводим сообщение об ошибке.
                    if (dataGridView1.Rows[0].Cells[i].Value == null) throw new Exception("Заполните все ячейки!");
                    // Значения из таблицы помещаем в массив.
                    a[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);
                }
                // Вызов метода для поиска элементов, кратных своему порядковому номеру.
                List<int> multi = Multiplication(a);

                // Новый массив без элементов, кратных своему порядковому номеру.
                int[] aNew = new int[a.Length - multi[1]];
                // Номер текущего элемента нового массива.
                int j = 0;

                for (int i = 1; i < n; i++)
                {
                    // Если элемент является кратным своему порядковому номеру, пропускаем его.
                    if (a[i] % (i+1) == 0) continue;

                    // Заполняем новый массив элементами старого.
                    aNew[j] = a[i];
                    // Удаление элементов производится путём сдвига вперёд.
                    j++;
                }

                // Устанавливаем количество колонок без учёта элементов, кратных своему порядковому номеру.
                dataGridView1.ColumnCount = aNew.Length;
                for (int i = 0; i < aNew.Length; i++)
                {
                    // Заполняем таблицу новым массивом.
                    dataGridView1.Rows[0].Cells[i].Value = aNew[i];
                }

                if (multi[1] == 1)
                    label2.Text = "Нет элементов, кратных заданному числу";
                else
                {

                    label2.Text = "Произведение элементов массива, кратных своему порядковому номеру = " + multi[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Метод интерактивного изменения способа ввода массива.
        /// </summary>
        /// <param name="sender">указатель на radioButton1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Очистка поля результата.
            label2.Text = "";
            n = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.RowCount = 1;
            // Устанавливаем количество колонок.
            dataGridView1.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                // Строка заголовков столбцов.
                dataGridView1.Columns[i].Name = (i+1).ToString();
                if (radioButton2.Checked)
                    // Заполняем таблицу случайными значениями.
                    dataGridView1.Rows[0].Cells[i].Value = r.Next(50, 101).ToString();
                else
                    dataGridView1.Rows[0].Cells[i].Value = 0;
            }

        }

        /// <summary>
        /// Метод интерактивного изменения размера таблицы.
        /// </summary>
        /// <param name="sender">указатель на numericUpDown1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(numericUpDown1.Value);
            // Устанавливаем количество колонок.
            dataGridView1.ColumnCount = n;

            for (int i = 0; i < n; i++)
            {
                // Строка заголовков столбцов.
                dataGridView1.Columns[i].Name = (i+1).ToString();
                // Новые ячейки заполняем нулями.
                if (dataGridView1.Rows[0].Cells[i].Value == null) dataGridView1.Rows[0].Cells[i].Value = 0;
            }

        }

        /// <summary>
        /// Событие проверки нажимаемых клавиш при отображении таблицы для редактирования ячейки.
        /// </summary>
        /// <param name="sender">указатель на dataGridView1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(myKeyPress);
        }

        /// <summary>
        /// Метод контроля вводимых данных в таблицу.
        /// </summary>
        /// <param name="sender">указатель на dataGridView1</param>
        /// <param name="e">дополнительный аргумент</param>

        private void myKeyPress(object sender, KeyPressEventArgs e)
        {
            // Допустимыми являются только цифры и минус, можно стирать символы в поле ввода, используя клавишу BackSpace.
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back) e.Handled = false;
            else e.Handled = true;
        }


    }
}