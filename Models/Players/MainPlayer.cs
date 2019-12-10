using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    class MainPlayer : Player
    {
        private const int initialLifePoint = 100;
        private const string initialName = "Tommy Vercetti";
        public MainPlayer() : base(initialName, initialLifePoint)
        {

        }
    }
}
