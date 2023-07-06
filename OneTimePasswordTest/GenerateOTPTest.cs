using OneTimePassword.Controllers;

namespace OneTimePasswordTest
{
    [TestClass]
    public class GenerateOTPTest
    {
        [TestMethod]
        public void OTPTestValidInput()
        {
            //Arrange
            string userId = "testUser";
            OTPController otpController = new();

            //Act
            string otp = otpController.GetPassword(userId);

            //Assert
            Assert.IsNotNull(otp);
            Assert.AreEqual(8, otp.Length);
        }
    }
}