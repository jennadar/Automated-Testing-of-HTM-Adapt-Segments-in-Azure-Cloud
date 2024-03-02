using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [DataRow(100, 10, 10)]
        [DataRow(1000, 10, 100)]
        [DataRow(21, 15, 1.4)]  
        public void MyFirstUnitTestMethod(int a, int b, double expectedResult)
        {
            MyLib lib = new MyLib();

            var result = lib.Divide(a, b);

            Assert.IsTrue(result == expectedResult);
        }

        [TestMethod]
        public void MyFirstUnitTestMethod2()
        {
            MyLib lib = new MyLib();

            var res = lib.Multiple(100, 2123);

            Assert.IsTrue(res == 212300);
        }
    }
}
