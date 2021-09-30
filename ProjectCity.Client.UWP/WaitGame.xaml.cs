using ProjectCity.EntitiesShare;
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
    public sealed partial class WaitGame : Page
    {
        public Game Game { get; set; }
        public Player Player { get; set; }

        public WaitGame()
        {
            this.InitializeComponent();

            //socket ajoute le joueur

            while (Game.Players.Count() < 6)
            {
                //socket récupère la game

                
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Dictionary<string, Object> Parameters = new Dictionary<string, object>();
            Parameters = (Dictionary<string, Object>)e.Parameter;
            Player = (Player)Parameters["Player"];
            Game = (Game)Parameters["Game"];
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateOrJoinGame), Player);
            //Socket retirer le joueur dans la game
        }
    }
}
