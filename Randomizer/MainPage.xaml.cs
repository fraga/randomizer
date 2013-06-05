using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Randomizer.Resources;
using Randomizer.Utils;

namespace Randomizer
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void TxtMin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMin.Text = String.Empty;
        }

        private void TxtMax_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMax.Text = String.Empty;
        }

        private async void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            RandomOrgV1 randomOrg = new RandomOrgV1();

            btnRandom.IsEnabled = false;

            txtResult.Text = await randomOrg.IntegerRequest(Int32.Parse(txtMin.Text), Int32.Parse(txtMax.Text)).Request();

            btnRandom.IsEnabled = true;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}