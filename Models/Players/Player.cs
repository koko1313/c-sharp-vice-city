using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private IRepository<IGun> gunRepository;
        private bool isAlive;

        protected Player(string name, int lifePoints) 
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.gunRepository = new GunRepository();
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
        }

        #region GettersAndSetters
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(
                        message: "Player's name cannot be null or a whitespace!");
                }
                name = value;
            }
        }

        public int LifePoints
        {
            get
            {
                return lifePoints;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        message: "Player life points cannot be below zero!");
                }
                lifePoints = value;
            }
        }

        public IRepository<IGun> GunRepository { get; }

        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            private set
            {
                if (this.LifePoints > 0)
                {
                    isAlive = true;
                }
                else
                {
                    isAlive = false;
                }
            }
        }
        #endregion
    }
}
