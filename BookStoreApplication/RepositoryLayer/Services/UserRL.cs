﻿using CommonModel.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRL: IUserRL
    {
        public readonly BookStoreDBContext context;
        public  UserRL(BookStoreDBContext context)
        {
            this.context = context;
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
        Task<int> IUserRL.Register(User user)
        {
            var password = EncryptPassword(user.Password);
            user.Password = password;
            this.context.Users.Add(user);
            var result = this.context.SaveChangesAsync();
            return result;
        }
        public User Login(UserLogin login)
        {
            var result = this.context.Users.Where<User>(details => details.Email == login.Email).FirstOrDefault();
            var passwordCheck = DecryptPassword(result.Password);
            if (passwordCheck == login.Password)
            {
                return result;
            }
            return null;
        }
    }
}
