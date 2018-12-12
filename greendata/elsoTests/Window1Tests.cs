using Microsoft.VisualStudio.TestTools.UnitTesting;
using elso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elso.Tests
{
   
    [TestClass()]
    
    public class Window1Tests
    {
        [TestMethod()]
        public void ValidateEmailBoolTest()
        {
            Window1 registrationValidEmali = new Window1();
            try
            {
                registrationValidEmali.Email = "kelemenanna@gmail.com";
            }
            catch(ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "Nem lehet üres a mező!");
                return;
            }
            catch(Exception e)
            {
                StringAssert.Contains(e.Message, "Nincs meg 3 karakter vagy hiányzik a @ jel vagy nincs benne pont.");
                return;
            }
            Assert.Fail("Nincs hiba");
        }
    }
}