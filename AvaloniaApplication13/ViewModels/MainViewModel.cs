using AvaloniaApplication13.Commands;
using AvaloniaApplication13.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AvaloniaApplication13.Models

namespace AvaloniaApplication13.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged

    {
        private readonly BaseRepository<User> userRepository;
        private string _firstName = "";
        private string _secondName = "";
        private string login = "";
        private string password = "";
        private string status = "";
        private bool statusVisible = false;
        
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName
        {
            get => $"{FirstName} {SecondName }";
        }
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public string Greeting => string.IsNullOrWhiteSpace(FullName) ? "Введите имя чтобы увидеть приветствие" : $"Привет {FullName}";
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public bool CanLogin => !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);
        
        public RelayCommand LoginCommand { get; }
        public MainViewModel()
        {
            LoginCommand = new RelayCommand(OnLogin, () => CanLogin);
        }
        public void OnLogin()
        {
           
        }
    }
}
