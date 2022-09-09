using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
   public class DopClass
    {
        public static string[] Ras(string[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                string result = "";//переменная для временного хранения ответа
                char[] arr = a[i].ToCharArray();
                int schk = 0;//счетчик символов больших 4
                int schk1 = 0;//счетчик символов равных 0
                for (int j = 0; j < arr.Length; j++)
                {
                    if (Convert.ToInt32(arr[j].ToString()) > 4) //проверка: ищем символы больше 4
                        schk += 1;
                }
                if (schk > 0) result = a[i];
                    if (schk ==0) //
                {
                    for (int j = arr.Length - 1; j >= 0; j--) //перебираем символы с конца
                    {
                        arr[j] = symb(arr[j]); //применяем дополнительную функцию
                        if (arr[j] != '0')
                            break; // если символ был меньше четырех - выходим из цикла, остальные менять не нужно
                        else
                            schk1 += 1; //считаем сколько символов = 0
                    }
                    result = string.Concat(arr); //соединяем символы в строку
                    if (schk1 == arr.Length)
                        result = "1" + result; //если все они = 0, добавляем вперед 1
                }
                a[i]=result;
            }
            return a;
        }

        public static char symb(char x) //дополнительная функция 
        {
            //если символ = 4, то он заменяется на 0, чтобы к следующему прибавили 1
            //если символ < 4, то он увеличивается на 1
            char y = '0';
            if (x != '4')
                y = Convert.ToChar(Convert.ToInt32(x) + 1);
            return y;
        }

    }
}
