using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectCity.Client.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Plate : Page
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public List<Player> lstPlayers { get; set; }
        public Company Company { get; set; }

        public Plate()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var init = (InitGame)e.Parameter;
            Game = init.Game;
            Player = init.Player;
            Company = init.Company;
            lstPlayers = init.lstPlayers;

        }

        // méthode qui maj le nombre de projet en cours pour le joueur 
        public string UpPlateProjet()
        {
            string truc = "oof";
            List<Project> LstProject = new List<Project>();
            // il faut récupérer la liste des projets d'une compagnie puis faut une condition qui ajoute les projet dans la liste seulement s'il n'ont pas dépasser leurs durer depuis leurs debut (start)
            //Service.GetProject();
            //Player.projec
            return truc;
        }
        // méthode qui maj le nombre de devops recruter
        public string UpPlateDevops()
        {
            int total = Company.StaffMembers.Count();
            string truc = total.ToString();
            return truc;
        }
        // méthode qui passe le tours, une fois que tout les joueurs ont passer le tours passe au suivant
        private void ButPasserTour_Click(object sender, RoutedEventArgs e)
        {

        }
        // méthode qui envoie sur la page DevOpsRescuit.xaml
        private void ButDev_Click(object sender, RoutedEventArgs e)
        {
            InitGame param = new InitGame();
            param.Game = Game;
            param.Company = Company;
            param.Player = Player;
            param.lstPlayers = lstPlayers;

            Frame.Navigate(typeof(DevOpsRecruit), param);
        }
        // méthode qui envoie sur la page projectRecup.xaml
        private void ButProjet_Click(object sender, RoutedEventArgs e)
        {
            InitGame param = new InitGame();
            param.Game = Game;
            param.Company = Company;
            param.Player = Player;
            param.lstPlayers = lstPlayers;

            Frame.Navigate(typeof(ProjectRecup), param);
        }
        // méthode qui envoie sur la page Formation.xaml
        private void ButFormation_Click(object sender, RoutedEventArgs e)
        {
            InitGame param = new InitGame();
            param.Game = Game;
            param.Company = Company;
            param.Player = Player;
            param.lstPlayers = lstPlayers;

            Frame.Navigate(typeof(Formation), param);
        }
        // méthode qui envoie sur la page Preview.xaml
        private void ButPrevision_Click(object sender, RoutedEventArgs e)
        {
            InitGame param = new InitGame();
            param.Game = Game;
            param.Company = Company;
            param.Player = Player;
            param.lstPlayers = lstPlayers;

            Frame.Navigate(typeof(Preview), param);
        }
        // méthode qui envoie sur la page ListDevOps.xaml
        private void ButListDev_Click(object sender, RoutedEventArgs e)
        {
            InitGame param = new InitGame();
            param.Game = Game;
            param.Company = Company;
            param.Player = Player;
            param.lstPlayers = lstPlayers;

            Frame.Navigate(typeof(ListDevOps), param);
        }
        // méthode qui envoie sur la page ListProject.xaml
        private void ButListProjet_Click(object sender, RoutedEventArgs e)
        {
            InitGame param = new InitGame();
            param.Game = Game;
            param.Company = Company;
            param.Player = Player;
            param.lstPlayers = lstPlayers;

            Frame.Navigate(typeof(ListProject), param);
        }
    }
}
