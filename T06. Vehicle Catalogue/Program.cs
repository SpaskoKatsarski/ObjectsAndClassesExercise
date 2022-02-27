using System;
using System.Collections.Generic;
using System.Linq;

namespace T06._Vehicle_Catalogue
{
    class Car
    {
        public Car (string model, string color, int horsePowers)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePowers = horsePowers;
        }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePowers { get; set; }
    }

    class Truck
    {
        public Truck (string model, string color, int horsePowers)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePowers = horsePowers;
        }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePowers { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            string input;
            
            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleArgs[0].ToLower();

                string model = vehicleArgs[1];
                string color = vehicleArgs[2];
                int horsePowers = int.Parse(vehicleArgs[3]);

                AddInformationAboutChosenVehicle(cars, trucks, type, model, color, horsePowers);
            }

            string command;

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                // command is the vehicle model

                if (cars.Any(c => c.Model == command))
                {
                    // It is a car.

                    Car searchedCar = new Car(null, null, 0);

                    foreach (Car car in cars)
                    {
                        if (car.Model == command)
                        {
                            searchedCar = car;
                            break;
                        }
                    }

                    Console.WriteLine("Type: Car");
                    Console.WriteLine($"Model: {searchedCar.Model}");
                    Console.WriteLine($"Color: {searchedCar.Color}");
                    Console.WriteLine($"Horsepower: {searchedCar.HorsePowers}");
                }
                else
                {
                    // It is a truck.

                    Truck searchedTruck = new Truck(null, null, 0);

                    foreach (Truck truck in trucks)
                    {
                        if (truck.Model == command)
                        {
                            searchedTruck = truck;
                            break;
                        }
                    }

                    Console.WriteLine("Type: Truck");
                    Console.WriteLine($"Model: {searchedTruck.Model}");
                    Console.WriteLine($"Color: {searchedTruck.Color}");
                    Console.WriteLine($"Horsepower: {searchedTruck.HorsePowers}");
                }

                //Type: {typeOfVehicle}
                //Model: { modelOfVehicle}
                //Color: { colorOfVehicle}
                //Horsepower: { horsepowerOfVehicle}
            }

            // TODO: {typeOfVehicles} have average horsepower of {averageHorsepower}.

            double horsePowersCarSum = 0;

            foreach (Car car in cars)
            {
                horsePowersCarSum += car.HorsePowers;
            }

            double horsePowersTruckSum = 0;

            foreach (Truck truck in trucks)
            {
                horsePowersTruckSum += truck.HorsePowers;
            }

            double averageHorsePowersPerCar = horsePowersCarSum / cars.Count;
            double averageHorsePowersPerTruck = horsePowersTruckSum / trucks.Count;

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageHorsePowersPerCar:f2}.");

            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageHorsePowersPerTruck:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }

        static void AddInformationAboutChosenVehicle(List<Car> cars, List<Truck> trucks, string typeOfVehicle, string model, string color, int horsePowers)
        {
            if (typeOfVehicle == "car")
            {
                Car currCar = new Car(model, color, horsePowers);
                cars.Add(currCar);
            }
            else
            {
                Truck currTruck = new Truck(model, color, horsePowers);
                trucks.Add(currTruck);
            }
        }
    }
}
