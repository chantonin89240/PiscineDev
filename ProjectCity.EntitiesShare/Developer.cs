using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Developer : Person
    {

        public List<Certification> Certifications { get; set; }
        public List<Project> Projects { get; set; }
        public double Salary { get; set; }

        public Developer()
        {
            this.Certifications = new List<Certification>();
            this.Projects = new List<Project>();
        }
    }
}
