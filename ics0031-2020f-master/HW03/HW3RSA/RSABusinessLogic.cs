using System;

namespace HW3RSA
{
    public static class RsaBusinessLogic
    {
        public static void Encrypt()
        {
            ulong p, q;
            
            Console.WriteLine("RSA");

            do
            {
                if (!ulong.TryParse(GetInput("1st prime p:"), out p))
                {
                    Console.WriteLine("input value must be a positive integer! try again...");
                    continue;
                }

                if (!ValidatePrime(p))
                {
                    Console.WriteLine("this p is not prime! try again...");
                    continue;
                }
                
                
                if (p == 1)
                {
                    Console.WriteLine("q should more than 1! try again...");
                    continue;
                }

                break;
            } while (true);
            
            
            do
            {
                if (!ulong.TryParse(GetInput("2nd prime q:"), out q))
                {
                    Console.WriteLine("input value must be a positive integer! try again...");
                    continue;
                }

                if (!ValidatePrime(q))
                {
                    Console.WriteLine("this p is not prime! try again...");
                    continue;
                }
                
                if (q == 1)
                {
                    Console.WriteLine("q should more than 1! try again...");
                    continue;
                }

                break;
            } while (true);

            var n = p * q;
            var m = (p - 1) * (q - 1);
            
            Console.WriteLine($"n = p * q is {n}");
            Console.WriteLine($"m = (p - 1) * (q- 1) is {m}");
            
            ulong e;
            for (e = 2; e < ulong.MaxValue; e++)
            {
                if (Gcd(e, m) == 1) break;
            }

            ulong d = 0;
            for (ulong k = 2; k < ulong.MaxValue; k++)
            {
                if ((1 + k * m) % e == 0)
                {
                    d = (1 + k * m) / e;
                    break;
                }
            }
            
            Console.WriteLine($"Public key({n} {e})");
            Console.WriteLine($"Private key({n} {d})");
            
            ulong message;

            do
            {
                var messageStr = GetInput("Message: ");
                if (!ulong.TryParse(messageStr, out message))
                {
                    Console.WriteLine("received string was not a ulong! try again...");
                    continue;
                }

                if (n < message)
                {
                    Console.WriteLine("message string value cannot be less than n (p * q)");
                    continue;
                }

                break;
            } while (true);

            var cipher = CalculatePowMod(message, e, n);
            Console.WriteLine($"Cipher: {cipher}");

            var plainMessage = CalculatePowMod(cipher, d, n);
            Console.WriteLine($"plainText: {plainMessage}");
        }

        public static void BruteForce()
        {
            ulong pubE;
            ulong pubN;
            ulong cipher;
            ulong p = 0;
            ulong q = 0;
            ulong m;

            do
            {
                var primeOneString = GetInput("enter public key's n: ");
                if (!ulong.TryParse(primeOneString, out pubN))
                {
                    Console.WriteLine("enter a valid n! try again...");
                    continue;
                }

                var primeTwoString = GetInput("enter public key's e: ");
                if (!ulong.TryParse(primeTwoString, out pubE))
                {
                    Console.WriteLine("enter a valid e! try again...");
                    continue;
                }

                if (pubE == 1 || pubN == 1)
                {
                    Console.WriteLine("e or n should more than 1! try again...");
                    continue;
                }

                var cipherString = GetInput("enter cipher");
                if (!ulong.TryParse(cipherString , out cipher))
                {
                    Console.WriteLine("enter a valid cipher!! try again...");
                    continue;
                }
                
                break;
            } while (true);

            //pubN is (p * q) if i'll know what those are, we can kiss the cipher goodbye
            //deciphered message must me less than pubN(p * q)
            for (ulong i = 3; i < ulong.MaxValue; i+=2)
            {
                if ((pubN % i) == 0)
                {
                    p = i;
                    q = pubN / i;
                    break;
                }
            }
            
            m = (q - 1) * (p - 1);
            
            ulong d = 0;
            for (ulong k = 2; k < ulong.MaxValue; k++)
            {
                if ((1 + k * m) % pubE == 0)
                {
                    d = (1 + k * m) / pubE;
                    break;
                }
            }

            var plainMessage = CalculatePowMod(cipher, d, pubN);
            Console.WriteLine($"plainText: {plainMessage}");
            
        }

        private static ulong Gcd(ulong a, ulong b)
        {
            return a == 0 ? b : Gcd(b % a, a);
        }
        
        private static string GetInput(string message) {
            Console.WriteLine(message);
            Console.Write(">");

            return Console.ReadLine()?.Trim();
        }

        private static ulong CalculatePowMod(ulong b, ulong e, ulong m)
        {
            if (m == 1) return 0;
            ulong c = 1;
            for (ulong i = 0; i < e; i++)
            {
                c = (c * b) % m;
            }

            return c;
        }

        private static bool ValidatePrime(ulong prime)
        {
            if (prime == 1) return true;
            
            if (prime % 2 == 0)
            {
                return false;
            }

            for (ulong i = 3; i < prime; i+=2)
            {
                if (prime % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}