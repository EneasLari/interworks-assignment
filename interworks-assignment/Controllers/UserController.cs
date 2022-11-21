using interworks_assignment.Data;
using interworks_assignment.Helpers;
using interworks_assignment.Models.UserManagement;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IConfiguration _config;
        public UserController(IRepositoryManager repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _repository.User.GetAllUsers();
            return Ok(users);
        }

        //[HttpPost]
        //public IActionResult CreateUser(User user)
        //{
        //    _repository.User.CreateUser(user);
        //    _repository.Save();
        //    return Ok(_repository.User.GetAll());
        //}

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            _repository.User.Update(user);
            _repository.Save();
            return Ok(_repository.User.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _repository.User.DeleteUser(id);
            _repository.Save();
            return Ok(_repository.User.GetAll());
        }

        [HttpPost("Signup")]
        public IActionResult Signup(SignupDto userregister) {
            var existinguser = _repository.User.GetUserByEmail(userregister.Email);
            if (existinguser != null)
            {
                //return new JsonResult(BadRequest("User already exists."));
                return new JsonResult(new { error = "User already exists.", res = BadRequest() });
            }
            User user = new User(userregister);
            //encrypt paswsword
            string encryptedPassword = AesOperation.EncryptString(userregister.Password);
            //RE-ENCRYPT encrypted password
            CreatePasswordHash(encryptedPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken, user);
            SetToken(token);
            _repository.User.CreateUser(user);
            _repository.Save();
            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto userlogin)
        {
            var user = _repository.User.GetUserByEmail(userlogin.Email);
            if (user == null)
            {
                return new JsonResult(new { error = "Ο χρήστης δεν υπάρχει , παρακαλώ ξαναδοκιμάστε", res = BadRequest() });
            }
            //encrypt password
            string encryptedPassword = AesOperation.EncryptString(userlogin.Password);
            //verify the encrypted password with password hash
            if (!VerifyPasswordHash(encryptedPassword, user.PasswordHash, user.PasswordSalt))
            {
                return new JsonResult(new { error = "Λάθος κωδικός , παρακαλώ ξαναδοκιμάστε", res = BadRequest() });
            }

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken, user);
            SetToken(token);
            return Ok(new { token = token, expires = new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo, user = user });
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                SameSite = SameSiteMode.None,
            };
            Response.Cookies.Delete("t", cookieOptions);
            //Response.Cookies.Delete(" ", cookieOptions);

            return Ok(new { message = "Successfully LogOut" });
        }
        //Authentication methods
        RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };

            return refreshToken;
        }

        void SetRefreshToken(RefreshToken newRefreshToken, User user)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = newRefreshToken.Expires,
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }

        void SetToken(string token)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo
            };
            Response.Cookies.Append("t", token, cookieOptions);
        }

        string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AuthSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
