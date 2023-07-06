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
            OTPController OTPController = new();

            //Act
            string OTP = OTPController.GetPassword(userId);

            //Assert
            Assert.IsNotNull(OTP);
            Assert.AreEqual(8, OTP.Length);
        }
    }
}