﻿using System;
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
        public MainPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
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

                txtResult.Text = await randomOrg.IntegerRequest(Int32.Parse(txtMin.Text), Int32.Parse(txtMax.Text)).Request();
            }
            catch (RandoOrgMinGreaterThanMaxException exception)
            {
                txtResult.Text = exception.Message;
            }
            catch (Exception exception)
            {
                txtResult.Text = exception.Message;
            }
        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/refresh.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            appBarButton.Click += appBarButton_Click;
            ApplicationBar.Buttons.Add(appBarButton);
        }
    }
}