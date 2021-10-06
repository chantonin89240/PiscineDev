using System;
using System.Collections.Generic;
using System.Text;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;

namespace ProjectCity.Server.Services
{
    public static partial class Service
    { 

        public static List<Training> GetTraining()
        {
            List<Training> listeTraining = new List<Training>();

            listeTraining.Add(
                new Training
                {
                    Id = 1,
                    Title = "formation une",
                    Duration = 3,
                    Price = 1000,
                    Capacity = 4,
                    Certifications = GetCertifications()
                }
            );

            listeTraining.Add(
                new Training
                {
                    Id = 2,
                    Title = "formation deux",
                    Duration = 5,
                    Price = 1600,
                    Capacity = 6,
                    Certifications = GetCertifications()

                }
            );

            listeTraining.Add(
                new Training
                {
                    Id = 3,
                    Title = "formation trois",
                    Duration = 2,
                    Price = 800,
                    Capacity = 3,
                    Certifications = GetCertifications()

                }
            );
            List<Training> listeForma = Serializer.FromJson<List<Training>>("formation");

            return listeTraining;
        }
        public static void GenerateTraining()
        {

        }

        public static void GetTurn()
        {
            
        }
    }
}
