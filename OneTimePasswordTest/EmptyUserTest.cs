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
            OTPController otpController = new();

            //Act
            string otp = otpController.GetPassword(null);

            //Assert
            Assert.AreEqual(otp, string.Empty);
        }
    }
}