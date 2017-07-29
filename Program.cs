using System;
using System.Text;

namespace SafeEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args == null || args.Length <= 0)
                {
                    DisplayMenuOptions();
                }
                else if (args[0] == "--help")
                {
                    DisplayMenuOptions();
                }
                else if (args[0] == "--version")
                {
                    DisplayVersion();
                }
                else if (args.Length == 1 && args[0] == "--generatekey")
                {
                    Console.WriteLine(KeyGenerator.Generate());
                }
                else if (args.Length >= 4)
                {
                    var key = string.Empty;
                    var filePath = string.Empty;

                    if (args[0] == "--encrypt" || args[2] == "--encrypt")
                    {
                        if ((args[0] == "--key" && args[2] == "--encrypt"))
                        {
                            key = args[1];
                            filePath = args[3];
                        }

                        if ((args[0] == "--encrypt" && args[2] == "--key"))
                        {
                            key = args[3];
                            filePath = args[1];
                        }
                        Encrypt.EncryptFile(filePath, Encoding.UTF8.GetBytes(key));
                        Console.WriteLine("Encrypted successfully!");
                    }
                    else if (args[0] == "--decrypt" || args[2] == "--decrypt")
                    {
                        if ((args[0] == "--key" && args[2] == "--decrypt"))
                        {
                            key = args[1];
                            filePath = args[3];
                        }

                        if ((args[0] == "--decrypt" && args[2] == "--key"))
                        {
                            key = args[3];
                            filePath = args[1];
                        }
                        Encrypt.DecryptFile(filePath, Encoding.UTF8.GetBytes(key));
                        Console.WriteLine("Decrypted successfully!");
                    }
                }
                else
                {
                    DisplayMenuOptions();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("An error occurred. Error details: {0}", ex);
            }

        }

        private static void DisplayMenuOptions()
        {
            Console.WriteLine(@"
SafeEncrypt 
Version 0.1

Usage: dotnet SafeEncrypt.dll [common-options] [[options] []]

Common Options:
    --help          Display SafeEncrypt usage options
    --version       Display SafeEncrypt version details

Options:
    --generatekey   This generates an encryption key to be used for encryption/decryption
    --key           This is the key generated and which would be used for encryption/decryption
    --encrypt       This will enable encryption 
    --decrypt       This will enable decryption

Example:

For key generation:
dotnet SafeEncrypt.dll --generatekey

For Encryption:
dotnet SafeEncrypt.dll --key [key-value] --encrypt [file path]

For Decryption:
dotnet SafeEncrypt.dll --key [key-value] --decrypt [file path]
");
        }

        private static void DisplayVersion()
        {
            Console.WriteLine("v0.1");
        }
    }
}
