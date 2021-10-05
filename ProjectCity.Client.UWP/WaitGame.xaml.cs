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
           /* Dictionary<string, object> Parameters = (Dictionary<string, object>)e.Parameter;
            //Players = new ObservableCollection<Player>();

            Game = (Game)Parameters["Game"];

            Player = (Player)Parameters["Player"];
            Game.Players.Add(Player);

            //foreach (Player p in Game.Players)
            //{
            //    Players.Add(p);
            //}*/

            Game = (Game)e.Parameter;

            Player = (Player)e.Parameter;
            foreach (Player p in Game.Players)
            {
                Players.Add(p);
            }

            Players.Add(Player);

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

        private void btnValid_Click(object sender, RoutedEventArgs e)
        {
            Company.Name = txbNom.Text;
            //var paramters = Task.Factory.StartNew(() => { SyncLoop(); });
            Dictionary<string, object> parameters = Service.SyncLoop(Game, Company);

            InitGame param = new InitGame();
            param.Game = Game;
            param.Company = Company;
            param.Player = Player;

            Frame.Navigate(typeof(Plate), param);
        }
    }
}
