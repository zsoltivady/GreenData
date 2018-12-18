using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace elsoTests
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod()]
        public void TestLogin()
        {
            try
            {
                string un = "dsadasda";

                string pw = "asddsadasds";

                elso.User.UserLogin(un, pw);      
            }
            catch (System.ArgumentNullException E)
            {
                StringAssert.Contains(E.Message, "Minden mező kitöltése kötelező!");
                return;
            }
            catch (System.Exception E)
            {
                StringAssert.Contains(E.Message, "Nem megfelelően kitöltött mezők!");
                return;
            }

            Assert.Fail("Nem keletkezett hiba!");

        }
    }
}
