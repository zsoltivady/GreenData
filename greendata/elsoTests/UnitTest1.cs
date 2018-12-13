using System;
using elso;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace elsoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Window1 w1 = new Window1();
            try
            {
                w1.UserName = "Tesztelek";
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "A mező nem lehet üres");
                return;
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Minimum 3 karakter hosszúnak kell lennie!");
                return;
            }
            Assert.Fail("Nem találtam hibát");
        }
    }
}
