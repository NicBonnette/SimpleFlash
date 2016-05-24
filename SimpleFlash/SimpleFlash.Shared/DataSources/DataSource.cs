using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using System.IO;
using System.Linq;

namespace SimpleFlash.DataSources
{
    public class Card : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        
        public Card()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public class DataSource
    {
        private ObservableCollection<Card> _cards;
        private Queue<Card> _toTestDeck;

        const string fileName = "cards.json";

        public DataSource()
        {
            _cards = new ObservableCollection<Card>();
            _toTestDeck = new Queue<Card>();
        }
               
            public async Task<ObservableCollection<Card>> GetCards()
            {
                await ensureDataLoaded();
                return _cards;
            }

        

        private async Task ensureDataLoaded()
        {
            if (_cards.Count == 0)
                await getCardDataAsync();

            return;
        }

        private async Task getCardDataAsync()
        {
            if (_cards.Count != 0)
                return;

            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Card>));

            try
            {
                // Add a using System.IO;
                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName))
                {
                    _cards = (ObservableCollection<Card>)jsonSerializer.ReadObject(stream);
                }
            }

            catch
            {
                _cards = new ObservableCollection<Card>();
            }
        }

        public async void AddCard(string question, string answer)
        {
            var card = new Card();
            card.Question = question;
            card.Answer = answer;

            _cards.Add(card);
            await saveCardDataAsync();
        }

        public async void UpdateCard(Card card, string question, string answer)
        {
            var newCard = new Card();
            newCard.Question = question;
            newCard.Answer = answer;

            _cards.Add(newCard);
            _cards.Remove(card);
            await saveCardDataAsync();
        }

        public async void DeleteCard(Card card)
        {
            _cards.Remove(card);
            await saveCardDataAsync();
        }

        private async Task saveCardDataAsync()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Card>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName,
                CreationCollisionOption.ReplaceExisting))
            {
                jsonSerializer.WriteObject(stream, _cards);
            }
        }

        public async void ResetTestDeck()
        {
            _toTestDeck.Clear();
            await ensureDataLoaded();
            foreach (Card card in _cards)
            {
                _toTestDeck.Enqueue(card);
            }
        }

        public Card GetNextTestCard()
        {
            if (HasNextTestCard()) { return (Card)_toTestDeck.Dequeue(); }
            else return null;
        }

        public bool HasNextTestCard()
        {
            return (_toTestDeck.Count != 0);
        }

        public void AddToEndOfTestDeck(Card card)
        {
            if (card != null)
                _toTestDeck.Enqueue(card);
        }


    }
}

