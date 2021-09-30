using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.EntitiesShare
{
    public class TrainingSession
    {
        public int Id { get; set; }

        public StaffMember StaffMember { get; set; }
        public Training Training { get; set; }
        public Turn StartTurn { get; set; }
        public Turn EndTurn { get; set; }

        public TrainingSession()
        {

        }
    }
}
