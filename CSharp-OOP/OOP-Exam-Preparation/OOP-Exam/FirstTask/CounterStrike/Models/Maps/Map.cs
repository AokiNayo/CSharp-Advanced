using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        //public string Start(ICollection<IPlayer> players)
        //{
        //    var terrorists = players.Where(p => p.GetType().Name == nameof(Terrorist));

        //    var counterTerrorists = players.Where(p => p.GetType().Name == nameof(CounterTerrorist));


        //    while (terrorists.Any(t => t.IsAlive) && counterTerrorists.Any(c => c.IsAlive))
        //    {
        //        foreach (var terrorist in terrorists)
        //        {
        //            foreach (var counterTerrorist in counterTerrorists)
        //            {

        //                counterTerrorist.TakeDamage(terrorist.Gun.Fire());

        //            }
        //        }

        //        foreach (var counterTerrorist in counterTerrorists)
        //        {
        //            foreach (var terrorist in terrorists)
        //            {

        //                terrorist.TakeDamage(counterTerrorist.Gun.Fire());

        //            }
        //        }
        //    }

        //    return counterTerrorists.Any(c => c.IsAlive) ? "Counter Terrorist wins!" : "Terrorist wins!";
        //}
        // MINE

        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;
        public Map()
        {
            terrorists = new List<IPlayer>();
            counterTerrorists = new List<IPlayer>();
        }
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(p => p.GetType().Name == nameof(Terrorist));

            var counterTerrorists = players.Where(p => p.GetType().Name == nameof(CounterTerrorist));


            while (terrorists.Any(t => t.IsAlive) && counterTerrorists.Any(c => c.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    foreach (var counterTerrorist in counterTerrorists)
                    {

                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());

                    }
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    foreach (var terrorist in terrorists)
                    {

                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());

                    }
                }
            }

            return counterTerrorists.Any(c => c.IsAlive) ? "Counter Terrorist wins!" : "Terrorist wins!";

            //SeparateTeams(players);

            //while (isTeamAlive(terrorists) && isTeamAlive(counterTerrorists))
            //{
            //    AttackTeam(terrorists, counterTerrorists);
            //    AttackTeam(counterTerrorists, terrorists);
            //}

            //if (isTeamAlive(counterTerrorists))
            //{
            //    return "Counter Terrorist wins!";
            //}
            //else if (isTeamAlive(terrorists))
            //{
            //    return "Terrorist wins!";
            //}

            //return "Doesnt work correctly";
        }

        //private bool isTeamAlive(ICollection<IPlayer> players)
        //{
        //    return players.Any(x => x.IsAlive);
        //}
        //private void AttackTeam(ICollection<IPlayer> attacking, ICollection<IPlayer> defending)
        //{
        //    foreach (var attackers in attacking.Where(x => x.IsAlive))
        //    {
        //        foreach (var defenders in defending.Where(x => x.IsAlive))
        //        {
        //            var damageDone = attackers.Gun.Fire();
        //            defenders.TakeDamage(damageDone);
        //        }
        //    }
        //}
        //private void SeparateTeams(ICollection<IPlayer> players)
        //{
        //    foreach (var player in players)
        //    {
        //        if (player is Terrorist) // player is Terrorist
        //        {
        //            terrorists.Add(player);
        //        }
        //        else if (player is CounterTerrorist)
        //        {
        //            counterTerrorists.Add(player);
        //        }
        //    }
        //}
    }
}
