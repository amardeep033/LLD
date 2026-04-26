using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_SRP
{
    using System;

    //Composition Class
    public class GoodUser
    {
        private readonly UserValidator validator = new UserValidator();
        private readonly PasswordHasher hasher = new PasswordHasher();
        private readonly UserRepository repository = new UserRepository();
        private readonly EmailService emailService = new EmailService();

        public void RegisterUser(string email, string password)
        {
            // 1. Validate input
            validator.Validate(email, password);

            // 2. Hash password
            string hashedPassword = hasher.Hash(password);

            // 3. Save user
            repository.Save(email, hashedPassword);

            // 4. Send email
            emailService.SendWelcomeEmail(email);

            Console.WriteLine("User registered successfully");
        }
    }
    public class UserValidator
    {
        public void Validate(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email cannot be empty");

            if (password.Length < 8)
                throw new Exception("Password too short");
        }
    }

    public class PasswordHasher
    {
        public string Hash(string password)
        {
            return "";
        }
    }


    public class UserRepository
    {
        public void Save(string email, string hashedPassword)
        {

        }
    }


    public class EmailService
    {
        public void SendWelcomeEmail(string email)
        {
            Console.WriteLine($"Sending welcome email to {email}");
        }
    }
}