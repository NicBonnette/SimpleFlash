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
    public sealed partial class Answering : Page
    {
        private Card card;

        public Answering()
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
            AnswerTextBlock.Text = card.Answer;
        }

        private void DontKnowButton_Click(object sender, RoutedEventArgs e)
        {
            ///add the card back into the question queue
            App.DataModel.AddToEndOfTestDeck(card);
            ///then go to the next question
            Frame.Navigate(typeof(Asking));//no need to check if there is one... we just added something!
        }

        private void KnewItButton_Click(object sender, RoutedEventArgs e)
        {
            ///go to next question - the current card will have gone from the askingDeck 
            ///(until next time you initialise it - you have not removed it from the overall collection...)
            ///

            if (App.DataModel.HasNextTestCard())
            {
                Frame.Navigate(typeof(Asking));
            }
            else
                Frame.Navigate(typeof(MainPage));
        }


        private void BackToStart_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }


    }
}
