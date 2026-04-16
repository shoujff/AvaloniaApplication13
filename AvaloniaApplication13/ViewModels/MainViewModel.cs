using AvaloniaApplication13.Commands;
using AvaloniaApplication13.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AvaloniaApplication13.Models;
using AvaloniaApplication13.Data;

namespace AvaloniaApplication13.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged

    {
       
        private readonly UserRepository userRepository;
        private string _firstName = "";
        private string _secondName = "";
        private string login = "";
        private string password = "";
        private string _status = "";
        private bool _statusVisible= false;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value; OnPropertyChanged();
            }
        }


            public bool StatusVisible
             { 
            get 
            {
                return _statusVisible;
            }
            set {
                _statusVisible = value;
                OnPropertyChanged();
            }
           }  

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FullName));
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                OnPropertyChanged(nameof(FullName));
                RegisterCommand.RaiseCanExecuteChanged();
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
                LoginCommand.RaiseCanExecuteChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
                LoginCommand.RaiseCanExecuteChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }
        public string Greeting => string.IsNullOrWhiteSpace(FullName) ? "Введите имя чтобы увидеть приветствие" : $"Привет {FullName}";
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public bool CanLogin => !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);
        public bool CanRegister()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(SecondName)  && !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);
        }
        public RelayCommand LoginCommand { get; }
        public RelayCommand RegisterCommand { get; }
        public MainViewModel()
        {
            
            userRepository = new UserRepository();
            LoginCommand = new RelayCommand(OnLogin, () => CanLogin);
            RegisterCommand = new RelayCommand(OnRegister, () => CanRegister());
        }
        public void OnLogin()
        {
            Status = "Вошел";
            StatusVisible = true;
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(StatusVisible));
        }
        public void OnRegister()
        {
            var newUser = new User
            {
                Name = FirstName,
                Surname = SecondName,
                Login = Login,
                Password = Password,
                IsLogin = false
            };
            userRepository.CreateUser(newUser);

            FirstName = "";
            SecondName = "";
            Login = "";
            Password = "";
            Status = "создан";
            StatusVisible = true;
        }
        
    }
}
