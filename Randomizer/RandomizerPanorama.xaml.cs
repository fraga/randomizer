using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Randomizer.Resources;
using Randomizer.Utils;

namespace Randomizer
{
    public partial class RandomizerPanorama : PhoneApplicationPage
    {
        public ObservableCollection<string> RandomNumbers = new ObservableCollection<string>();

        public RandomizerPanorama()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            lisResults.DataContext = RandomNumbers;
        }

        private void TxtMin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMin.Text = String.Empty;
        }

        private void TxtMax_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMax.Text = String.Empty;
        }

        private async void appBarButton_Click(object sender, EventArgs e)
        {
            try
            {
                RandomOrgV1 randomOrg = new RandomOrgV1();

                RandomNumbers.Add(await randomOrg.IntegerRequest(Int32.Parse(txtMin.Text), Int32.Parse(txtMax.Text)).Request());

            }
            catch (RandoOrgMinGreaterThanMaxException exception)
            {
                //txtResult.Text = exception.Message;
            }
            catch (Exception exception)
            {
                //txtResult.Text = exception.Message;
            }
        }

        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Buttons.Add(RandomizerAppButton());
        }

        private ApplicationBarIconButton RandomizerAppButton()
        {
            ApplicationBarIconButton randomizerAppButton = new ApplicationBarIconButton(new Uri("/Assets/refresh.png", UriKind.Relative));
            randomizerAppButton.Text = AppResources.AppBarButtonText;
            randomizerAppButton.Click += appBarButton_Click;
            
            return randomizerAppButton;
        }
    }
}