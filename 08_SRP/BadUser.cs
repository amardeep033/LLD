using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_SRP
{
    public class BadUser
    {
        public void RegisterUser(string email, string password)
        {
            // 1. Validation logic
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email cannot be empty");

            if (password.Length < 8)
                throw new Exception("Password too short");

            // 2. Password hashing
            string hashedPassword = HashPassword(password);

            // 3. Save to database

            // 4. Send welcome email
            Console.WriteLine($"Sending welcome email to {email}");

            // 5. Logging
            Console.WriteLine("User registered successfully");
        }

        private string HashPassword(string password)
        {
            return "dummy";
        }
    }
}