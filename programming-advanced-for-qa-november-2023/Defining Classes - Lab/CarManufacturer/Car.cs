using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;

        }

        public Car(string make, string model, int year):this()
        {
            this.Make=make;
            this.Model=model;   
            this.Year=year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public Car(string make,string model,int year,double fuelQuantity,double fuelConsumption,Engine engine, Tire[] tires):this(make,model,year,fuelQuantity,fuelConsumption)
        {
            this.Engine=engine;
            this.Tires = tires;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            if(this.FuelQuantity -(this.FuelConsumption * distance)>0)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }     
        }
        public string WhoAmI()
        {
           return ($"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelConsumption}");
        }
    }//carfuel-distance*distance
}
