using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    abstract class Player : IPlayer
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public IRepository<IGun> GunRepository { get; }
        public int LifePoints { get; set; }

        public Player(string name, int lifePoints)
        {
            SetName(name);
            SetLifePoints(lifePoints);
            SetIsAlive(lifePoints);
        }
        public void TakeLifePoints(int points)
        {
            if (this.LifePoints<points)
            {
                this.LifePoints -= points;
            }
            else
            {
                this.LifePoints = 0;
            }
            SetIsAlive(this.LifePoints);
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    message: "Player's name cannot be null or a whitespace!");
            }
            this.Name = name;
        }
        public void SetLifePoints(int lifePoints)
        {
            if (lifePoints<0)////////////////////////////////////////////////////////////////////////// ERROR(<=)
            {
                throw new ArgumentException(
                    message: "Player life points cannot be below zero!");
            }
            this.LifePoints = lifePoints;
        }
        public void SetIsAlive(int lifePoints)
        {
            if (lifePoints>0)
            {
                this.IsAlive = true;
            }
            else
            {
                this.IsAlive = false;
            }
        }
    }
}
