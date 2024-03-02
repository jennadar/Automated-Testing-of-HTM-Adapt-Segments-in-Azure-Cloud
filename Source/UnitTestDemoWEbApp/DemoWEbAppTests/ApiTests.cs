using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestDemoWEbApp.Controllers;

namespace DemoWEbAppTests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void GetTest()
        {
            var controller = new WeatherForecastController();
            var result = controller.Get();

            Assert.IsNotNull(result);

        }
        void Example()
        {
            this.NamedActionDelegate = NamedMethod;
            this.NamedActionDelegate.Invoke("Hi", 5);

            this.AnonymousActionDelegate.Invoke("Foooo", 106);
        }

        public Action<string, int> NamedActionDelegate { get; set; }
        public Action<string, int> AnonymousActionDelegate = (text, digit) => Console.WriteLine("Anonymous said: {0} {1}", text, digit);

        public void NamedMethod(string text, int digit)
        {
            Console.WriteLine("Named said: {0} {1}", text, digit);
        }

        public void SomethingElse(Action onComplete)
        {
            //do stuff here

            onComplete.Invoke();
        }

    }
}
