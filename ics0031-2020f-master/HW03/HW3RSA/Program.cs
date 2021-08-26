using System;
using System.Numerics;
using MenuSystem;
using MenuSystem.Enums;

namespace HW3RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var mainMenu = new Menu(MenuLevels.Level0);
            
            mainMenu.AddMenuItem(new MenuItem("Encrypt", "1", Encrypt));
            mainMenu.AddMenuItem(new MenuItem("Brute Force", "2", BruteForce));

            mainMenu.RunMenu();
        }
        
        private static string Encrypt()
        {
            RsaBusinessLogic.Encrypt();
            return "";
        }
        
        
        private static string BruteForce()
        {
            RsaBusinessLogic.BruteForce();
            return "";
        }

    }
}