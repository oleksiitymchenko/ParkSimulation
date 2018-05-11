using Park.Data;
using System;
using System.Collections.Generic;

namespace ParkSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Add car");
                Console.WriteLine("[2] Remove car");
                Console.WriteLine("[3] Put money on car`s account");
                Console.WriteLine("[4] Show free space on parking");
                Console.WriteLine("[5] Show parking benefits");
                Console.WriteLine("[6] Show 1 minute transaction history");
                Console.WriteLine("[7] Show Transaction.log");
                switch (Console.ReadLine())
                {
                    case "1":
                    {
                        Console.WriteLine("Already staying cars");
                        ShowStayCars(Parking.Instance.Cars);
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("Creating cars");
                        double balance;
                        while (true)
                        {
                            Console.WriteLine("Input account balance");


                            bool n = double.TryParse(Console.ReadLine(), out balance);
                            if (!n)
                            {
                                Console.WriteLine("Input correct number");
                            }
                            else break;
                        }

                        CarType type;

                        Console.WriteLine("Choose car type 1-Bus, 2-Motorcycle, 3- Passenger, 4-Truck");

                        switch (Console.ReadLine())
                        {
                            case "1":
                            {
                                type = CarType.Bus;
                                break;
                            }
                            case "2":
                                type = CarType.Motorcycle;
                                break;
                            case "3":
                                type = CarType.Passenger;
                                break;
                            case "4":
                                type = CarType.Truck;
                                break;
                            default:
                                type = CarType.Passenger;
                                break;
                        }

                        Parking.Instance.AddCar(new Car(balance, type));
                        Console.ReadKey();
                        break;
                    }
                    case "2":
                    {
                        if (Parking.Instance.Cars.Count == 0)
                        {
                            Console.WriteLine("There are no cars");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Already staying cars");
                        ShowStayCars(Parking.Instance.Cars);
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("Choose car to remove");
                        int index;
                        while (true)
                        {
                            Console.WriteLine("Input number of car");


                            bool n = int.TryParse(Console.ReadLine(), out index);
                            if (!n)
                            {
                                Console.WriteLine("Input correct number");
                            }
                            else break;
                        }

                        try
                        {
                            Car removedCar = Parking.Instance.Cars[index];
                            Parking.Instance.RemoveCar(removedCar);
                        }

                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Index is out of range");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Put money on car`s account");
                        }

                        Console.ReadKey();
                        break;
                    }
                    case "3":
                    {
                        if (Parking.Instance.Cars.Count == 0)
                        {
                            Console.WriteLine("There are no cars");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Already staying cars");
                        ShowStayCars(Parking.Instance.Cars);


                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("Choose car to add money on account");
                        int index;
                        while (true)
                        {
                            Console.WriteLine("Input number of car");
                            bool n = int.TryParse(Console.ReadLine(), out index);
                            if (!n || index >= Parking.Instance.Cars.Count)
                            {
                                Console.WriteLine("Input correct number");
                            }
                            else break;
                        }

                        double sum = 0;
                        while (true)
                        {
                            Console.WriteLine("Input amount of money");


                            bool n = double.TryParse(Console.ReadLine(), out sum);
                            if (!n)
                            {
                                Console.WriteLine("Input correct number");
                            }
                            else break;
                        }

                        try
                        {
                            Car carForPutMoney = Parking.Instance.Cars[index];
                            Parking.Instance.Deposit(carForPutMoney, sum);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Index is out of range");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Index is incorrect");
                        }

                        break;
                    }
                    case "4":
                    {
                        Console.WriteLine("There are some free space on parking");
                        Console.WriteLine($"{Parking.Instance.FreeSpace} free spots.");
                        Console.ReadKey();
                        break;
                    }
                    case "5":
                    {
                        Console.WriteLine("Parking is making money");
                        Console.WriteLine($"Current sum is {Parking.Instance.Balance}");
                        Console.ReadKey();
                        break;
                    }
                    case "6":
                    {
                        Console.WriteLine("Transactions in past minute:");
                        Console.WriteLine();
                        foreach (var trans in Parking.Instance.TransactionsOneMinute)
                        {
                            Console.WriteLine(trans);
                        }

                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                    }
                    case "7":
                    {
                        Console.WriteLine("Transactions.log file");
                        Console.WriteLine();
                        Console.WriteLine(Parking.Instance.TransactionsLogged());
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }

        private static void ShowStayCars(List<Car> cars)
        {
            int a = 0;
            foreach (var car in cars)
            {
                Console.WriteLine($"[{a}] {car}");
                a++;
            }
        }
    }
}