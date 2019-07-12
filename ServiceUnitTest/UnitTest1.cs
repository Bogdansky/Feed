using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Services;

namespace ServiceUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string[] urls = new string[] { "https://nodejs.org/api/fs.html#fs_fs_writefilesync_file_data_options",
            "https://www.bestprog.net/ru/2018/08/25/example-of-creating-a-unit-test-in-ms-visual-studio-2017-c_ru/",
            "https://www.tut.by/",
            "https://afisha.tut.by/news/anews/645238.html"
        };

        [TestMethod]
        public void TestMethod1()
        {
            var service = new ParseService();
            var result = service.Execute(urls[0]);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var service = new ParseService();
            var result = service.Execute(urls[1]);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var service = new ParseService();
            var result = service.Execute(urls[2]);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var service = new ParseService();
            var result = service.Execute(urls[3]);
            Assert.IsNotNull(result);
        }
    }
}
