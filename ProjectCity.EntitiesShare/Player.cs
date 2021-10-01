using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Player : Person
    {
        public string Pseudo { get; set; }
        public string Password { get; set; }

        public Player()
        {

        }

        public Player(string pseudo)
        {
            Pseudo = pseudo;
        }
    }
}
