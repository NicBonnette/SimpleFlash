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
    public sealed partial class Adding : Page
    {
        public Adding()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void GoToPrevPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeckMaintenance));
        }

        private void UpdateCard_Click(object sender, RoutedEventArgs e)
        {
            //Save this new card
            App.DataModel.AddCard(QuestionTextBox.Text, AnswerTextBox.Text);

            Frame.Navigate(typeof(DeckMaintenance));
        }
    }
}
