﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elso;

namespace elsoTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod()
        {
            Window1 win1 = new Window1();
            try
            {
                string jelszo = "barack123";

                win1.Password = jelszo;

            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "A mező nem lehet üres");
                return;
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Nincs meg a 3 karakter.");
                return;
            }
            Assert.Fail("nincsen hiba");
        }
    }
}