using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Certification
    {
        public int Id { get; set; }

        public Level Level { get; set; }
        public Field Field { get; set; }

        public Certification()
        {

        }
        public Certification(int id, Level level, Field field)
        {
            Id = id;
            Level = level;
            Field = field;
        }
    }
}
