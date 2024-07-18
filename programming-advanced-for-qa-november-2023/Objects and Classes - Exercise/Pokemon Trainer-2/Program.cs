using System.ComponentModel.Design;
using System.Xml.Linq;

namespace Pokemon_Trainer_2
{


    public class Trainer
    {
        public Trainer(string trainer)
        {
            TrainerName = trainer;
            NumberOfBadges = 0;
            List<Pokemon> AllPokemons = new List<Pokemon>();
        }
        
        public string TrainerName { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> AllPokemons { get; set; }

    }

    public class Pokemon
    {
        public Pokemon(string pokemon, string element, int health)
        {

            PokemonName = pokemon;
            PokemonElement = element;
            Health = health;
        }

        public string PokemonName { get; set; }
        public string PokemonElement { get; set; }
        public int Health { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
           var trainers=new List<Trainer>();

            while (command != "Tournament")
            {
                string[] pokemonAndTrainerInfo = command.Split(" ");
                var trainerName = pokemonAndTrainerInfo[0];
                var pokemonName = pokemonAndTrainerInfo[1];
                var pokemonElement = pokemonAndTrainerInfo[2];
                int pokemonHealth = int.Parse(pokemonAndTrainerInfo[3]);

                Trainer currentTrainer = new(trainerName);
                Pokemon currentPokemon = new(pokemonName, pokemonElement, pokemonHealth);

                var trainer = trainers.FirstOrDefault(t => t.TrainerName == trainerName);

                if (trainer == null)
                {
                    trainer = new(trainerName);
                    trainers.Add(trainer);
                }

                //var pokemon = new Pokemon
                //{
                //    PokemonName = pokemonName,
                //    PokemonElement = pokemonElement,
                //    Health = pokemonHealth,
                //};
                //trainer.AllPokemons.Add(pokemon);
                trainer.AllPokemons.Add(currentPokemon);
            }
            string input=Console.ReadLine();
            while(input !="End")
            {
                foreach(var trainer in trainers)
                {
                    var hasElement = trainer.AllPokemons.Any(p => p.PokemonElement == input);
                    if (hasElement) 
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach(var pokemon in trainer.AllPokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.AllPokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            var sortedTrainers = trainers.OrderByDescending(s => s.NumberOfBadges).ThenBy(x => x).ToList();

            foreach(var trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.TrainerName} {trainer.NumberOfBadges} {trainer.AllPokemons.Count}");
            }


        }
            
    }
}