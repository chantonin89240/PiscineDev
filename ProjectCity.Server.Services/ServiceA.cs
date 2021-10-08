using System;
using System.Collections.Generic;
using System.Text;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;

namespace ProjectCity.Server.Services
{
    public static partial class Service
    {
        static List<Training> trainings = new List<Training>();

        public static List<Training> GetTraining()
        {
            return trainings;
        }

        public static void GenerateTraining()
        {
            trainings = Serializer.FromJson<List<Training>>("../../../../ProjectCity.VM/JSon/Formation.json");
        }

        public static void GetTurn()
        {
            
        }
    }
}
