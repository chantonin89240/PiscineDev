using ProjectCity.Client.Services;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class WaitGame : Page
    {
        public Game Game = new Game();
        public Player Player { get; set; }
        public List<Player> Players { get; set; }
        public Company Company = new Company();



        public WaitGame()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            InitGame initGame = (InitGame)e.Parameter;

            Game = initGame.Game;

            Player = initGame.Player;
            foreach (Player p in Game.Players)
            {
                Players.Add(p);
            }

            Game.Players.Add(Player);

            Company = new Company();
            Company.CompanyType = (CompanyType)Game.CompanyType;
            Company.Name = Company.CompanyType.Title + " de " + Player.Pseudo;
            txbNom.Text = Company.Name;
            Company.Player = Player;

            txtNbJoueur.Text = Game.Players.Count() + "/" + Game.PlayerMax + " joueur(s) en attente";

            Service.SetGame(Game);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Game.Players.Remove(Game.Players.Find(player => player.Id == Player.Id));
            Frame.GoBack();
        }

        private void btnValid_Click(object sender, RoutedEventArgs e) /////////////////////////////////////// UN THREAD
        {
            Company.Name = txbNom.Text;
            InitGame parameters = Service.SyncLoop(Game, Company);

            Frame.Navigate(typeof(Plate), parameters);
        }
    }
}
