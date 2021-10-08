using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class StaffMember
    {
        public Company Company { get; set; }
        public Developer Developer { get; set; }
        public Turn StartTurn { get; set; }
        public Turn EndTurn { get; set; }
        List<Project> Projects { get; set; }

        public StaffMember()
        {
            this.Projects = new List<Project>();
        }
    }
}
