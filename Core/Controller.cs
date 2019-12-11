using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    class Controller : IController
    {
        private MainPlayer mainPlayer;
        private List<IPlayer> players;
        private Queue<Gun> guns;
        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.players = new List<IPlayer>();
            this.guns = new Queue<Gun>();
        }
        public string AddGun(string type, string name)
        {
            switch (type)
            {
                case "Pistol":
                    this.guns.Enqueue(new Pistol(name));
                    return $"Successfully added {name} of type: {type}";
                case "Rifle":
                    this.guns.Enqueue(new Rifle(name));
                    return $"Successfully added {name} of type: {type}";
                default:
                    return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (!guns.Any())
            {
                return "There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                Gun gun = guns.Dequeue();
                mainPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            if (players.Any(x=>x.Name == name))
            {
                Gun gun = guns.Dequeue();
                players.Find(x=>x.Name == name).GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Civil Player: {name}";
            }
            return "Civil player with that name doesn't exists!";
        }

        public string AddPlayer(string name)
        {
            this.players.Add(new CivilPlayer(name));
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            GangNeighbourhood fightScene = new GangNeighbourhood();
            fightScene.Action(mainPlayer, players);

            if (mainPlayer.LifePoints==100)
            {
                bool isOk = true;
                foreach (var civilian in players)
                {
                    if (civilian.LifePoints < 50)
                    {
                        isOk = false;
                        break;
                    }
                }
                if (isOk)
                {
                    return "Everything is okay!";
                }
            }
            int dead = 0;
            int alive = 0;
            foreach (var civilian in players)
            {
                if (civilian.IsAlive)
                {
                    alive++;
                }
                else
                {
                    dead++;
                }
            }
            return $"A fight happened:" + Environment.NewLine + $"Tommy live points: {mainPlayer.LifePoints}!"
                + Environment.NewLine + $"Tommy has killed: {dead} players!" + Environment.NewLine
                + $"Left Civil Players: {alive}!";
        }
    }
}
