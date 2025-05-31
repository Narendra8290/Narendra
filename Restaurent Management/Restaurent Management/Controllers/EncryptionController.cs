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
