using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    class Rifle : Gun
    {
        private const int initialBulletsPerBarrel = 50;
        private const int initialTotalBullets = 500;
        private const int initialBulletsPerShot = 5;

        public Rifle(string name) : base(name, initialBulletsPerBarrel, initialTotalBullets)
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
