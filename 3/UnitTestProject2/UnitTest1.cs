using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using L3;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() //к пятеричным числам прибавляется 1
        {
            string[] mas = { "1", "15", "18", "22" };
            string[] ex = { "2", "15", "18", "23" };
            string[] actual = DopClass.Ras(mas);
            CollectionAssert.AreEqual(ex, actual,  "Ожидаемый результат не найден");
        }

        [TestMethod]
        public void TestMethod2() //проверка метода прибавления 1
        {
            char x = '1';
            char actual = DopClass.symb(x);
            char ex = '2';
            Assert.AreEqual(ex, actual, "Ожидаемый результат не найден");
        }


    }
}
