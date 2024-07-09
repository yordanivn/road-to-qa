using System;
namespace Animals.Models
{
	public class Cat:Animal
	{
		private string name { get; set; }
		private string favouriteFood { get; set; }

        public Cat(string name,string favouriteFood):base(name,favouriteFood)
        {

        }
        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()} {Environment.NewLine}MEEOW";
        }
    }
}

