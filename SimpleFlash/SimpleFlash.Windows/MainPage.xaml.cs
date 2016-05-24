using SimpleFlash.DataSources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpleFlash
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        ObservableCollection<Card> cards;

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            cards = await App.DataModel.GetCards(); //loads up the cards from json
          App.DataModel.ResetTestDeck();//resets the testDeck to a queue of the full set of cards
            this.DataContext = cards;
            
        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.DataModel.HasNextTestCard())
            {
                Frame.Navigate(typeof(Asking));
            }

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeckMaintenance));
        }
    }
}
