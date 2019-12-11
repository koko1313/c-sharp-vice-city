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
        private bool isAlive;
        private IRepository<IGun> gunRepository;
        private int lifePoints;
        

        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.IsAlive = true;
            this.GunRepository = new GunRepository();
        }
        public void TakeLifePoints(int points)
        {
            if (this.LifePoints>=points)
            {
                this.LifePoints -= points;
            }
            else
            {
                this.LifePoints = 0;
            }
            if (lifePoints<=0)
            {
                this.IsAlive = false;
            }
        }
        #region gettersAndSetters
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(
                        message: "Player's name cannot be null or a whitespace!");
                }
                this.name = value;
            }
        }
        public bool IsAlive
        {
            get => this.isAlive;
            protected set
            {
                this.isAlive = value;
            }
        }
        public IRepository<IGun> GunRepository { get; }
        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        message: "Player life points cannot be below zero!");
                }
                this.lifePoints = value;
            }
        }
        #endregion
    }
}
