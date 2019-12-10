using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private bool canFire;
        private int barrelCapacity;
        
        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
            this.barrelCapacity = bulletsPerBarrel;
        }

        public abstract int Fire();

        protected void Reload(int barrelCapacity) 
        {
            if (this.TotalBullets >= barrelCapacity) 
            {
                this.BulletsPerBarrel = barrelCapacity;
                this.TotalBullets -= barrelCapacity;
            }
        }

        protected int DecreaseBullets(int bullets)
        {
            int firedBullets = 0;
            if(this.BulletsPerBarrel - bullets >= 0) 
            {
                this.BulletsPerBarrel -= 1;
                firedBullets = bullets;
            }

            return firedBullets;
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
                        message: "Name cannot be null or a white space!");
                }
                name = value;
            }
        }

        public int BulletsPerBarrel 
        {
            get
            {
                return bulletsPerBarrel;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        message: "Bullets cannot be below zero!");
                }
                bulletsPerBarrel = value;
            }
        }

        public int TotalBullets 
        {
            get
            {
                return totalBullets;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        message: "Total bullets cannot be below zero!");
                }
                totalBullets = value;
            }
        }

        public bool CanFire 
        {
            get 
            {
                return canFire;
            }
            set
            {
                if (bulletsPerBarrel > 0 || totalBullets > 0)
                {
                    canFire = true;
                }
                else
                {
                    canFire = false;
                }
            }
        }
        #endregion
    }
}
