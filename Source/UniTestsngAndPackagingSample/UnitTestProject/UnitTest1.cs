using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;

namespace UnitTestProjectNamespace
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory("prod")]
        [TestCategory("Cat2")]
        [TestCategory("MulTests")]
        [TestMethod]
        public void MultipleTest()
        {
            MyLib lib = new MyLib();

            var res = lib.Multiple(1,2);

            Assert.AreEqual(2, res);
        }

        [TestCategory("prod")]
        [TestMethod]
        [DataRow(1, 2, 3 )]
        [DataRow(2, 2, 4)]
        [DataRow(10, 200, 210)]
        [DataRow(7, 20, 27)]
        [TestCategory("SumTests")]
        [TestCategory("Cat1")]
        public void SumTest(int a, int b, int expected)
        {
            MyLib lib = new MyLib();

            var res = lib.Sum(a, b);

            Assert.AreEqual(expected, res);
        }

        [TestCategory("Cat1")]
        [TestCategory("DivideTests")]
        [TestMethod]
        public void DivideTest()
        {
            MyLib lib = new MyLib();
           
            var res = lib.Divide(1, 2);

            Assert.AreEqual(0.5, res);
        }

        [TestMethod]
        public void TestHelloStudents()
        {
            HelloStudents.MyAlgorithm a = new HelloStudents.MyAlgorithm();
            Assert.IsTrue(a.Calculate(100) == 1.0);
        }
    }
}
