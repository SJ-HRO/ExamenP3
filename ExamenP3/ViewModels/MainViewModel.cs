using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ExamenP3.Services;
using ExamenP3.Models;

namespace ExamenP3.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ChuckNorrisService _chuckNorrisService;
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Joke> Jokes { get; } new ObservableCollection<Joke>();

        public ICommand AddJokeCommand { get; }
        public ICommand LoadJokesCommand { get; }

        public MainViewModel()
        {

        }
        public MainViewModel(ChuckNorrisService chuckNorrisService, DatabaseService databaseService) {
        _chuckNorrisService = chuckNorrisService;
        _databaseService = databaseService;

            LoadJokesCommand = new Command(async () => await LoadJokesAsync());
            AddJokeCommand = new Command(async () => await AddJokeAsync());
        }
        
        private async Task LoadJokesAsync()
        {
            Jokes.Clear();
            var jokes = await _databaseService.GetJokesAsync();
            foreach (var joke in jokes)
            {
                Jokes.Add(joke);
            }
        }
        
        private async Task AddJokeAsync()
        {
            var jokeText = await _chuckNorrisService.GetRandomJokeAsync();

            var random = new Random();
            var code = $"SC{random.Next(1000, 2000)}";

            var joke = new Joke
            {
                JokeText = jokeText,
                Code = code
            };
            await _databaseService.SaveJokeAsync(joke);
            Jokes.Add(joke);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
