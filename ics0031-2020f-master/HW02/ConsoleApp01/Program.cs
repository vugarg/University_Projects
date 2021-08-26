using System;
using System.ComponentModel;
using System.Reflection;

namespace HW02
{
    static class Program
    {
        private static UInt64 baseNumberValue;
        private static UInt64 primeValue;
        private static UInt64 randomAValue;
        private static UInt64 randomBValue;
        static void Main(string[] args)
        {
            Console.WriteLine("ics0031-2020f Vugar.Gafarli HW02");
            Console.WriteLine("------ Welcome to Diffie Hellman key exchange algorithm ------");
            Console.WriteLine();
            

            Console.WriteLine("1) Person A please enter a random number: ");
            randomAValue = Convert.ToUInt64(Console.ReadLine());
            
            Console.WriteLine("2) Person B please enter a random number: ");
            randomBValue = Convert.ToUInt64(Console.ReadLine());
            
            Console.WriteLine("3) Please enter a prime number or Press 'R' to generate randomly : ");
            var userInput = Console.ReadLine();
            if (userInput != null && userInput.ToLower() == "r")
            {
                prmg();
            }
            else
            {
                primeNum(userInput);
            }
            
            Console.WriteLine("4) Please enter your base number:");
            numBase();
            
            Console.WriteLine("Calculation going on.....");
            Console.WriteLine();
            var personAPub = publicCalulator(primeValue, baseNumberValue, randomAValue);
            var personBPub = publicCalulator(primeValue, baseNumberValue, randomBValue);

            var personAPriv = privateCalulator(personBPub, randomAValue, primeValue);
            var personBPriv = privateCalulator(personAPub, randomBValue, primeValue);
            
            if(personAPriv == personBPriv) Console.WriteLine($"They are equal and the result is: {personAPriv}");
            else Console.WriteLine("Something went wrong give me another chance :D");
            
            
        }

        static void prmg()
        {
            var primegen = new PrimeGenerator(new Random());
            var primeNumberGenerated = primegen.Next(0, 18446744073709551614);
            Console.WriteLine($"Generated prime number is: {primeNumberGenerated}");
            primeValue = primeNumberGenerated;
        }

        static void randomA()
        {
            step1:
            if (randomAValue==0)
            {
                Console.WriteLine("Enter a positive integer bigger tha 0 please...");
                goto step1;
            }
            else
            {
                Console.WriteLine($"Thank you, your number is {randomAValue}");
            }
        }

        static void randomB()
        {
            step1:
            if (randomBValue==0)
            {
                Console.WriteLine("Enter a positive integer bigger tha 0 please...");
                goto step1;
            }
            else
            {
                Console.WriteLine($"Thank you, your number is {randomBValue}");
            }
        }

        static void primeNum(string userInput)
        {
            step1:
            UInt64 pValue = Convert.ToUInt64(userInput);
            if (IsPrime(pValue))
            {
                Console.WriteLine($"Thank you your prime number is {pValue}");
                primeValue = pValue;
            }
            else
            {
                Console.WriteLine("you havent entered a prime number try again..");
                userInput = Console.ReadLine();
                goto step1;
                
            }
        }

        static void numBase()
        {
            step1:
            var baseNum = Convert.ToUInt64(Console.ReadLine());
            if (baseNum==0)
            {
                Console.WriteLine("Base number cannot be 0 ...");
                goto step1;
            }
            else
            {
                Console.WriteLine($"Thank you, your base number is {baseNum}");
                baseNumberValue = baseNum;
            }
        }

        static ulong publicCalulator(ulong a, ulong b, ulong c)
        {
            ulong result = 0;
            result = (ulong)(Math.Pow(b, c) % a);
            Console.WriteLine($"Public Value: {result}");
            return result;
        }
        
        static ulong privateCalulator(ulong a, ulong b, ulong c)
        {
            ulong result = 0;
            result = (ulong)(Math.Pow(a, b) % c);
            Console.WriteLine($"Private Value: {result}");
            return result;
        }

        public static bool IsPrime(ulong number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (ulong)Math.Floor(Math.Sqrt(number));

            for (ulong i = 3; i <= boundary; i+=2)
                if (number % i == 0)
                    return false;

            return true;        
        }
    }
}