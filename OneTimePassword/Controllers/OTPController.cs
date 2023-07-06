using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace OneTimePassword.Controllers
{
    public class OTPController : Controller
    {
        public IActionResult Generate()
        {
            return View();
        }

        [HttpGet]
        public string GetPassword(string userId)
        {
            //verify if userId is not null
            if (userId == null)
            {
                return string.Empty;
            }

            //concatenate the userId with dateTime
            string password = userId + DateTimeOffset.Now.ToString();

            //this method encrypt the password using hashing and return the result
            string hash = EncryptPassword(password);

            //retun the firrst 8 characters of password
            return hash.ToString().Substring(0, 8);
        }

        public ActionResult GetPasswordView(string userId)
        {
            //get the password from request
            string password = GetPassword(userId);
            //set the expiration time
            string expireTime = DateTimeOffset.Now.AddSeconds(30).ToString("HH:mm:ss");

            ViewBag.UserId = userId;
            ViewBag.Password = password.ToString().Substring(0, 8);//display the first 8 characters of password
            ViewBag.ExpirationTime = expireTime; //display the time when OTP will expire

            return View();
        }

        private string EncryptPassword(string password)
        {
            //using the sha256 hash function for encrypting the password
            SHA256 sha256 = SHA256.Create();
            //create a byte array with encoded password charactes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            //create a byte array with characters afer using the hash function
            byte[] encriptedBytes = sha256.ComputeHash(passwordBytes);
            //create a string with the values of encrypted paswword
            StringBuilder sb = new();
            foreach (byte b in encriptedBytes)
            {
                sb.Append(b);
            }

            return sb.ToString();
        }
    }
}