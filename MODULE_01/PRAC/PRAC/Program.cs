using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }

        public virtual void StartEngine()
        {
            Console.WriteLine($"{Brand} {Model}: Двигатель запущен.");
        }

        public virtual void StopEngine()
        {
            Console.WriteLine($"{Brand} {Model}: Двигатель остановлен.");
        }
    }

    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public string TransmissionType { get; set; }

        public Car(string brand, string model, int year, int numberOfDoors, string transmissionType)
            : base(brand, model, year)
        {
            NumberOfDoors = numberOfDoors;
            TransmissionType = transmissionType;
        }

        public override void StartEngine()
        {
            Console.WriteLine($"{Brand} {Model} (Автомобиль): Двигатель запущен.");
        }

        public override void StopEngine()
        {
            Console.WriteLine($"{Brand} {Model} (Автомобиль): Двигатель остановлен.");
        }
    }

    public class Motorcycle : Vehicle
    {
        public string BodyType { get; set; }
        public bool HasBox { get; set; }

        public Motorcycle(string brand, string model, int year, string bodyType, bool hasBox)
            : base(brand, model, year)
        {
            BodyType = bodyType;
            HasBox = hasBox;
        }

        public override void StartEngine()
        {
            Console.WriteLine($"{Brand} {Model} (Мотоцикл): Двигатель запущен.");
        }

        public override void StopEngine()
        {
            Console.WriteLine($"{Brand} {Model} (Мотоцикл): Двигатель остановлен.");
        }
    }

    public class Garage
    {
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
            Console.WriteLine($"{vehicle.Brand} {vehicle.Model} добавлен в гараж.");
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            Vehicles.Remove(vehicle);
            Console.WriteLine($"{vehicle.Brand} {vehicle.Model} удален из гаража.");
        }
    }

    public class Fleet
    {
        public List<Garage> Garages { get; set; } = new List<Garage>();

        public void AddGarage(Garage garage)
        {
            Garages.Add(garage);
            Console.WriteLine("Гараж добавлен в автопарк.");
        }

        public void RemoveGarage(Garage garage)
        {
            Garages.Remove(garage);
            Console.WriteLine("Гараж удален из автопарка.");
        }

        public Vehicle FindVehicle(string brand, string model)
        {
            foreach (var garage in Garages)
            {
                foreach (var vehicle in garage.Vehicles)
                {
                    if (vehicle.Brand == brand && vehicle.Model == model)
                    {
                        return vehicle;
                    }
                }
            }
            return null;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var car1 = new Car("Toyota", "Camry", 2020, 4, "Автоматическая");
            var car2 = new Car("Honda", "Civic", 2019, 4, "Механическая");
            var motorcycle1 = new Motorcycle("Yamaha", "R1", 2021, "Спортбайк", true);

            var garage1 = new Garage();
            garage1.AddVehicle(car1);
            garage1.AddVehicle(motorcycle1);

            var garage2 = new Garage();
            garage2.AddVehicle(car2);

            var fleet = new Fleet();
            fleet.AddGarage(garage1);
            fleet.AddGarage(garage2);

            var foundVehicle = fleet.FindVehicle("Toyota", "Camry");
            if (foundVehicle != null)
            {
                Console.WriteLine($"Найдено транспортное средство: {foundVehicle.Brand} {foundVehicle.Model}");
            }
            else
            {
                Console.WriteLine("Транспортное средство не найдено.");
            }

            garage1.RemoveVehicle(motorcycle1);

            fleet.RemoveGarage(garage2);
        }
    }
}
