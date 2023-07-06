using OneTimePassword.Controllers;

namespace OneTimePasswordTest
{
    [TestClass]
    public class EmptyUserTest
    {
        [TestMethod]
        public void OTPTestNullInput()
        {
            //Arrange
            OTPController OTPController = new();

            //Act
            string OTP = OTPController.GetPassword(userId: null);

            //Assert
            Assert.AreEqual(OTP, string.Empty);
        }
    }
}