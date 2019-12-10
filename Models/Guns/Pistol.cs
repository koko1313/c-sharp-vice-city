using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    class Pistol : Gun
    {
        private const int initialBulletsPerBarrel = 10;
        private const int initialTotalBullets = 100;
        private const int initialBulletsPerShot = 1;

        public Pistol(string name) : base(name, initialBulletsPerBarrel,initialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel < initialBulletsPerShot) 
            {
                this.Reload(initialBulletsPerBarrel);
            }

            int firedBullets = this.DecreaseBullets(initialBulletsPerShot);
            return firedBullets;
        }
    }
}
