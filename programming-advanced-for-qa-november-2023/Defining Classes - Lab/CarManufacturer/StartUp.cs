using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            //string make=Console.ReadLine();
            //string model=Console.ReadLine();
            //int year=int.Parse(Console.ReadLine());
            //double fuelQuantity=double.Parse(Console.ReadLine()); 
            //double fuelConsumption=double.Parse(Console.ReadLine());
            
            //Car firstCar= new Car();
            //Car secondCar= new Car(make,model,year);
            //Car thirdCar= new Car(make,model,year,fuelQuantity,fuelConsumption);

            var tires = new Tire[]
            {
                new Tire(1,2.5),
                new Tire(1,2.1),
                new Tire(2,0.5),
                new Tire(2,2.3),
            };

            var engine = new Engine(560, 6300);
            var lambo=new Car("Lamborghini","Urus",2010,250,9,engine,tires);
            //car.Drive(2000);
            //Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
            //car.Drive(2000);
            Console.WriteLine(lambo.WhoAmI());
        }
    }
}
