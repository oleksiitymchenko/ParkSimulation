using Park.Data;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ParkSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine(Settings.ParkingSpace);
           // Settings.ParkingSpace = 200;
           // Console.WriteLine(Settings.ParkingSpace);
           //// Console.ReadLine();

           // var x = Parking.Instance;
           // var i = new Car(20, CarType.Bus);
           // x.AddCar(i);
           // x.AddCar(new Car(200, CarType.Truck));
           // x.AddCar(new Car(200, CarType.Passenger));
           // x.AddCar(new Car(200, CarType.Motorcycle));
           // x.AddCar(new Car(200, CarType.Motorcycle));
           // x.AddCar(i);


           // Console.WriteLine(DateTime.Now.ToString("F"));
           // Console.WriteLine("LOL");
           // Parking.Instance.ShowAllTransactions();
           // Thread.Sleep(1000);
           // Console.WriteLine(Parking.Instance.FreeSpace);
           // x.RemoveCar(i);
           // x.RemoveCar(i);
           // Console.WriteLine(Parking.Instance.FreeSpace);



           // Thread.Sleep(10000);

              
           //     Thread.Sleep(60500);
           //     Console.WriteLine("===========================");
           //     Parking.Instance.ShowAllTransactions();
           //     Console.WriteLine(  "******************************************");
           //     foreach (var item in Parking.Instance.OneMinuteTransactions){
           //         Console.WriteLine(item);
           //     }
           // Console.WriteLine("---------------------------------------------------");
           // Console.WriteLine(Parking.Instance.Balance);


           // Thread.Sleep(60500);
           // Console.WriteLine("===========================");
           // Parking.Instance.ShowAllTransactions();
           // Console.WriteLine("******************************************");

           // Console.WriteLine("LOL");
           // Console.ReadLine();
          Start:
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
                    Console.Clear();
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
                    Parking.Instance.AddCar(new Car(balance,type));
                    Console.ReadLine();
                    goto Start;
                }
                case "2":
                {
                    Console.Clear();
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
                        Car RemovedCar = Parking.Instance.Cars[index];
                        Parking.Instance.RemoveCar(RemovedCar);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Index is out of range");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Index is out of range");
                    }
                        Console.ReadLine();
                        goto Start;
                    }
                case "3":
                {
                    Console.Clear();
                    Console.WriteLine("Already staying cars");
                    ShowStayCars(Parking.Instance.Cars);
                    if (Parking.Instance.Cars.Count==0)
                    {
                        Console.WriteLine("There are no cars");
                        Console.ReadLine();
                        goto Start;
                    }
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Choose car to add money on account");
                    int index;
                    while (true)
                    {
                        Console.WriteLine("Input number of car");
                        bool n = int.TryParse(Console.ReadLine(), out index);
                        if (!n || index>=Parking.Instance.Cars.Count)
                        {
                            Console.WriteLine("Input correct number");
                        }
                        else break;
                    }

                    double sum=0;
                    while (true)
                    {
                        Console.WriteLine("Input amount of money");


                        bool n = double.TryParse(Console.ReadLine(), out sum);
                        if (!n )
                        {
                            Console.WriteLine("Input correct number");
                        }
                        else break;
                    }

                        try
                    {
                        Car AddingMoneyToCar = Parking.Instance.Cars[index];
                        Parking.Instance.Deposit(AddingMoneyToCar,sum);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Index is out of range");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Index is out of range");
                    }
                        goto Start;
                }
                case "4":
                {
                    Console.WriteLine("There are some free space on parking");
                    Console.WriteLine($"{Parking.Instance.FreeSpace} free spots.");
                    Console.ReadLine();
                    break;
                }
                case "5":
                {
                    Console.WriteLine("Parking is making money");
                    Console.WriteLine($"Current sum is {Parking.Instance.Balance}");
                    Console.ReadLine();
                    break;
                }
                case "6":
                {
                    Console.WriteLine("Transactions in past minute:");
                    Console.WriteLine();
                    foreach (var trans in Parking.Instance.OneMinuteTransactions)
                    {
                        Console.WriteLine(trans);
                    }
                    Console.WriteLine();
                    Console.ReadLine();
                    break;
                }
                case "7":
                {
                    Console.WriteLine("Transactions.log file");
                    Console.WriteLine();
                    Console.WriteLine(Parking.Instance.ShowTransactionLog());
                    Console.ReadLine();
                    break;
                }
                default: goto Start;
            }
            


        }

        private static void ShowStayCars(List<Car> cars)
        {
            int a = 0;
            foreach (var car in cars)
            {
                Console.WriteLine($"[{a}]. {car}");
                a++;
            }
        }
    }
}
