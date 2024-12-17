using System;
using System.Collections.Generic;
using System.IO;

namespace BAC
{
    public class User
    {
        public string userLogin; 
        public string Password; 

        
        public User(string login, string password)
        {
            userLogin = login;
            Password = password;
        }

        
        public static void Register()
        {
            string fileName = "users.txt"; 
            List<User> users = new List<User>(); 

            
            if (File.Exists(fileName))
            {
                
                string[] lines = File.ReadAllLines(fileName);

                
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':'); 
                    if (parts.Length == 2) 
                    {
                        users.Add(new User(parts[0], parts[1])); 
                    }
                }
            }

            
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            bool loginTaken = false; 

            
            foreach (var user in users)
            {
                 
                if (user.userLogin == login)
                {
                    loginTaken = true; 
                    break; 
                }
            }

            
            if (loginTaken)
            {
                Console.WriteLine("Этот логин уже занят. Попробуйте другой.");
            }
            else
            {
                
                string password = "";
                User newUser = new User(login, password);


                StreamWriter sw = new StreamWriter(fileName, true); 

                sw.WriteLine($"{newUser.userLogin}:{newUser.Password}"); 

                
                sw.Close();


                Console.WriteLine("Регистрация прошла успешно!");
            }
        }

        
        public static void Login()
        {
            string fileName = "users.txt"; 
            List<User> users = new List<User>(); 

            
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        users.Add(new User(parts[0], parts[1])); 
                    }
                }
            }

            bool isAuthenticated = false; 

            
            while (!isAuthenticated)
            {
                
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                
                foreach (var user in users)
                {
                    
                    if (user.userLogin == login && user.Password == password)
                    {
                        isAuthenticated = true; 
                        Console.WriteLine("Вход выполнен успешно!");
                        break; 
                    }
                }

                if (!isAuthenticated)
                {
                    Console.WriteLine("Неверный логин или пароль. Попробуйте снова.");
                }
            }
        }
    }
}