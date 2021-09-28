using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public partial class Level
    {
        public int Id { get; set; }
        public int Niveau { get; set; }
        public string Description { get; set; }

        public Level()
        {

        }

        public Level(int id, int niveau, string description)
        {
            Id = id;
            Niveau = niveau;
            Description = description;
        }
    }
}
