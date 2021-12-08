using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly ApplicationDBContext applicationDBContext;
        public UserRL(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public async Task<User> UserRegistration(User user)
        {
            var password =EncryptPassword(user.Password);
            user.Password = password;
            await this.applicationDBContext.Users.AddAsync(user);
            await this.applicationDBContext.SaveChangesAsync();
            return await applicationDBContext.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
        }
        public async Task<User> UserLogin(UserLogin userLogin)
        {
            var user = await applicationDBContext.Users.Where(u => u.Email == userLogin.Email).FirstOrDefaultAsync();
            if (user != null)
            {
                var password = DecryptPassword(user.Password);
                if (password == userLogin.Password)
                {
                    return user;
                }
                throw new Exception("Password entered is wrong");
            }
            throw new Exception("No user registered with given Email id");
        }
        private string EncryptPassword(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        private string DecryptPassword(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }
}
