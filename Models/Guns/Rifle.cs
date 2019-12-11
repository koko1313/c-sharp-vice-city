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
            this.BulletsPerShot = initialBulletsPerShot;
        }

        public override int Fire()
        {
            if (BulletsInBarrel < initialBulletsPerShot)
            {
                CanFire = false;
            }

            if (!CanFire)
            {
                Reload();
            }

            if (BulletsInBarrel >= initialBulletsPerShot)
            {
                CanFire = true;
            }

            if (CanFire)
            {
                BulletsInBarrel -= BulletsPerShot;
                return BulletsPerShot;
            }

            return 0;
        }
    }
}
