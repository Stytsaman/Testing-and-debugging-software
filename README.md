<h1 align="center">Быки и коровы
<img src="https://i.pinimg.com/originals/12/ce/65/12ce65bc6c2b201d68c29822ecbd186c.gif" height="32"/></h1>
<h3 align="center">Sudent DVGUPS</h3>

This is my Game on C#


Метод регистрации пользователя
```
         public static void Register()
 {
     string fileName = "users.txt"; 
     List<User> users = LoadUsersFromFile(fileName); // Загрузка пользователей, которые уже есть

     Console.Write("Введите логин: ");
     string login = Console.ReadLine();

     if (IsLoginTaken(users, login))
     {
         Console.WriteLine("Этот логин уже занят. Попробуйте другой.");
         return;
     }

     
     string password = GetValidPassword();

     // Создаём нового пользователя и записываем его в файл
     User newUser = new User(login, password);
     AppendUserToFile(fileName, newUser);

     Console.WriteLine("Регистрация прошла успешно!");
 }
```
Сама менюха: <br />
![alt text] (imageMenu.png)
