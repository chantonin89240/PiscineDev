using ProjectCity.EntitiesShare;
using System;
using System.Collections.Generic;
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
        public Game Game { get; set; }
        public Player Player { get; set; }
        public Company Company { get; set; }

        public WaitGame()
        {
            this.InitializeComponent();
            Task.Factory.StartNew(() => { SyncLoop(); });

            //socket ajoute le joueur

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Dictionary<string, object> Parameters = (Dictionary<string, object>)e.Parameter;

            Player = (Player)Parameters["Player"];
            Game = (Game)Parameters["Game"];

            Company = new Company();
            Company.CompanyType = new CompanyType(); //Socket récupère le type de companie
            Company.Name = Company.CompanyType.Title + " de " + Player.Pseudo;
            txbNom.Text = Company.Name;
            Company.Player = Player;

            Game.Players.Add(Player);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Game.Players.Remove(Game.Players.Find(player => player.Id == Player.Id));
            //Socket retirer le joueur dans la game
            //Frame.Navigate(typeof(CreateOrJoinGame), Player);
        }

        private void btnValid_Click(object sender, RoutedEventArgs e)
        {
            Company.Name = txbNom.Text;
        }

        private void SyncLoop()
        {
            while (Game.Players.Count() < 6)
            {
                Game = new Game();//socket récupère la game;

                System.Threading.Thread.Sleep(3000);
            }

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("Company", Company);
            Parameters.Add("Game", Game);

            //Frame.Navigate(typeof(Plate), Parameters);
        }
    }
}