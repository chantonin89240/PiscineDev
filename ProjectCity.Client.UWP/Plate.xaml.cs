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
    public sealed partial class Plate : Page
    {
        public Plate()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*Dictionary<string, object> Parameters = (Dictionary<string, object>)e.Parameter;
            Company Company = (Company)Parameters["Compagny"];*/
        }

        // méthode qui incrémente le plateau (tour, argent, projet en cours, devops recruter)
        public void UpdatePlate()
        {

        }
        private void ButPasserTour_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButDev_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DevOpsRecruit));
        }

        private void ButProjet_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProjectRecup)); 
        }

        private void ButFormation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Formation));
        }

        private void ButPrevision_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Preview));
        }

        private void ButListDev_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListDevOps));
        }

        private void ButListProjet_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListProject));
        }

       
    }
}
