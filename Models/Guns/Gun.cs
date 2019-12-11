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
        
        public Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
            this.BulletsInBarrel = bulletsPerBarrel;
            this.CanFire = true;
        }

        public abstract int Fire();
        protected void Reload()
        {
            if (TotalBullets>BulletsPerBarrel)
            {
                BulletsInBarrel = BulletsPerBarrel;
                TotalBullets -= BulletsPerBarrel;
            }
            else
            {
                BulletsInBarrel = TotalBullets;
                TotalBullets -= BulletsInBarrel;
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
                        message: "Name cannot be null or a white space!");
                }
                this.name = value;
            }
        }
        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        message: "Bullets cannot be below zero!");
                }
                this.bulletsPerBarrel = value;
            }
        }
        public int TotalBullets
        {
            get => this.totalBullets;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        message: "Total bullets cannot be below zero!");
                }
                this.totalBullets = value;
            }
        }
        public bool CanFire
        {
            get => this.canFire;
            protected set
            {
                this.canFire = value;
            }
        }
        protected int BulletsInBarrel { get; set; }
        protected int BulletsPerShot { get; set; }
        #endregion
    }
}
