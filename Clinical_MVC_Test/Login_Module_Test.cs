using Clinical_MVC_Ganesh.Models;

namespace Clinical_MVC_Test
{
    [TestClass]
    public class Login_Module_Test
    {
        [TestMethod]
        public void Login_Test_Using_Incorrect_Role()
        {
            TblLogin model = new TblLogin();
            model.Role = "Teacher";

           
            
            
        }
    }
}