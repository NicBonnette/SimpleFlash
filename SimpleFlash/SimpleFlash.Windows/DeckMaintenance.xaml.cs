using SimpleFlash.DataSources;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpleFlash
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DeckMaintenance : Page
    {
        public DeckMaintenance()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var cards = await App.DataModel.GetCards();
            this.DataContext = cards;
        }

        private void GoToMainPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Adding));
        }

        private void EditCard_Click(object sender, RoutedEventArgs e)
        {
            //find the selected card
            Card selectedCard = (Card)myListBox.SelectedItem;

            if (selectedCard != null)
            {
                //process it to send for editing
                NavigationContext nav = new NavigationContext();
                nav.theCard = selectedCard;

                //send it for editing            
                Frame.Navigate(typeof(Editing), nav);
            }
            //if there isn't a selected card, do nothing
        }

        private void DeleteCard_Click(object sender, RoutedEventArgs e)
        {
            Card selectedCard = (Card)myListBox.SelectedItem;
            if (selectedCard != null) { App.DataModel.DeleteCard(selectedCard); }
        }
    }
}
