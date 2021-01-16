using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Enum;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun currentGun = CreateGun(type, name, bulletsCount);

            this.guns.Add(currentGun);

            return String.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var currentGun = guns.FindByName(gunName);

            if (currentGun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer currentPlayer = CreatePlayer(type, username, health, armor, currentGun);
            players.Add(currentPlayer);

            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string StartGame()
        {

            return this.map.Start(this.players.Models.Where(p => p.IsAlive).ToList());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in players.Models.OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health).ThenBy(x => x.Username))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
        private static IGun CreateGun(string type, string name, int bulletsCount)
        {
            IGun gun;
            Enum.TryParse(type, out GunType gunType);
            gun = gunType switch
            {
                GunType.Pistol => new Pistol(name, bulletsCount),
                GunType.Rifle => new Rifle(name, bulletsCount),
                _ => throw new ArgumentException(ExceptionMessages.InvalidGunType)
            };
            return gun;
        }
        private static IPlayer CreatePlayer(string type, string username, int health, int armor, IGun gun)
        {
            IPlayer player;
            Enum.TryParse(type, out PlayerType playerType);
            player = playerType switch
            {
                PlayerType.CounterTerrorist => new CounterTerrorist(username, health, armor, gun),
                PlayerType.Terrorist => new Terrorist(username, health, armor, gun),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPlayerType)
            };
            return player;
        }
    }
}
