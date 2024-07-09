using System;
namespace Raiding.Models
{
	public abstract class Healer:BaseHero
	{
		public Healer(string name):base(name)
		{
		}
        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {this.Power}";
        }
    }
}

