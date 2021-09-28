using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class Training
    {
        public int Id { get; set; }

        public StaffMember StaffMember { get; set; }
        public TrainingSession TrainingSession { get; set; }
        public Turn StartTurn { get; set; }
        public Turn EndTurn { get; set; }

        public Training()
        {

        }
    }
}
