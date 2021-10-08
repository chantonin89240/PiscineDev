using ProjectCity.Client.Services;
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
    public sealed partial class DevOpsRecruit : Page
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public List<Player> lstPlayers { get; set; }
        public Company Company { get; set; }

        public DevOpsRecruit()
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

        private void ButGoBAck_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        // méthode qui retourne le dernier tour 
        private string UpTours()
        {
            int TourSup = Game.Turns.Count();
            string total;
            if (TourSup == 0)
            {
                total = "0";
            }
            else
            {
                int tours = Game.Turns.Max().Id;
                total = tours.ToString();
            }
            return total;
        }

        // méthode qui récupére des devops est les affiche
        public List<Developer> ListeDevops()
        {
            List<Developer> ListeDevops = new List<Developer>();
            ListeDevops = Service.ListeDevops(Game);
            return ListeDevops;
        }

    }
}
