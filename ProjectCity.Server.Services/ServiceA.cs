﻿using System;
using System.Collections.Generic;
using System.Text;
using ProjectCity.EntitiesShare;

namespace ProjectCity.Server.Services
{
    public partial class Service
    { 

        public List<Training> GetTraining()
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

            return listeTraining;
        }
        public void GenerateTraining()
        {

        }
    }
}