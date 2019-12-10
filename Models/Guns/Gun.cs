using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    abstract class Gun : IGun
    {
        public string Name { get; set; }
        public int BulletsPerBarrel { get; set; }
        public int TotalBullets { get; set; }
        public bool CanFire { get; set; }
        private int bulletsInBarrel { get; set; }
        private int bulletsPerShot { get; set; }
        public Gun(string name, int bulletsPerBarrel, int totalBullets, int bulletsPerShot)
        {
            SetName(name);
            SetBulletsPerBarrel(bulletsPerBarrel);
            SetTotalBullets(totalBullets);
            SetCanFire(bulletsPerShot, totalBullets);
            this.bulletsPerShot = bulletsPerShot;
        }

        public int Fire()
        {
            SetCanFire(bulletsInBarrel, TotalBullets);
            if(!CanFire)
            {
                Reload();
            }

            if (CanFire)
            {
                bulletsInBarrel -= bulletsPerShot;
                return bulletsPerShot;
            }

            return -1;
        }
        private void Reload()
        {
            if (bulletsInBarrel<=0)
            {
                if (TotalBullets>BulletsPerBarrel)
                {
                    bulletsInBarrel = BulletsPerBarrel;
                    TotalBullets -= BulletsPerBarrel;
                }
                else
                {
                    bulletsInBarrel = TotalBullets;
                    TotalBullets -= bulletsInBarrel;
                }
            }
        }
        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    message: "Name cannot be null or a white space!");
            }
            this.Name = name;
        }
        private void SetBulletsPerBarrel(int bulletsPerBarrel)
        {
            if (bulletsPerBarrel<0)
            {
                throw new ArgumentException(
                    message: "Bullets cannot be below zero!");
            }
            this.BulletsPerBarrel = bulletsPerBarrel;
        }
        private void SetTotalBullets(int totalBullets)
        {
            if (totalBullets < 0)
            {
                throw new ArgumentException(
                    message: "Total bullets cannot be below zero!");
            }
            this.TotalBullets = totalBullets;
        }
        private void SetCanFire(int bulletsInBarrel, int totalBullets)
        {
            if (bulletsInBarrel>0)//////////////////////////////ERROR (barrel/total)
            {
                this.CanFire = true;
            }
            else
            {
                this.CanFire = false;
            }
        }
    }
}
