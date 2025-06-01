using EncriptionLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurent_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        private readonly EncryptionHelper _encriptionHelper;

        public EncryptionController()
        {
            string secretKey = "ThisIsA32CharacterLongSecretKey!";
            _encriptionHelper = new EncryptionHelper(secretKey);
        }

        /// <summary>
        /// Encrypts the provided plain text and returns the encrypted result.
        /// </summary>
        /// <param name="plainText">The plain text string to be encrypted.</param>
        /// <returns>The encrypted form of the given plain text.</returns>
        /// <example>
        /// var result = Encrpt("exampleText");
        /// Console.WriteLine(result); // Outputs encrypted text
        /// </example>
        [HttpPost("encrypt")]
        public IActionResult Encrpt(string plainText)
        {
            try
            {
                return Ok(_encriptionHelper.Encrypt(plainText));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Decrypts the provided cipher text and returns the plaintext result.
        /// </summary>
        /// <param name="cipherText">The encrypted string that needs to be decrypted.</param>
        /// <returns>An IActionResult containing the decrypted plaintext.</returns>
        /// <example>
        /// var result = Decrypt("encryptedString");
        /// Console.WriteLine(result); // Outputs the decrypted string
        /// </example>
        [HttpPost("decrypt")]
        public IActionResult Decrypt(string cipherText)
        {
            try
            {
                return Ok(_encriptionHelper.Decrypt(cipherText));
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
