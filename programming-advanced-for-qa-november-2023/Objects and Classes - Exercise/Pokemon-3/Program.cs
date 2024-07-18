namespace _05._Pokemon_Trainer
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }

    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                var data = input.Split();
                var trainerName = data[0];
                var pokemonName = data[1];
                var pokemonElement = data[2];
                var pokemonHealth = int.Parse(data[3]);

                var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                var pokemon = new Pokemon
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Health = pokemonHealth
                };

                trainer.Pokemons.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    var hasElement = trainer.Pokemons.Any(p => p.Element == input);

                    if (hasElement) trainer.Badges++;
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            var sortedTrainers = trainers
                .OrderByDescending(t => t.Badges)
                .ToList();

            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}