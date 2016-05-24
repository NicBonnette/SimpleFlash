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
    public sealed partial class Editing : Page
    {
        private Card card;

        public Editing()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationContext nav = (NavigationContext)e.Parameter;

            card = nav.theCard;
            QuestionTextBox.Text = card.Question;
            AnswerTextBox.Text = card.Answer;
        }

        private void UpdateCard_Click(object sender, RoutedEventArgs e)
        {//Save the card details, and go back to the deck editing page

            App.DataModel.UpdateCard(card, QuestionTextBox.Text, AnswerTextBox.Text);

            Frame.Navigate(typeof(DeckMaintenance));
        }

        private void GoToPrevPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeckMaintenance));
        }
    }
}
