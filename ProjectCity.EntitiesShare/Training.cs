using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Training
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Duration { get; set; } //turn  =month
        public double Price { get; set; }
        public int Capacity { get; set; }
        public List<Certification> Certifications { get; set; }

        public Training()
        {
            this.Certifications = new List<Certification>();
        }
    }
}
