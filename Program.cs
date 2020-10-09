using System;
using System.Collections.Generic;
using System.Threading;

namespace Klädbutiken
{

    class Program
    {
        public static List<Clothing> ClothingsList { get; set; }
        static bool isRunning = true;
        static bool isRunning2 = true;
        static bool isRunning3 = true;
        static void Main(string[] args)
        {
            ClothingsList = new List<Clothing>();
            AdminOrCustomer();
        }

        private static void AdminOrCustomer()
        {
            while (isRunning)
            {
                Console.Clear();
                Console.Write("Skriv in [A]dmin eller [K]und. [Q] för att avsluta: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();

                switch (key.KeyChar)
                {
                    case 'a':
                        Console.Write("Lösenord: ");
                        string password = "password";
                        string passTry = Console.ReadLine();
                        if (passTry == password)
                        {
                            Admin();
                        }
                        else
                        {
                            Console.WriteLine("Fel lösenord!");
                            Thread.Sleep(1000);
                        }
                        break;
                    case 'k':
                        int choice = 0;
                        int listNumber = 0;
                        while (isRunning3)
                        {

                            //for (int i = 0; i < ClothingsList.Count; i++)
                            //{
                            foreach (var item in ClothingsList)
                            {
                                Console.Write($"Klädesplagg: {item.Type}" +
                                    $"  Storlek: {item.Size}" +
                                    $"  Färg: {item.Color}" +
                                    $"  Pris: {item.Price}");
                                if ((int)ClothingsList[choice] == choice)
                                {
                                    Console.Write(" <--");
                                    i++;
                                }
                                Console.WriteLine();
                            }
                            //i--;
                            ConsoleKeyInfo keySize = Console.ReadKey();
                            if (keySize.KeyChar == 'a')
                            {
                                choice++;
                                if (choice > ClothingsList.Count)
                                {
                                    choice = 0;
                                }

                            }
                            else if (keySize.KeyChar == 'z')
                            {
                                choice--;
                                if (choice > 0)
                                {
                                    choice = ClothingsList.Count;
                                }
                            }
                            //else if (keySize.KeyChar == ConsoleKey.Enter)
                            //{

                            //}
                            Console.Clear();
                            //}
                        }
                        break;
                    case 'q':
                        Console.WriteLine("Avslutar");
                        Thread.Sleep(1000);
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }

            }
        }

        private static void Admin()
        {
            while (isRunning2)
            {
                Console.Write("Vill du lägga in ett nytt klädespagg? [J]/[N]: ");
                ConsoleKeyInfo keyChoice = Console.ReadKey();
                Console.Clear();
                if (keyChoice.KeyChar == 'n')
                {
                    isRunning2 = false;
                    break;
                }
                else if (keyChoice.KeyChar == 'j')
                {
                    Clothing garment = default;
                    int garmentChoice = 0;
                    do
                    {
                        try
                        {
                            Console.Write("Vill du lägga in" +
                                "\n[1] Tröja" +
                                "\n[2] Byxor" +
                                "\n[3] Skor" +
                                "\nVälj: ");
                            garmentChoice = int.Parse(Console.ReadLine());
                            garment.Type = Enum.GetName(typeof(Type), garmentChoice);
                            Console.Clear();
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("Vänligen välj en siffra 1, 2 eller 3!");
                        }

                    } while (garmentChoice < 1 || garmentChoice > 3);


                    Console.Write("Storlek på klädesplagget" +
                        "\n[1] S" +
                        "\n[2] M" +
                        "\n[3] L" +
                        "\nVälj: ");
                    int garmentSize = int.Parse(Console.ReadLine());
                    garment.Size = Enum.GetName(typeof(Size), garmentSize);
                    Console.Clear();


                    Console.Write("färg på klädesplagget" +
                        "\n[1] Blå" +
                        "\n[2] Gul" +
                        "\n[3] Röd" +
                        "\nVälj: ");
                    int garmentColor = int.Parse(Console.ReadLine());
                    garment.Color = Enum.GetName(typeof(Color), garmentColor);
                    Console.Clear();


                    Console.Write("Pris på klädesplagget: ");
                    string input = Console.ReadLine();
                    bool ok = int.TryParse(input, out int result);

                    if (ok)
                    {
                        garment.Price = result;
                    }
                    else
                    {
                        Console.WriteLine("Felaktig inmatning!");
                        Thread.Sleep(1500);
                        break;
                    }
                    ClothingsList.Add(garment);
                }
                else
                {
                    Console.WriteLine("Vänligen välj [J] eller [N]!");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }
    }
}
