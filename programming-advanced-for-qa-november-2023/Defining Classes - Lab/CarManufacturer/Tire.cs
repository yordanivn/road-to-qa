using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int year,double preasure)
        { 
            Year= year;
            Preasure= preasure;
        }
        public int Year {  get; set; }
        public double Preasure { get; set; }
    }
}
