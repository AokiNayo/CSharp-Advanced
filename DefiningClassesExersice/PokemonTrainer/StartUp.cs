using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = String.Empty;

            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);

                var test = trainers.FirstOrDefault(x => x.Name == trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (test == null)
                {
                    Trainer currentTrainer = new Trainer(trainerName, new List<Pokemon>());
                    currentTrainer.Pokemons.Add(currentPokemon);
                    trainers.Add(currentTrainer);
                    continue;
                }

                var existingTrainer = trainers.FirstOrDefault(x => x.Name == trainerName);
                existingTrainer.Pokemons.Add(currentPokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    var matchedPokemons = trainer.Pokemons.FindAll(x => x.Element == input);

                    if (matchedPokemons.Any())
                    {
                        trainer.NumberOfBadges++;
                        continue;
                    }

                    matchedPokemons = trainer.Pokemons.FindAll(x => x.Element != input);

                    foreach (var currPokemon in matchedPokemons)
                    {
                        currPokemon.Health -= 10;
                        if (currPokemon.Health <= 0)
                        {
                            trainer.Pokemons.Remove(currPokemon);
                        }
                    }
                }
            }

            trainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();

            foreach (var item in trainers)
            {
                Console.WriteLine($"{item.Name} {item.NumberOfBadges} {item.Pokemons.Count}");
            }
        }
    }
}
