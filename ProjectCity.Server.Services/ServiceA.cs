using System;
using System.Collections.Generic;
using System.Text;
using ProjectCity.EntitiesShare;

namespace ProjectCity.Server.Services
{
    public partial class Service
    { 

        public static List<TrainingSession> GetTrainingSession()
        {
            List<TrainingSession> listeTraining = new List<TrainingSession>();

            listeTraining.Add(
                new TrainingSession
                {
                    Id = 1,
                    Title = "formation une",
                    Duration = 3,
                    Price = 1000,
                    Capacity = 4,
                    Certifications = GetCertification()
                }
            );

            listeTraining.Add(
                new TrainingSession
                {
                    Id = 2,
                    Title = "formation deux",
                    Duration = 5,
                    Price = 1600,
                    Capacity = 6,
                    Certifications = GetCertification()

                }
            );

            listeTraining.Add(
                new TrainingSession
                {
                    Id = 3,
                    Title = "formation trois",
                    Duration = 2,
                    Price = 800,
                    Capacity = 3,
                    Certifications = GetCertification()

                }
            );

            return listeTraining;
        }

        private static List<Certification> GetCertification()
        {
            throw new NotImplementedException();
        }

        public static void GenerateTraining()
        {

        }
    }
}
