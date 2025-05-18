using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // User class to store each user's information
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public User(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}";
        }
    }

    // List to store users
    static List<User> users = new List<User>();

    static void Main(string[] args)
    {
        int nextId = 1; // Next ID for a new user

        while (true)
        {
            Console.WriteLine("\n1. Show all users");
            Console.WriteLine("2. Add a new user");
            Console.WriteLine("3. Edit user information");
            Console.WriteLine("4. Delete a user");
            Console.WriteLine("5. Exit");
            Console.Write("Please enter your choice: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowAllUsers();
                    break;

                case "2":
                    AddUser(ref nextId);
                    break;

                case "3":
                    EditUser();
                    break;

                case "4":
                    DeleteUser();
                    break;

                case "5":
                    Console.WriteLine("Exiting the program...");
                    return;

                default:
                    Console.WriteLine("The entered option is incorrect. Please try again.");
                    break;
            }
        }
    }

    // Show all users
    static void ShowAllUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("There are no users in the list.");
        }
        else
        {
            Console.WriteLine("\nUser list:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }

    // Add a new user
    static void AddUser(ref int nextId)
    {
        Console.Write("Enter the name of the new user: ");
        string name = Console.ReadLine();

        Console.Write("Enter the age of the new user: ");
        int age = int.Parse(Console.ReadLine());

       


        User newUser = new User(nextId++, name, age);
        users.Add(newUser);

        Console.WriteLine("The new user was successfully added.");
    }

    // Edit user information
    static void EditUser()
    {
        Console.Write("Please enter the user's ID: ");
        int id = int.Parse(Console.ReadLine());

        User userToEdit = users.FirstOrDefault(u => u.Id == id);

        if (userToEdit != null)
        {
            Console.Write($"Edit name (current: {userToEdit.Name}): ");
            userToEdit.Name = Console.ReadLine();

            Console.Write($"Edit age (current: {userToEdit.Age}): ");
            userToEdit.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("The user's information was successfully edited.");
        }
        else
        {
            Console.WriteLine("No user found with this ID.");
        }
    }

    // Delete a user
    static void DeleteUser()
    {
        Console.Write("Please enter the user's ID: ");
        int id = int.Parse(Console.ReadLine());

        User userToDelete = users.FirstOrDefault(u => u.Id == id);

        if (userToDelete != null)
        {
            users.Remove(userToDelete);
            Console.WriteLine("The user was successfully deleted.");
        }
        else
        {
            Console.WriteLine("No user found with this ID.");
        }
    }
}
