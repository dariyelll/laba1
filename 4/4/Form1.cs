using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            from2Closed = true;
        }
        int sec = 0;
        int wR = 40, hR = 40;
        int x = 2, y = 80;
        int dx = 2, dy = 80;
        int change;
        enum STATUS_LR { Left, Right };  //направления движения
        enum STATUS_UD { Up, Down };  //направления движения

        STATUS_LR flag_LR;		//флаг изменения направления движения
        STATUS_UD flag_UD;

        SolidBrush brush = new SolidBrush(Color.White); // кисть
        SolidBrush brush1 = new SolidBrush(Color.White);
        SolidBrush brush2 = new SolidBrush(Color.Black);
        Rectangle rc;

        Form2 form2;

        public int MySpeed //свойство скорости
        {
            get
            {

                return (100 - timer1.Interval);
            }
            set
            {
                timer1.Interval = 100 - value;
            }
        }

        public Color MyColor1//свойство цвет
        {
            get
            {
                return brush1.Color;
            }
            set
            {
                brush1.Color = value;
            }
        }
        public Color MyColor2//свойство цвет
        {
            get
            {
                return brush2.Color;
            }
            set
            {
                brush2.Color = value;
            }
        }

        public bool DirectionMovement //движение
        {
            get;
            set;
        }
        public bool from2Closed
        {
            get;
            set;
        }



       

        // мое
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            sec++;  // секунды
            rc = new Rectangle(x, y -20, wR, hR); // размер прямоугольной области

            this.Invalidate(rc, true);      // вызываем прорисовку области            

            if (DirectionMovement == true)
            {
                x = (this.ClientSize.Width / 2) - 60;
                if (flag_UD == STATUS_UD.Up) // движение вверх
                    y -= dy;
                if (flag_UD == STATUS_UD.Down) // движение вниз
                    y += dy;
                if (y >= (this.ClientSize.Height - hR)) // если достигли нижнего края формы
                {
                    flag_UD = STATUS_UD.Up; // меняем статус движения на верх
                    change = wR;
                    wR = hR;
                    hR = change;
                    brush = brush2;
                }
                else
                if (y <= 1) // если достигли верхнего края формы
                {
                    flag_UD = STATUS_UD.Down;    // меняем статус движения на вниз
                    change = wR;
                    wR = hR;
                    hR = change;
                    brush = brush1;
                }
            }
            else
            {
                y = 100;
                if (flag_LR == STATUS_LR.Left) // движение влево
                    x -= dx;
                if (flag_LR == STATUS_LR.Right) // движение вправо
                    x += dx;
                if (x >= (this.ClientSize.Width - wR)) // если достигли правого края формы
                {
                    flag_LR = STATUS_LR.Left; // меняем статус движения на левый
                    change = wR;
                    wR = hR;
                    hR = change;
                    brush = brush2;
                }
                else
                if (x <= 1) // если достигли левого края формы
                {
                    flag_LR = STATUS_LR.Right;    // меняем статус движения на правый
                    change = wR;
                    wR = hR;
                    hR = change;
                    brush = brush1;
                }
            }
            rc = new Rectangle(x, y-20, wR, hR); // новая прямоугольная область
            this.Invalidate(rc, true);  // вызываем прорисовку этой области

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (from2Closed == true)
            {
                timer1.Start();
                button1.Text = "Стоп";
                form2 = new Form2();
                form2.Owner = this;//передача управления 2 форме
                form2.Show();//отображение 2 формы
                from2Closed = false;

            }
        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.MyColor1 = MyColor1;
            Properties.Settings.Default.MySpeed1 = MySpeed;
            Properties.Settings.Default.Movement = DirectionMovement;
            Properties.Settings.Default.Save();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(brush, rc);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            MyColor1 = Properties.Settings.Default.MyColor1;
            MyColor2 = Properties.Settings.Default.MyColor2;
            DirectionMovement = Properties.Settings.Default.Movement;

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Пуск")//при нажатии на кнопку с надписью "Пуск", изменениее на "Стоп"
            {
                button1.Text = "Стоп";
                timer1.Start();//включение таймера
            }
            else
            {
                button1.Text = "Пуск";
                timer1.Stop();//выключение таймера
            }
        }
    }
}
