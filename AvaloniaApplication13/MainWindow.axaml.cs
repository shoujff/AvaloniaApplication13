using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication13.Models;
using AvaloniaApplication13.Repositories;
using AvaloniaApplication13.ViewModels

namespace AvaloniaApplication13
{
    public partial class MainWindow : Window
    {
        private BaseRepository<User> _userRepository = new BaseRepository<User>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateUsersDisplay();
            DataContext = new MainViewModel();

        }
        public void Register_Click(object? sender, RoutedEventArgs e)
        {
            if (Main.IsVisible == true)
            {
                Main.IsVisible = false;
                Register.IsVisible = true;
             
            }
          
        }
        public void Back_Click(object? sender, RoutedEventArgs e)
        {
            Main.IsVisible = true;
            Register.IsVisible = false;
          
        }
        public void RegisterUser_Click(object? sender, RoutedEventArgs e)
        {
            var userRepo = new UserRepository();
            
            string name = TextName.Text;
            string surname = TextSurname.Text;
            string login = TextLogin.Text;
            string password = TextPassword.Text;
          
            var user = new User(name, surname, login, password);
            _userRepository.Create(user);
            TextName.Text = "";
            TextSurname.Text = "";
            TextLogin.Text = "";
            TextPassword.Text = "";
            UpdateUsersDisplay();
            Main.IsVisible = true;
            Register.IsVisible = false;

        }
        private void UpdateUsersDisplay()
        {
           
            UsersList.Items.Clear();

            foreach (var user in _userRepository.GetAll())
            {
               
                string userInfo = $" {user.Name}  {user.Surname} -  {user.Login} ({user.Password})";
                UsersList.Items.Add(userInfo);
            }
        }
    
    }
}