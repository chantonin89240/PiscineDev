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
using Windows.UI.Popups;
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

            Service.StartClient();
            LstGame = Service.Games();


        }

        // Rejoindre une partie
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            InitGame initGame = new InitGame();

            initGame.Game = (Game)lvGame.SelectedItem;

            var pseudo = "";
            TextBox tb_pseudo = new TextBox();
            tb_pseudo.PlaceholderText = "Pseudo";
            Grid contentGrid = new Grid();
            contentGrid.Children.Add(tb_pseudo);

#pragma warning disable UWP003 // UWP-only
            var dialog = new ContentDialog
            {
                Title = "Entre ton pseudo",
                Content = contentGrid,
                PrimaryButtonText = "Valider",
                SecondaryButtonText = "Annuler"
            };
#pragma warning restore UWP003 // UWP-only
            var result = await dialog.ShowAsync();



            if (result == ContentDialogResult.Primary && tb_pseudo.Text == "" || tb_pseudo.Text == null)
            {
                pseudo = "Player"+DateTime.Now.ToString();
            }
            else
            {
                pseudo = tb_pseudo.Text;

            }
            Player player = new Player()
            {
                Pseudo = pseudo,
                Id = (int)(new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()),
            };


            initGame.Game.Players.Add(player);
            initGame.IdPlayer = player.Id;
            

            Frame.Navigate(typeof(WaitGame), initGame);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
