using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                foreach (var civilian in civilPlayers)
                {
                    while (civilian.IsAlive && gun.CanFire)
                    {
                        civilian.TakeLifePoints(gun.Fire());
                    }
                }
            }

            foreach (var civilian in civilPlayers)
            {
                if (civilian.IsAlive)
                {
                    foreach (var gun in civilian.GunRepository.Models)
                    {
                        while (mainPlayer.IsAlive && gun.CanFire)
                        {
                            mainPlayer.TakeLifePoints(gun.Fire());
                        }

                    }
                }
            }
        }
    }
}
