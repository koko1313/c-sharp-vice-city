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
        public Pistol(string name) : base(name, initialBulletsPerBarrel,initialTotalBullets, initialBulletsPerShot)
        {
        }
    }
}
