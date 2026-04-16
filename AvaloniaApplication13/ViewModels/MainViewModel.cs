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
using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AvaloniaApplication13.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged

    {
       
        private readonly UserRepository userRepository;
        private string _registerFirstName = "";
        private string _registerSecondName = "";
        private string _registerLogin = "";
        private string _registerPassword = "";
        private string _registerConfirmPassword = "";


        private string _loginLogin = "";
        private string _loginPassword = "";

        private bool _showRegisterForm = false;
        private string _status = "";
        private bool _statusVisible= false;
        private string statusColor = "";
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value; OnPropertyChanged();
            }
        }
        public string StatusColor
        {
            get { return statusColor; }
            set
            {
                statusColor = value; OnPropertyChanged();
            }
        }


        public bool StatusVisible
        { 
            get { return _statusVisible; }
            set {
                _statusVisible = value;
                OnPropertyChanged();
            }
           }
        public string LoginLogin
        {
            get { return _loginLogin; }
            set
            {
                _loginLogin = value;
                OnPropertyChanged();
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public string LoginPassword
        {
            get { return _loginPassword; }
            set
            {
                _loginPassword = value;
                OnPropertyChanged();
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public string RegisterFirstName
        {
            get { return _registerFirstName; }
            set
            {
                _registerFirstName = value;
                OnPropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }

        public string RegisterSecondName
        {
            get { return _registerSecondName; }
            set
            {
                _registerSecondName = value;
                OnPropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }
        public string RegisterLogin
        {
            get { return _registerLogin; }
            set
            {
                _registerLogin = value;
                OnPropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }

        public string RegisterPassword
        {
            get { return _registerPassword; }
            set
            {
                _registerPassword = value;
                OnPropertyChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }
        public bool ShowRegisterForm
        {
            get { return _showRegisterForm; }
            set
            {
                _showRegisterForm = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowLoginForm));
            }
        }
        public bool ShowLoginForm => !_showRegisterForm;
        public string FullName
        {
            get => $"{RegisterFirstName} {RegisterSecondName}";
        }
        public RelayCommand LoginCommand { get; }
        public RelayCommand RegisterCommand { get; }
        public RelayCommand SwitchModeCommand { get; }
        public bool CanLogin => !string.IsNullOrWhiteSpace(LoginLogin) &&
                                !string.IsNullOrWhiteSpace(LoginPassword);

        public bool CanRegister()
        {
            return !string.IsNullOrWhiteSpace(RegisterFirstName) &&
                   !string.IsNullOrWhiteSpace(RegisterSecondName) &&
                   !string.IsNullOrWhiteSpace(RegisterLogin) &&
                   !string.IsNullOrWhiteSpace(RegisterPassword) &&
                   RegisterPassword.Length >= 6;
        }


       
      
       

       

        public MainViewModel()
        {
            
            userRepository = new UserRepository();
            LoginCommand = new RelayCommand(OnLogin, () => CanLogin);
            RegisterCommand = new RelayCommand(OnRegister, () => CanRegister());
            SwitchModeCommand = new RelayCommand(OnSwitchMode);
        }
        public void OnSwitchMode()
        {
            ShowRegisterForm = !ShowRegisterForm;
            if (ShowRegisterForm)
            {
                RegisterFirstName = "";
                RegisterSecondName = "";
                RegisterLogin = "";
                RegisterPassword = "";
            }
            else
            {
                LoginLogin = "";
                LoginPassword = "";
            }
            StatusVisible = false;
        }
        public void OnLogin()
        {
            var user = userRepository.GetByLogin(LoginLogin);
            if (user == null)
            {
                Status = "Пользователь с таким логином не найден";
                StatusColor = "Red";
                StatusVisible = true;

                return;
            }
            if (user.Password != LoginPassword)
            {
                Status = "Неверный пароль!";
                StatusColor = "Red";
                StatusVisible = true;
                return;
            }
            StatusColor = "Green";
            Status = $"Добро пожаловать, {user.FullName}!";
            StatusVisible = true;
        }
        public void OnRegister()
        {

            if (!userRepository.UserExists(RegisterLogin))
            {



                var newUser = new User
                {
                    Name = RegisterFirstName,
                    Surname = RegisterSecondName,
                    Login = RegisterLogin,
                    Password = RegisterPassword,
                    IsLogin = false
                };

                userRepository.CreateUser(newUser);
                Status = "Пользователь успешно создан!";
                StatusColor = "Green";
                StatusVisible = true;
            }
            else
            {
                StatusColor = "Red";
                Status = "Пользователь с таким логином уже существует";
                StatusVisible = true;
            }

            

            RegisterFirstName = "";
            RegisterSecondName = "";
            RegisterLogin = "";
            RegisterPassword = "";

            RegisterCommand.RaiseCanExecuteChanged();
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
