using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ics0031-2020f Vugar.Gafarli HW01");

            var userInput = "";
            do
            {

                Console.WriteLine();
                Console.WriteLine("1) Cesar cipher");
                Console.WriteLine("2) Vigenere cipher");
                Console.WriteLine("X) Exit");
                Console.Write(">");

                userInput = Console.ReadLine()?.ToLower();

                switch (userInput)
                {
                    case "1":
                        Cesar();
                        break;
                    case "2":
                        Vigenere();
                        break;
                    case "x":
                        Console.WriteLine("closing down...");
                        break;
                    default:
                        Console.WriteLine($"Don't have this '{userInput}' as an option");
                        break;
                }

            } while (userInput != "x");

        }

        static void Cesar()
        {
            Console.WriteLine("Cesar Cipher");

            var userInput = "";
            var key = 0;
            do
            {
                Console.WriteLine("Please enter your shift amount (or X to cancel):");
                userInput = Console.ReadLine()?.ToLower().Trim();
                if (userInput != "x")
                {
                    if (int.TryParse(userInput, out var userValue))
                    {

                        key = userValue % 255;
                        if (key == 0)
                        {
                            Console.WriteLine("0 or multiple of 255 is no cipher, this would not do anything");
                        }
                        else
                        {
                            Console.WriteLine($"Cesar key is: {key}");
                        }
                    }
                }


            } while (userInput != "x" && key == 0);

            if (userInput == "x") return;

            Console.WriteLine("Please enter your plaintext");
            var plainText = Console.ReadLine();
            if (plainText != null)
            {
                Console.WriteLine($"Length of text: {plainText.Length}");

                ShowEncoding(plainText, Encoding.Default);

                var encryptedBytes = CesarEncryptString(plainText, (byte) key, Encoding.Default);

                Console.Write("Encrypted bytes: ");
                foreach (var encryptedByte in encryptedBytes)
                {
                    Console.Write(encryptedByte + " ");
                }

                var baseSixtyFour = System.Convert.ToBase64String(encryptedBytes);
                Console.WriteLine($"base64: {baseSixtyFour}");

                var decryptedBytes = CesarDecrypt(encryptedBytes, (byte) key);

                Console.Write("Decrypted bytes: ");
                foreach (var decryptedByte in decryptedBytes)
                {
                    Console.Write(decryptedByte + " ");
                }

                var decryptedBase64 = System.Convert.FromBase64String(baseSixtyFour);
                string x = Encoding.UTF8.GetString(decryptedBytes);
                Console.Write(x);

                /* ShowEncoding(plainText, Encoding.UTF7);
                ShowEncoding(plainText, Encoding.UTF8);
                ShowEncoding(plainText, Encoding.UTF32);
                ShowEncoding(plainText, Encoding.Unicode);
                ShowEncoding(plainText, Encoding.ASCII);
                ShowEncoding(plainText, Encoding.Default);
                */


            }
            else
            {
                Console.WriteLine("Plaintext is null!");
            }

        }

        static byte[] CesarEncryptString(string input, byte shiftAmount, Encoding encoding)
        {
            var inputBytes = encoding.GetBytes(input);
            return CesarEncrypt(inputBytes, shiftAmount);
        }

        static byte[] CesarEncrypt(byte[] input, byte shiftAmount)
        {
            var result = new byte[input.Length];

            if (shiftAmount == 0)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    result[i] = input[i];
                }
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    var newCharValue = (input[i] + shiftAmount);
                    if (newCharValue > byte.MaxValue)
                    {
                        newCharValue = newCharValue - byte.MaxValue;
                    }

                    result[i] = (byte) newCharValue;
                }

            }

            return result;
        }

        static byte[] CesarDecrypt(byte[] ciphertext, byte shiftAmount)
        {
            var result = new byte[ciphertext.Length];


            if (shiftAmount == 0)
            {
                // no shifting needed, just create deep copy
                for (var i = 0; i < ciphertext.Length; i++)
                {
                    result[i] = ciphertext[i];
                }
            }
            else
            {
                for (int i = 0; i < ciphertext.Length; i++)
                {
                    var decryptedLetter = (ciphertext[i] - shiftAmount);
                    if (decryptedLetter < 0)
                    {
                        decryptedLetter = decryptedLetter + byte.MaxValue; 
                    }

                    result[i] = (byte) decryptedLetter; // drop the first 3 bytes of int, just use the last one
                }
            }


            return result;
        }

        static void Vigenere()
        {
            Console.WriteLine("Vigenere");
            Console.WriteLine("Enter the text you want to encrypt");
            var vigenerePlainTextBytes = Encoding.Default.GetBytes(Console.ReadLine());
            Console.WriteLine("Enter key value");
            var vigenereKeyBytes = Encoding.Default.GetBytes(Console.ReadLine());
            Console.WriteLine($"Your Encrypted text is: { Convert.ToBase64String(VigenereEncrypt(vigenerePlainTextBytes, vigenereKeyBytes))}");
            
            Console.WriteLine("Enter the text you want to decrypt");
            var vigenereDPlainTextBytes = Convert.FromBase64String(Console.ReadLine());
            Console.WriteLine("Enter key value");
            var vigenereDKeyBytes = Encoding.Default.GetBytes(Console.ReadLine());
            Console.Write($"Your Decrypted text is: {Encoding.UTF8.GetString(VigenereDecrypt(vigenereDPlainTextBytes, vigenereDKeyBytes))}");
        }

        static byte[] VigenereEncrypt(byte[] plaintext, byte[] key)
        {
            var result = new byte[plaintext.Length];

            for (int i = 0; i < plaintext.Length; i++)
            {
                var newCharValue = (plaintext[i] + key[i % key.Length]);
                if (newCharValue > byte.MaxValue)
                {
                    newCharValue = newCharValue - byte.MaxValue;
                }

                result[i] = (byte) newCharValue;
            }

            return result;
        }
        
        static byte[] VigenereDecrypt(byte[] plaintext, byte[] key)
        {
            var result = new byte[plaintext.Length];

            for (int i = 0; i < plaintext.Length; i++)
            {
                var newCharValue = (plaintext[i] - key[i % key.Length]);
                if (newCharValue < 0)
                {
                    newCharValue = newCharValue + byte.MaxValue;
                }

                result[i] = (byte) newCharValue;
            }

            return result;
        }
        

        static void ShowEncoding(string text, Encoding encoding)
        {
            Console.WriteLine(encoding.EncodingName);
            
            /* Console.Write("Preamble ");
            foreach (var preambleByte in encoding.Preamble)
            {
                Console.Write(preambleByte + " ");
            } */
            Console.WriteLine();
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"{text[i]} ");
                foreach (var byteValue in encoding.GetBytes(text.Substring(i,1)))
                {
                    Console.Write(byteValue + " ");
                }
            }
            
            Console.WriteLine();
        }
    }
}