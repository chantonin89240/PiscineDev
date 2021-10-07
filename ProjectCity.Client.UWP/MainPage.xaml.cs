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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectCity.Client.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       

        public List<Game> LstGame { get; set; }
        public Player Player { get; set; }

        

        public MainPage()
        {
            this.InitializeComponent();
            LstGame = Service.Games();
        }

        // Rejoindre une partie
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //var laGameSelect = LstGame[lvGame.SelectedIndex];

            //Player = new Player(1, "Vinc", "Sim", "pseudo");

            //Dictionary<string, object> Inscription = new Dictionary<string, object>();
            //Inscription["Game"] = laGameSelect;
            //Inscription["Player"] = Player;


            InitGame initGame = new InitGame() {
                Game = (Game)lvGame.SelectedItem,
                Player = new Player(1, "Vinc", "Sim", "pseudo")
        };

            //faire evoluer e en dictionnaire dico["game"] = object lagame, dico["player"] = objet leplayer

            Frame.Navigate(typeof(WaitGame), initGame );
        }
         
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
