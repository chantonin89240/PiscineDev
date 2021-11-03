using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.VM
{
    public class InitGame
    {
        // Id Player client
        public int IdPlayer { get; set; }

        // Information partie
        public Game Game { get; set; }

        // Liste de développeurs choisie par un joueur sur communication client to server
        // Liste de développeurs attribué par le jeu sur communication server to client
        public Dictionary<Company, Developer> LstChoiceDev { get; set; }

        // Liste de projets choisie par un joueur sur communication client to server
        // Liste de projets attribué par le jeu sur communication server to client
        public Dictionary<Company, Project> LstChoiceProject { get; set; }

        // Liste de sessions de formation choisie par un joueur sur communication client to server
        // Liste de sessions de formation attribué par le jeu sur communication server to client
        public Dictionary<Company, TrainingSession> LstChoiceSession { get; set; }

        // Liste de développeur fourni par le serveurs
        public List<Developer> Developers { get; set; }

        // Liste de projets fourni par le serveurs
        public List<Project> Projects { get; set; }

        // Liste de sessions de formation fourni par le serveurs
        public List<TrainingSession> Sessions { get; set; }

        // Liste de événements aléatoires fourni par le serveurs
        public Event TurnEvent { get; set; } 
    }


}